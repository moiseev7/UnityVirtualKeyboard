using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using VirtualKeyboard.Data.Button;

namespace VirtualKeyboard.ScriptableObjects.Blueprints.KeyboardRow
{
    /// <summary>
    /// Tests for <see cref="RowBlueprint"/>
    /// </summary>
    public class RowBlueprintTests
    {
        /// <summary>
        /// Target of the tests
        /// </summary>
        private RowBlueprint _target;

        [SetUp]
        public void BeforeEveryTest()
        {
            _target = ScriptableObject.CreateInstance<RowBlueprint>();
        }

        [TearDown]
        public void AfterEveryScript()
        {
            Object.DestroyImmediate(_target);
        }
        
        [Test]
        public void Fix_Fixes_The_Buttons_Size()
        {
            var button1 = new ButtonData(new List<string>{"One"},0);
            _target.Initialize(1, new List<ButtonData>{button1});
            _target.Fix();
            Assert.AreEqual(1, _target.Buttons.First().ButtonHorizontalSize);
        }
        
        [Test]
        public void Fix_Fixes_The_Buttons_Modes()
        {
            var button1 = new ButtonData(new List<string> { "One"}, 0);
            var button2 = new ButtonData(new List<string> { "1", "2", "3" }, 0);
            _target.Initialize(2, new List<ButtonData> { button1, button2 });
            _target.Fix();

            var firstButton = _target.Buttons.First();
            var secondButton = _target.Buttons.Last();

            Assert.AreEqual(2, firstButton.ButtonModeCharacters.Count());
            Assert.AreEqual(2, secondButton.ButtonModeCharacters.Count());
            Assert.AreEqual("One", firstButton.ButtonModeCharacters.First());
            Assert.AreEqual("", firstButton.ButtonModeCharacters.Last());

            Assert.AreEqual("1", secondButton.ButtonModeCharacters.First());
            Assert.AreEqual("2", secondButton.ButtonModeCharacters.Last());
        }
    }
}
