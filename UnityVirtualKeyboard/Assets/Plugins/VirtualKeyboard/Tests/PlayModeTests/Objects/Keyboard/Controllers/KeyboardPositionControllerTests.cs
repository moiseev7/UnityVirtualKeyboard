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
        private Subject<RectTransform> _selectedRectTransformAsObservable;
        private IKeyboardPositionControllerConfig _positionControllerConfig;

        [SetUp]
        public void BeforeEveryTest()
        {
            _controlledTransform = new GameObject().AddComponent<RectTransform>();

            _selectionManager = Substitute.For<IInputFieldSelectionManager>();
            _selectedRectTransformAsObservable = new Subject<RectTransform>();
            _selectionManager.SelectedRectTransformAsObservable.Returns(_selectedRectTransformAsObservable);

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

            _positionControllerConfig.PositionOffset.Returns(Vector3.zero);
            _controlledTransform.position = Vector3.zero;
            _controlledTransform.sizeDelta = Vector2.one * 2;
            _selectedRectTransformAsObservable.OnNext(_controlledTransform);
            yield return null;
            Assert.That(Vector3.Distance(new Vector3(-1,-1,0),_controlledTransform.position) < 0.01f);

            _controlledTransform.position = new Vector3(-1,1,1);
            _selectedRectTransformAsObservable.OnNext(_controlledTransform);
            yield return null;
            Assert.That(Vector3.Distance(new Vector3(-2, 0, 1), _controlledTransform.position) < 0.01f);
        }

        [UnityTest]
        public IEnumerator Appears_On_The_Position_And_Applies_Config()
        {
            _controlledTransform.position = Vector3.one * 50;

            _positionControllerConfig.PositionOffset.Returns(new Vector3(1, -1, 0));
            _controlledTransform.position = Vector3.zero;
            _controlledTransform.sizeDelta = Vector2.one * 2;
            _selectedRectTransformAsObservable.OnNext(_controlledTransform);
            yield return null;
            Debug.Log($"Position: {_controlledTransform.position}");
            Assert.That(Vector3.Distance(new Vector3(0, -2, 0), _controlledTransform.position) < 0.01f);

            _positionControllerConfig.PositionOffset.Returns(new Vector3(1, -1, -4));
            _controlledTransform.position = new Vector3(-1, 1, 1);
            _selectedRectTransformAsObservable.OnNext(_controlledTransform);
            yield return null;
            Debug.Log($"Position: {_controlledTransform.position}");
            Assert.That(Vector3.Distance(new Vector3(-1, -1, -3), _controlledTransform.position) < 0.01f);
        }

        [UnityTest]
        public IEnumerator Dispose_Works_Correctly()
        {
            _controlledTransform.position = Vector3.one * 50;
            _target.Dispose();

            _selectedRectTransformAsObservable.OnNext(_controlledTransform);
            yield return null;
            Debug.Log($"Position: {_controlledTransform.position}");
            Assert.That(Vector3.Distance(new Vector3(50, 50, 50), _controlledTransform.position) < 0.01f);
        }
    }
}