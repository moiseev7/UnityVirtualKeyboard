using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using VirtualKeyboard.Data.Button;

namespace VirtualKeyboard.Data.ButtonDataTests
{
    /// <summary>
    /// Tests for <see cref="ButtonData"/>
    /// </summary>
    public class ButtonDataTests
    {
        /// <summary>
        /// Target of the tests
        /// </summary>
        private ButtonData _target;

        /// <summary>
        /// Tests for the Fix() function
        /// </summary>
        public class FixTests : ButtonDataTests
        {
            [Test]
            public void Fix_Sets_Size_To_1_If_Size_Is_Less_Than_1()
            {
                _target = new ButtonData(new List<string>(), 0);
                Assert.AreEqual(0, _target.ButtonHorizontalSize);
                _target.Fix();
                Assert.AreEqual(1, _target.ButtonHorizontalSize);
            }

            [Test]
            public void Fix_Sets_Size_To_1_If_Size_Is_Greater_Or_Equal_To_1()
            {
                _target = new ButtonData(new List<string>(), 2);
                Assert.AreEqual(2, _target.ButtonHorizontalSize);
                _target.Fix();
                Assert.AreEqual(2, _target.ButtonHorizontalSize);
            }
        }

        public class SetModesAmountTests :  ButtonDataTests
        {
            [Test]
            public void _2_Doesnt_Alter_List_If_The_Size_Is_2()
            {
                _target = new ButtonData(new List<string> {"first", "second"}, 1);
                _target.SetModesAmount(2);
                Assert.AreEqual(_target.ButtonModeCharacters.Count(), 2);
                Assert.AreEqual("first", _target.ButtonModeCharacters.First());
                Assert.AreEqual("second", _target.ButtonModeCharacters.Last());
            }

            [Test]
            public void _2_Reduces_Size_Of_List_If_The_Size_Is_3()
            {
                _target = new ButtonData(new List<string> { "first", "second", "third" }, 1);
                _target.SetModesAmount(2);
                Assert.AreEqual(_target.ButtonModeCharacters.Count(), 2);
                Assert.AreEqual("first", _target.ButtonModeCharacters.First());
                Assert.AreEqual("second", _target.ButtonModeCharacters.Last());
            }

            [Test]
            public void _2_Increases_Size_Of_List_If_The_Size_Is_1()
            {
                _target = new ButtonData(new List<string> { "first"}, 1);
                _target.SetModesAmount(2);
                Assert.AreEqual(_target.ButtonModeCharacters.Count(), 2);
                Assert.AreEqual("first", _target.ButtonModeCharacters.First());
                Assert.AreEqual("", _target.ButtonModeCharacters.Last());
            }
        }
    }
}

