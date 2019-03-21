using System.Collections;
using NSubstitute;
using NUnit.Framework;
using UniRx;
using UnityEngine;
using UnityEngine.TestTools;
using VirtualKeyboard.Managers.InputFieldManagement.Manager;
using VirtualKeyboard.Objects.Keyboard.Controllers.ShowController;
using Zenject;

namespace VirtualKeyboard.Tests.PlayModeTests.Objects.Keyboard.Controllers
{
    /// <summary>
    /// Tests for KeyboardShowController
    /// </summary>
    public class KeyboardShowControllerTests : ZenjectIntegrationTestFixture
    {
        private KeyboardShowController _target;
        private GameObject _controlledGameObject;
        private IInputFieldSelectionManager _selectionManager;
        private Subject<bool> _isFieldSelectedObservable;

        [SetUp]
        public void BeforeEveryTest()
        {
            _controlledGameObject = new GameObject();
            _selectionManager = Substitute.For<IInputFieldSelectionManager>();
            _isFieldSelectedObservable = new Subject<bool>();
            _selectionManager.IsFieldSelectedAsObservable.Returns(_isFieldSelectedObservable);

            PreInstall();

            Container.Bind<GameObject>().WithId("KeyboardShowController - Controlled Object")
                .FromInstance(_controlledGameObject).AsCached();

            Container.Bind<IInputFieldSelectionManager>().FromInstance(_selectionManager).AsSingle();

            Container.BindInterfacesAndSelfTo<KeyboardShowController>().FromNew().AsSingle();

            PostInstall();

            _target = Container.Resolve<KeyboardShowController>();
        }


        [TearDown]
        public void AftereveryTest()
        {
            Object.Destroy(_controlledGameObject);
        }

        [UnityTest]
        public IEnumerator Hides_By_Default()
        {
            yield return null;
            Assert.AreEqual(false, _controlledGameObject.activeInHierarchy);
        }

        [UnityTest]
        public IEnumerator Shows_On_Selection()
        {
            _controlledGameObject.SetActive(false);
            _isFieldSelectedObservable.OnNext(true);
            yield return null;
            Assert.AreEqual(true, _controlledGameObject.activeInHierarchy);
        }

        [UnityTest]
        public IEnumerator Hides_On_Deselection()
        {
            _controlledGameObject.SetActive(true);
            _isFieldSelectedObservable.OnNext(false);
            yield return null;
            Assert.AreEqual(false, _controlledGameObject.activeInHierarchy);
        }


        [UnityTest]
        public IEnumerator Doesnt_Affect_Object_After_Dispose()
        {
            _controlledGameObject.SetActive(true);
            _target.Dispose();
            _isFieldSelectedObservable.OnNext(false);
            yield return null;
            Assert.AreEqual(true, _controlledGameObject.activeInHierarchy);
        }
    }
}