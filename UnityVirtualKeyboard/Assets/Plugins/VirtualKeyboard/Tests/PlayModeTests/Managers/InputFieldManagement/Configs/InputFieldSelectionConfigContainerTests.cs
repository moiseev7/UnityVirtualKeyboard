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
        protected TMP_InputField _tmpInputField;
        protected InputField _unityInputField;
        protected InputFieldSelectionConfigContainer _target;
        protected UnityInputFieldSelectionConfig _unityInputFieldSelectionConfig;
        protected TMP_InputFieldSelectionConfig _tmpInputFieldSelectionConfig;

        [SetUp]
        public void BeforeEveryTest()
        {
            _tmpInputField = new GameObject().AddComponent<TMP_InputField>();
            var textComponent = new GameObject().AddComponent<TextMeshProUGUI>();
            textComponent.transform.SetParent(_tmpInputField.transform);
            _tmpInputField.textComponent = textComponent;
            _tmpInputField.textViewport = _tmpInputField.gameObject.AddComponent<RectTransform>();

            _unityInputField = new GameObject().AddComponent<InputField>();
            _target = ScriptableObject.CreateInstance<InputFieldSelectionConfigContainer>();

            _unityInputFieldSelectionConfig = ScriptableObject.CreateInstance<UnityInputFieldSelectionConfig>();
            _tmpInputFieldSelectionConfig = ScriptableObject.CreateInstance<TMP_InputFieldSelectionConfig>();

            InitializeTarget();
        }

        protected abstract void InitializeTarget();

        [TearDown]
        public void AfterEveryTest()
        {
            Object.Destroy(_tmpInputField.gameObject);
            Object.Destroy(_unityInputField.gameObject);
            Object.Destroy(_target);
            Object.Destroy(_unityInputFieldSelectionConfig);
            Object.Destroy(_tmpInputFieldSelectionConfig);
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
                _target.Initialize(new List<AbstractInputFieldSelectionConfig> {_unityInputFieldSelectionConfig});
            }

            [Test]
            public override void Select_Null()
            {
                Assert.AreEqual(null, _target.GetConfig(null));
            }

            [Test]
            public override void Select_UnityInputField()
            {
                Assert.AreEqual(_unityInputFieldSelectionConfig, _target.GetConfig(_unityInputField));
            }

            [Test]
            public override void Select_TMPInputField()
            {
                Assert.AreEqual(null, _target.GetConfig(_tmpInputField));
            }

            [Test]
            public override void Select_Suitable_Field_Then_Null()
            {
                Assert.AreEqual(_unityInputFieldSelectionConfig, _target.GetConfig(_unityInputField));
                Assert.AreEqual(null, _target.GetConfig(null));
            }

            [Test]
            public override void Select_Null_Then_Suitable_Field()
            {
                Assert.AreEqual(null, _target.GetConfig(null));
                Assert.AreEqual(_unityInputFieldSelectionConfig, _target.GetConfig(_unityInputField));
            }
        }

        public class TMPInputFieldOnly : InputFieldSelectionConfigContainerTests
        {
            protected override void InitializeTarget()
            {
                _target.Initialize(new List<AbstractInputFieldSelectionConfig> {_tmpInputFieldSelectionConfig});
            }

            [Test]
            public override void Select_Null()
            {
                Assert.AreEqual(null, _target.GetConfig(null));
            }

            [Test]
            public override void Select_UnityInputField()
            {
                Assert.AreEqual(null, _target.GetConfig(_unityInputField));
            }

            [Test]
            public override void Select_TMPInputField()
            {
                Assert.AreEqual(_tmpInputFieldSelectionConfig, _target.GetConfig(_tmpInputField));
            }

            [Test]
            public override void Select_Suitable_Field_Then_Null()
            {
                Assert.AreEqual(_tmpInputFieldSelectionConfig, _target.GetConfig(_tmpInputField));
                Assert.AreEqual(null, _target.GetConfig(null));
            }

            [Test]
            public override void Select_Null_Then_Suitable_Field()
            {
                Assert.AreEqual(null, _target.GetConfig(null));
                Assert.AreEqual(_tmpInputFieldSelectionConfig, _target.GetConfig(_tmpInputField));
            }
        }

        public class TMPAndUnityInputFields : InputFieldSelectionConfigContainerTests
        {
            protected override void InitializeTarget()
            {
                _target.Initialize(new List<AbstractInputFieldSelectionConfig> { _tmpInputFieldSelectionConfig, _unityInputFieldSelectionConfig });
            }

            [Test]
            public override void Select_Null()
            {
                Assert.AreEqual(null, _target.GetConfig(null));
            }

            [Test]
            public override void Select_UnityInputField()
            {
                Assert.AreEqual(_unityInputFieldSelectionConfig, _target.GetConfig(_unityInputField));
            }

            [Test]
            public override void Select_TMPInputField()
            {
                Assert.AreEqual(_tmpInputFieldSelectionConfig, _target.GetConfig(_tmpInputField));
            }

            [Test]
            public override void Select_Suitable_Field_Then_Null()
            {
                Assert.AreEqual(_tmpInputFieldSelectionConfig, _target.GetConfig(_tmpInputField));
                Assert.AreEqual(null, _target.GetConfig(null));
            }

            [Test]
            public override void Select_Null_Then_Suitable_Field()
            {
                Assert.AreEqual(null, _target.GetConfig(null));
                Assert.AreEqual(_unityInputFieldSelectionConfig, _target.GetConfig(_unityInputField));
            }
        }
    }
}
