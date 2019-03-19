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

        [SetUp]
        public void BeforeEveryTest()
        {
            Canvas = new GameObject().AddComponent<Canvas>();
            

            TmpInputField = new GameObject().AddComponent<TMP_InputField>();
            var textComponent = new GameObject().AddComponent<TextMeshProUGUI>();
            textComponent.transform.SetParent(TmpInputField.transform);
            TmpInputField.textComponent = textComponent;
            TmpInputField.transform.SetParent(Canvas.transform);


            UnityInputField = new GameObject().AddComponent<InputField>();
            UnityInputField.transform.SetParent(Canvas.transform);

            UnityInputFieldSelectionConfig = ScriptableObject.CreateInstance<UnityInputFieldSelectionConfig>();
            TmpInputFieldSelectionConfig = ScriptableObject.CreateInstance<TMP_InputFieldSelectionConfig>();

            ConfigContainer = ScriptableObject.CreateInstance<InputFieldSelectionConfigContainer>();
            InitializeConfigsContainer();

            EventSystem = new GameObject().AddComponent<EventSystem>();
            EventSystem.current = EventSystem;

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
    }
        
        [TearDown]
        public void AfterEveryTest()
        {
            Object.Destroy(Canvas.gameObject);
            Object.Destroy(ConfigContainer);
            Object.Destroy(UnityInputFieldSelectionConfig);
            Object.Destroy(TmpInputFieldSelectionConfig);
            Object.Destroy(EventSystem.gameObject);
        }


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
                Target.IsFieldSelectedAsObservable.Subscribe(flag => SelectionFlag = flag);

                EventSystem.current.SetSelectedGameObject(UnityInputField.gameObject);
                yield return null;
                Assert.AreEqual(false, SelectionFlag);
                Assert.AreEqual(null, SelectedRect);
                Assert.AreEqual(null, ParentCanvas);
                Assert.AreEqual(false, SupportsSubmit);
                Assert.AreEqual(null, SubmitIcon);
            }

            public override IEnumerator Select_TMP_Input_Field()
            {
                yield return null;
            }

            public override IEnumerator Select_Suitable_Input_Field_Then_Null()
            {
                yield return null;
            }

            public override IEnumerator Select_Null_Field_Then_Suitable_Input()
            {
                yield return null;
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

            public override IEnumerator Try_Type_To_Suitable_Field()
            {
                yield return null;
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
