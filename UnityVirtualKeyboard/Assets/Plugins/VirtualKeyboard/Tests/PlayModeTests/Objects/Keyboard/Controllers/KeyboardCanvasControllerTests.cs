using System.Collections;
using NSubstitute;
using NUnit.Framework;
using UniRx;
using UnityEngine;
using UnityEngine.TestTools;
using VirtualKeyboard.Managers.InputFieldManagement.Manager;
using VirtualKeyboard.Objects.Keyboard.Controllers.CanvasController;
using Zenject;

namespace VirtualKeyboard.Tests.PlayModeTests.Objects.Keyboard.Controllers
{
    /// <summary>
    /// Tests for KeyboardCanvasController
    /// </summary>
    public class KeyboardCanvasControllerTests : ZenjectIntegrationTestFixture
    {
        private Canvas _selectedCanvas;
        private Canvas _controlledCanvas;
        private KeyboardCanvasController _target;
        private IInputFieldSelectionManager _fieldSelectionManager;
        private Subject<Canvas> _parentCanvasSubject;
        private Camera _camera;

        [SetUp]
        public void BeforeEveryTest()
        {
            _parentCanvasSubject = new Subject<Canvas>();
            _fieldSelectionManager = Substitute.For<IInputFieldSelectionManager>();
            _fieldSelectionManager.ParentCanvasAsObservable.Returns(_parentCanvasSubject);

            _camera = new GameObject().AddComponent<Camera>();

            _controlledCanvas = new GameObject().AddComponent<Canvas>();
            _selectedCanvas = new GameObject().AddComponent<Canvas>();

            PreInstall();
            Container.Bind<IInputFieldSelectionManager>().FromInstance(_fieldSelectionManager).AsSingle();
            Container.Bind<Canvas>().WithId("KeyboardCanvasController - Controlled Canvas")
                .FromInstance(_controlledCanvas).AsSingle();
            Container.BindInterfacesAndSelfTo<KeyboardCanvasController>().FromNew().AsSingle();
            PostInstall();

            _target = Container.Resolve<KeyboardCanvasController>();
        }

        [TearDown]
        public void AfterEveryTest()
        {
            Object.Destroy(_controlledCanvas.gameObject);
            Object.Destroy(_selectedCanvas.gameObject);
            Object.Destroy(_camera.gameObject);
        }

        [UnityTest]
        public IEnumerator Applies_Render_Mode()
        {
            _controlledCanvas.renderMode = RenderMode.WorldSpace;

            _selectedCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
            _parentCanvasSubject.OnNext(_selectedCanvas);

            yield return null;
            Assert.AreEqual(RenderMode.ScreenSpaceOverlay, _controlledCanvas.renderMode);

            _selectedCanvas.renderMode = RenderMode.WorldSpace;
            _selectedCanvas.worldCamera = _camera;

            _parentCanvasSubject.OnNext(_selectedCanvas);

            yield return null;
            Assert.AreEqual(RenderMode.WorldSpace, _controlledCanvas.renderMode);
        }

        [UnityTest]
        public IEnumerator Applies_Render_Camera_Mode()
        {
            _controlledCanvas.worldCamera = null;
            _selectedCanvas.worldCamera = _camera;
            _parentCanvasSubject.OnNext(_selectedCanvas);

            yield return null;
            Assert.AreEqual(_camera, _controlledCanvas.worldCamera);
        }

        [UnityTest]
        public IEnumerator Applies_RectTransform()
        {
            var controlledRectTransform = _controlledCanvas.GetComponent<RectTransform>();
            var selectedRectTransform = _selectedCanvas.GetComponent<RectTransform>();
            selectedRectTransform.position = Vector3.one;
            selectedRectTransform.sizeDelta = new Vector2(100,200);
            selectedRectTransform.localScale = Vector3.one * 3;

            _parentCanvasSubject.OnNext(_selectedCanvas);

            yield return null;
            Assert.That(Vector3.Distance(controlledRectTransform.position, selectedRectTransform.position) < 0.01f);
            Assert.That(Vector2.Distance(controlledRectTransform.sizeDelta, selectedRectTransform.sizeDelta) < 0.01f);
            Assert.That(Vector3.Distance(controlledRectTransform.localScale, Vector3.one * 3) < 0.01f);
        }

        [UnityTest]
        public IEnumerator Dispose_Works()
        {
            _target.Dispose();
            _controlledCanvas.renderMode = RenderMode.WorldSpace;
            Assert.AreEqual(RenderMode.WorldSpace, _controlledCanvas.renderMode);

            _selectedCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
            _parentCanvasSubject.OnNext(_selectedCanvas);

            yield return null;
            Assert.AreEqual(RenderMode.WorldSpace, _controlledCanvas.renderMode);
        }
    }
}