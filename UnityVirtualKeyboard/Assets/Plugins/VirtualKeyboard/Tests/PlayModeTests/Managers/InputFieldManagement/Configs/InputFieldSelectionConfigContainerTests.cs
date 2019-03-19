using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using VirtualKeyboard.Managers.InputFieldManagement.Configs;

namespace VirtualKeyboard.Tests.PlayModeTests.Managers.InputFieldManagement.Configs
{
    /// <summary>
    /// Tests for InputFieldSelectionConfigContainer
    /// </summary>
    public abstract class InputFieldSelectionConfigContainerTests
    {
        protected TMP_InputField TmpInputField;
        public InputField UnityInputField;
        public InputFieldSelectionConfigContainer Target;
        protected UnityInputFieldSelectionConfig UnityInputFieldSelectionConfig;
        protected TMP_InputFieldSelectionConfig TmpInputFieldSelectionConfig;

        [SetUp]
        public void BeforeEveryTest()
        {
            TmpInputField = new GameObject().AddComponent<TMP_InputField>();
            var textComponent = new GameObject().AddComponent<TextMeshProUGUI>();
            textComponent.transform.SetParent(TmpInputField.transform);
            TmpInputField.textComponent = textComponent;
            TmpInputField.textViewport = TmpInputField.gameObject.AddComponent<RectTransform>();

            UnityInputField = new GameObject().AddComponent<InputField>();
            Target = ScriptableObject.CreateInstance<InputFieldSelectionConfigContainer>();

            UnityInputFieldSelectionConfig = ScriptableObject.CreateInstance<UnityInputFieldSelectionConfig>();
            TmpInputFieldSelectionConfig = ScriptableObject.CreateInstance<TMP_InputFieldSelectionConfig>();

            InitializeTarget();
        }

        protected abstract void InitializeTarget();

        [TearDown]
        public void AfterEveryTest()
        {
            Object.Destroy(TmpInputField.gameObject);
            Object.Destroy(UnityInputField.gameObject);
            Object.Destroy(Target);
            Object.Destroy(UnityInputFieldSelectionConfig);
            Object.Destroy(TmpInputFieldSelectionConfig);
        }

        [Test]
        public abstract void Select_Null();

        [Test]
        public abstract void Select_UnityInputField();

        [Test]
        public abstract void Select_TMPInputField();

        [Test]
        public abstract void Select_Suitable_Field_Then_Null();

        [Test]
        public abstract void Select_Null_Then_Suitable_Field();

        public class UnityInputFieldOnly : InputFieldSelectionConfigContainerTests
        {
            protected override void InitializeTarget()
            {
                Target.Initialize(new List<AbstractInputFieldSelectionConfig> {UnityInputFieldSelectionConfig});
            }

            [Test]
            public override void Select_Null()
            {
                Assert.AreEqual(null, Target.GetConfig(null));
            }

            [Test]
            public override void Select_UnityInputField()
            {
                Assert.AreEqual(UnityInputFieldSelectionConfig, Target.GetConfig(UnityInputField));
            }

            [Test]
            public override void Select_TMPInputField()
            {
                Assert.AreEqual(null, Target.GetConfig(TmpInputField));
            }

            [Test]
            public override void Select_Suitable_Field_Then_Null()
            {
                Assert.AreEqual(UnityInputFieldSelectionConfig, Target.GetConfig(UnityInputField));
                Assert.AreEqual(null, Target.GetConfig(null));
            }

            [Test]
            public override void Select_Null_Then_Suitable_Field()
            {
                Assert.AreEqual(null, Target.GetConfig(null));
                Assert.AreEqual(UnityInputFieldSelectionConfig, Target.GetConfig(UnityInputField));
            }
        }

        public class TMPInputFieldOnly : InputFieldSelectionConfigContainerTests
        {
            protected override void InitializeTarget()
            {
                Target.Initialize(new List<AbstractInputFieldSelectionConfig> {TmpInputFieldSelectionConfig});
            }

            [Test]
            public override void Select_Null()
            {
                Assert.AreEqual(null, Target.GetConfig(null));
            }

            [Test]
            public override void Select_UnityInputField()
            {
                Assert.AreEqual(null, Target.GetConfig(UnityInputField));
            }

            [Test]
            public override void Select_TMPInputField()
            {
                Assert.AreEqual(TmpInputFieldSelectionConfig, Target.GetConfig(TmpInputField));
            }

            [Test]
            public override void Select_Suitable_Field_Then_Null()
            {
                Assert.AreEqual(TmpInputFieldSelectionConfig, Target.GetConfig(TmpInputField));
                Assert.AreEqual(null, Target.GetConfig(null));
            }

            [Test]
            public override void Select_Null_Then_Suitable_Field()
            {
                Assert.AreEqual(null, Target.GetConfig(null));
                Assert.AreEqual(TmpInputFieldSelectionConfig, Target.GetConfig(TmpInputField));
            }
        }

        public class TMPAndUnityInputFields : InputFieldSelectionConfigContainerTests
        {
            protected override void InitializeTarget()
            {
                Target.Initialize(new List<AbstractInputFieldSelectionConfig> { TmpInputFieldSelectionConfig, UnityInputFieldSelectionConfig });
            }

            [Test]
            public override void Select_Null()
            {
                Assert.AreEqual(null, Target.GetConfig(null));
            }

            [Test]
            public override void Select_UnityInputField()
            {
                Assert.AreEqual(UnityInputFieldSelectionConfig, Target.GetConfig(UnityInputField));
            }

            [Test]
            public override void Select_TMPInputField()
            {
                Assert.AreEqual(TmpInputFieldSelectionConfig, Target.GetConfig(TmpInputField));
            }

            [Test]
            public override void Select_Suitable_Field_Then_Null()
            {
                Assert.AreEqual(TmpInputFieldSelectionConfig, Target.GetConfig(TmpInputField));
                Assert.AreEqual(null, Target.GetConfig(null));
            }

            [Test]
            public override void Select_Null_Then_Suitable_Field()
            {
                Assert.AreEqual(null, Target.GetConfig(null));
                Assert.AreEqual(UnityInputFieldSelectionConfig, Target.GetConfig(UnityInputField));
            }
        }
    }
}
