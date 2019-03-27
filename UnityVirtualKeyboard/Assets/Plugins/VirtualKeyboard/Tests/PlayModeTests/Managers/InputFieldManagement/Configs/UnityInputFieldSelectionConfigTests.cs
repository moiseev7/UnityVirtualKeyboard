using System;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VirtualKeyboard.Managers.InputFieldManagement.Configs;
using Object = UnityEngine.Object;

namespace VirtualKeyboard.Tests.PlayModeTests.Managers.InputFieldManagement.Configs
{
    public class UnityInputFieldSelectionConfigTests
    {
        private UnityInputFieldSelectionConfig _config;

        private InputField _targetField;

        private TMP_InputField _wrongField;

         [SetUp]
        public void BeforeEveryTest()
        {
            _config = ScriptableObject.CreateInstance<UnityInputFieldSelectionConfig>();
            _targetField = new GameObject().AddComponent<InputField>();
            _wrongField = new GameObject().AddComponent<TMP_InputField>();
        }

        [TearDown]
        public void AfterEveryTest()
        {
            Object.DestroyImmediate(_config);
            Object.DestroyImmediate(_targetField);
            Object.DestroyImmediate(_wrongField);
        }
        
        [Test]
        public void CheckIfSelected_Returns_True_If_A_Correct_Field_Is_Selected()
        {
            Assert.AreEqual(true, _config.CheckIfSelected(_targetField));
        }

        [Test]
        public void CheckIfSelected_Returns_False_If_Null_Is_Selected()
        {
            Assert.AreEqual(false, _config.CheckIfSelected(null));
        }

        [Test]
        public void CheckIfSelected_Returns_False_If_A_Wrong_Field_Is_Selected()
        {
            Assert.AreEqual(false, _config.CheckIfSelected(_wrongField));
        }

        [Test]
        public void CheckIfSupportsSubmit_Always_Returns_False()
        {
            Assert.AreEqual(false, _config.CheckIfSupportsSubmit(_targetField));
            Assert.AreEqual(false, _config.CheckIfSupportsSubmit(_wrongField));
            Assert.AreEqual(false, _config.CheckIfSupportsSubmit(null));
        }

        [Test]
        public void GetSubmitTexture_Always_Returns_Null()
        {
            Assert.AreEqual(null, _config.GetSubmitTexture(_targetField));
            Assert.AreEqual(null, _config.GetSubmitTexture(_wrongField));
            Assert.AreEqual(null, _config.GetSubmitTexture(null));
        }

        [Test]
        public void Typing_Works_For_A_Correct_Field()
        {
            Assert.AreEqual("", _targetField.text);

            _config.TypingAction(_targetField, "test");

            Assert.AreEqual("test", _targetField.text);

            _config.TypingAction(_targetField, "-one");

            Assert.AreEqual("test-one", _targetField.text);
        }

        [Test]
        public void TypingAction_Throws_Exception_For_Null()
        {
            Assert.Throws<ArgumentNullException>(()=>_config.TypingAction(null, "Test"));
        }

        [Test]
        public void TypingAction_Throws_Exception_For_A_Wrong_Field()
        {
            Assert.Throws<ArgumentException>(() => _config.TypingAction(_wrongField, "Test"));
        }

        [Test]
        public void TypingAction_Throws_Exception_For_NullOrEmpty_Text()
        {
            Assert.Throws<ArgumentException>(() => _config.TypingAction(_targetField, null));
            Assert.Throws<ArgumentException>(() => _config.TypingAction(_targetField, ""));
        }

        [Test]
        public void DeleteLastSymbolAction_Works_For_A_Correct_Field()
        {
            _targetField.text = "test-one!";

            _config.DeleteLastSymbolAction(_targetField);

            Assert.AreEqual("test-one", _targetField.text);
        }

        [Test]
        public void DeleteLastSymbolAction_Throws_Exception_For_Null()
        {
            Assert.Throws<ArgumentNullException>(()=>_config.DeleteLastSymbolAction(null));
        }

        [Test]
        public void DeleteLastSymbolAction_Doesnt_Throw_Exception_For_An_Empty_Correct_Field()
        {
            _targetField.text = "";
            Assert.DoesNotThrow(() => _config.DeleteLastSymbolAction(_targetField));
        }

        [Test]
        public void DeleteLastSymbolAction_Throws_Exception_For_A_Wrong_Field()
        {
            Assert.Throws<ArgumentException>(() => _config.DeleteLastSymbolAction(_wrongField));
        }

        [Test]
        public void SubmitAction_Throws_Exception_For_Null()
        {
            Assert.Throws<ArgumentNullException>(() => _config.SubmitAction(null));
        }

        [Test]
        public void SubmitAction_Throws_Exception_For_A_Wrong_Field()
        {
            Assert.Throws<ArgumentException>(() => _config.SubmitAction(_wrongField));
        }
    }
}
