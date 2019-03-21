using System.Collections;
using NSubstitute;
using NUnit.Framework;
using UniRx;
using UnityEngine;
using UnityEngine.TestTools;
using VirtualKeyboard.Managers.InputFieldManagement.Manager;
using VirtualKeyboard.Objects.Keyboard.Controllers.PositionController;
using Zenject;

namespace VirtualKeyboard.Tests.PlayModeTests.Objects.Keyboard.Controllers
{
    /// <summary>
    /// Tests for KeyboardPositionController
    /// </summary>
    public class KeyboardPositionControllerTests : ZenjectIntegrationTestFixture
    {
        private KeyboardPositionController _target;
        private RectTransform _controlledTransform;
        private IInputFieldSelectionManager _selectionManager;
        private Subject<Rect?> _selectedRectAsObservable;
        private IKeyboardPositionControllerConfig _positionControllerConfig;

        [SetUp]
        public void BeforeEveryTest()
        {
            _controlledTransform = new GameObject().AddComponent<RectTransform>();

            _selectionManager = Substitute.For<IInputFieldSelectionManager>();
            _selectedRectAsObservable = new Subject<Rect?>();
            _selectionManager.SelectedRectAsObservable.Returns(_selectedRectAsObservable);

            _positionControllerConfig = Substitute.For<IKeyboardPositionControllerConfig>();

            PreInstall();
            Container.Bind<IInputFieldSelectionManager>().FromInstance(_selectionManager).AsSingle();
            Container.Bind<IKeyboardPositionControllerConfig>().FromInstance(_positionControllerConfig).AsSingle();
            Container.Bind<RectTransform>().WithId("KeyboardPositionController - Controlled RectTransform")
                .FromInstance(_controlledTransform).AsCached();
            Container.BindInterfacesAndSelfTo<KeyboardPositionController>().FromNew().AsSingle();
            PostInstall();

            _target = Container.Resolve<KeyboardPositionController>();
        }

        [TearDown]
        public void AfterEveryTest()
        {
            Object.Destroy(_controlledTransform.gameObject);
        }

        [UnityTest]
        public IEnumerator Appears_On_The_Position_On_Next_Rect()
        {
            _controlledTransform.position = Vector3.one * 50; 

            _positionControllerConfig.PositionOffset.Returns(Vector2.zero);
            _selectedRectAsObservable.OnNext(new Rect(0,0,2,2));
            yield return null;
            Assert.That(Vector3.Distance(new Vector3(1,1,0),_controlledTransform.position) < 0.01f);

            _selectedRectAsObservable.OnNext(new Rect(1, -1, 2, 2));
            yield return null;
            Assert.That(Vector3.Distance(new Vector3(2, 0, 0), _controlledTransform.position) < 0.01f);
        }

        [UnityTest]
        public IEnumerator Appears_On_The_Position_And_Applies_Config()
        {
            _controlledTransform.position = Vector3.one * 50;

            _positionControllerConfig.PositionOffset.Returns(new Vector2(1, -1));
            _selectedRectAsObservable.OnNext(new Rect(0, 0, 2, 2));
            yield return null;
            Assert.That(Vector3.Distance(new Vector3(2, 0, 0), _controlledTransform.position) < 0.01f);

            _selectedRectAsObservable.OnNext(new Rect(1, -1, 2, 2));
            yield return null;
            Assert.That(Vector3.Distance(new Vector3(3, -1, 0), _controlledTransform.position) < 0.01f);
        }

        [UnityTest]
        public IEnumerator Dispose_Works_Correctly()
        {
            _controlledTransform.position = Vector3.one * 50;
            _target.Dispose();

            _selectedRectAsObservable.OnNext(new Rect(0, 0, 2, 2));
            yield return null;
            Assert.That(Vector3.Distance(new Vector3(50, 50, 0), _controlledTransform.position) < 0.01f);
        }
    }
}