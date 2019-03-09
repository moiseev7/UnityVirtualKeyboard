using NUnit.Framework;
using UnityEngine;

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
            Object.Destroy(_target);
        }

        // A Test behaves as an ordinary method
        [Test]
        public void Fix_Sends_Fix_To_The_Buttons()
        {
            
        }

        
    }
}
