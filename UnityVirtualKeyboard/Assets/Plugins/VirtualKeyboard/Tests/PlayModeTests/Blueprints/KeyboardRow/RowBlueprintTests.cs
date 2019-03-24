using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using VirtualKeyboard.Blueprints.KeyboardRow;
using VirtualKeyboard.Data.Button;

namespace VirtualKeyboard.Tests.PlayModeTests.Blueprints.KeyboardRow
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

            Assert.AreEqual(2, firstButton.ButtonPageCharacters.Count());
            Assert.AreEqual(2, secondButton.ButtonPageCharacters.Count());
            Assert.AreEqual("One", firstButton.ButtonPageCharacters.First());
            Assert.AreEqual("", firstButton.ButtonPageCharacters.Last());

            Assert.AreEqual("1", secondButton.ButtonPageCharacters.First());
            Assert.AreEqual("2", secondButton.ButtonPageCharacters.Last());
        }
    }
}
