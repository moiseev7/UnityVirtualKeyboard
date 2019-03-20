using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.TestTools;
using UnityEngine.UI;
using VirtualKeyboard.Managers.InputFieldManagement.Configs;
using VirtualKeyboard.Managers.InputFieldManagement.Manager;
using Zenject;

namespace VirtualKeyboard.Tests.PlayModeTests.Managers.InputFieldManagement.Manager
{
    /// <summary>
    /// Tests for InputFieldManager
    /// </summary>
    public abstract class InputFieldManagerTests : ZenjectIntegrationTestFixture
    {
        protected TMP_InputField TmpInputField;
        protected InputField UnityInputField;
        protected InputFieldSelectionConfigContainer ConfigContainer;
        protected UnityInputFieldSelectionConfig UnityInputFieldSelectionConfig;
        protected TMP_InputFieldSelectionConfig TmpInputFieldSelectionConfig;
        protected InputFieldManager Target;
        protected Canvas Canvas;
        protected EventSystem EventSystem;

        
        protected bool? SelectionFlag;
        protected Rect? SelectedRect;
        protected Canvas ParentCanvas;
        protected bool? SupportsSubmit;
        protected Texture2D SubmitIcon;

        private CompositeDisposable _compositeDisposable;

        [SetUp]
        public void BeforeEveryTest()
        {
            // Canvas setup
            Canvas = new GameObject().AddComponent<Canvas>();
            Canvas.name = "Canvas";

            // TMP_InputField setup
            TmpInputField = new GameObject().AddComponent<TMP_InputField>();
            TmpInputField.name = "TmpInputField";
            var textComponent = new GameObject().AddComponent<TextMeshProUGUI>();
            textComponent.gameObject.AddComponent<RectTransform>();
            TmpInputField.textComponent = textComponent;
            TmpInputField.transform.SetParent(Canvas.transform);
            TmpInputField.gameObject.AddComponent<RectTransform>();
            TmpInputField.textViewport = (RectTransform)TmpInputField.transform;

            // Unity InputField setup
            UnityInputField = new GameObject().AddComponent<InputField>();
            UnityInputField.name = "UnityInputField";
            UnityInputField.transform.SetParent(Canvas.transform);

            // Config setup
            UnityInputFieldSelectionConfig = ScriptableObject.CreateInstance<UnityInputFieldSelectionConfig>();
            TmpInputFieldSelectionConfig = ScriptableObject.CreateInstance<TMP_InputFieldSelectionConfig>();
            ConfigContainer = ScriptableObject.CreateInstance<InputFieldSelectionConfigContainer>();
            InitializeConfigsContainer(); //Here we specify which config to use

            EventSystem = new GameObject().AddComponent<EventSystem>();
            EventSystem.name = "EventSystem";
            EventSystem.current = EventSystem;

            // Bindings
            PreInstall();
            Container.BindInterfacesTo<InputFieldSelectionConfigContainer>().FromInstance(ConfigContainer).AsSingle();
            Container.BindInterfacesAndSelfTo<InputFieldManager>().FromNew().AsSingle();
            PostInstall();

            Target = Container.Resolve<InputFieldManager>();

            SelectionFlag = null;
            SelectedRect = null;
            ParentCanvas = null;
            SupportsSubmit = null;
            SubmitIcon = null;

            _compositeDisposable = new CompositeDisposable();

            _compositeDisposable.Add(Target.IsFieldSelectedAsObservable.Subscribe(flag => SelectionFlag = flag));
            _compositeDisposable.Add(Target.SelectedRectAsObservable.Subscribe(rect => SelectedRect = rect));
            _compositeDisposable.Add(Target.ParentCanvasAsObservable.Subscribe(canvas => ParentCanvas = canvas));
            _compositeDisposable.Add(Target.SupportsSubmitAsObservable.Subscribe(supports => SupportsSubmit = supports));
            _compositeDisposable.Add(Target.SubmitIconAsObservable.Subscribe(icon => SubmitIcon = icon));
        }
        
        [TearDown]
        public void AfterEveryTest()
        {
            _compositeDisposable.Dispose();
            Object.Destroy(Canvas.gameObject);
            Object.Destroy(ConfigContainer);
            Object.Destroy(UnityInputFieldSelectionConfig);
            Object.Destroy(TmpInputFieldSelectionConfig);
            Object.Destroy(EventSystem.gameObject);
        }

        /// <summary>
        /// Here we specify which config to use
        /// </summary>
        protected abstract void InitializeConfigsContainer();

        public abstract IEnumerator Select_Unity_Input_Field();
        public abstract IEnumerator Select_TMP_Input_Field();

        public abstract IEnumerator Select_Suitable_Input_Field_Then_Null();

        public abstract IEnumerator Select_Null_Field_Then_Suitable_Input();

        public abstract IEnumerator Try_Submit_To_Suitable_Field();
        public abstract IEnumerator Try_Submit_To_Null();
        public abstract IEnumerator Try_Submit_To_Not_Suitable_Field();

        public abstract IEnumerator Try_Type_To_Suitable_Field();
        public abstract IEnumerator Try_Type_To_Null();
        public abstract IEnumerator Try_Type_To_Not_Suitable_Field();

        public abstract IEnumerator Delete_Submit_To_Suitable_Field();
        public abstract IEnumerator Delete_Submit_To_Null();
        public abstract IEnumerator Delete_Submit_To_Not_Suitable_Field();

        public class TMPOnly : InputFieldManagerTests
        {
            protected override void InitializeConfigsContainer()
            {
                ConfigContainer = new InputFieldSelectionConfigContainer();
                ConfigContainer.Initialize(new List<AbstractInputFieldSelectionConfig>{TmpInputFieldSelectionConfig});
            }

            [UnityTest]
            public override IEnumerator Select_Unity_Input_Field()
            {

                EventSystem.current.SetSelectedGameObject(UnityInputField.gameObject);
                yield return null;
                Assert.AreEqual(false, SelectionFlag);
                Assert.AreEqual(null, SelectedRect);
                Assert.AreEqual(null, ParentCanvas);
                Assert.AreEqual(false, SupportsSubmit);
                Assert.AreEqual(null, SubmitIcon);
            }

            [UnityTest]
            public override IEnumerator Select_TMP_Input_Field()
            {

                EventSystem.current.SetSelectedGameObject(TmpInputField.gameObject);
                yield return null;
                Assert.AreEqual(true, SelectionFlag);
                Assert.AreEqual(((RectTransform)TmpInputField.transform).rect, SelectedRect);
                Assert.AreEqual(Canvas, ParentCanvas);
                Assert.AreEqual(false, SupportsSubmit);
                Assert.AreEqual(null, SubmitIcon);
            }

            [UnityTest]
            public override IEnumerator Select_Suitable_Input_Field_Then_Null()
            {

                EventSystem.current.SetSelectedGameObject(TmpInputField.gameObject);
                yield return null;
                Assert.AreEqual(true, SelectionFlag);
                Assert.AreEqual(((RectTransform)TmpInputField.transform).rect, SelectedRect);
                Assert.AreEqual(Canvas, ParentCanvas);
                Assert.AreEqual(false, SupportsSubmit);
                Assert.AreEqual(null, SubmitIcon);

                EventSystem.current.SetSelectedGameObject(UnityInputField.gameObject);
                yield return null;
                Assert.AreEqual(false, SelectionFlag);
                Assert.AreEqual(null, SelectedRect);
                Assert.AreEqual(null, ParentCanvas);
                Assert.AreEqual(false, SupportsSubmit);
                Assert.AreEqual(null, SubmitIcon);
            }

            [UnityTest]
            public override IEnumerator Select_Null_Field_Then_Suitable_Input()
            {
                

                EventSystem.current.SetSelectedGameObject(UnityInputField.gameObject);
                yield return null;
                Assert.AreEqual(false, SelectionFlag);
                Assert.AreEqual(null, SelectedRect);
                Assert.AreEqual(null, ParentCanvas);
                Assert.AreEqual(false, SupportsSubmit);
                Assert.AreEqual(null, SubmitIcon);

                EventSystem.current.SetSelectedGameObject(TmpInputField.gameObject);
                yield return null;
                Assert.AreEqual(true, SelectionFlag);
                Assert.AreEqual(((RectTransform)TmpInputField.transform).rect, SelectedRect);
                Assert.AreEqual(Canvas, ParentCanvas);
                Assert.AreEqual(false, SupportsSubmit);
                Assert.AreEqual(null, SubmitIcon);
            }

            public override IEnumerator Try_Submit_To_Suitable_Field()
            {
                yield return null;
            }

            public override IEnumerator Try_Submit_To_Null()
            {
                yield return null;
            }

            public override IEnumerator Try_Submit_To_Not_Suitable_Field()
            {
                yield return null;
            }

            [UnityTest]
            public override IEnumerator Try_Type_To_Suitable_Field()
            {
                EventSystem.current.SetSelectedGameObject(TmpInputField.gameObject);
                yield return null;
                Target.Type("Test");
                Assert.AreEqual("Test", TmpInputField.text);

                Target.Type("!");
                Assert.AreEqual("Test!", TmpInputField.text);
            }

            public override IEnumerator Try_Type_To_Null()
            {
                yield return null;
            }

            public override IEnumerator Try_Type_To_Not_Suitable_Field()
            {
                yield return null;
            }

            public override IEnumerator Delete_Submit_To_Suitable_Field()
            {
                yield return null;
            }

            public override IEnumerator Delete_Submit_To_Null()
            {
                yield return null;
            }

            public override IEnumerator Delete_Submit_To_Not_Suitable_Field()
            {
                yield return null;
            }
        }
    }
}
