using System.Collections.Generic;
using UnityEngine;
using VirtualKeyboard.Data.Button;

namespace VirtualKeyboard.ScriptableObjects.Blueprints.KeyboardRow
{
    /// <summary>
    ///     Blueprint of a keyboard row
    /// </summary>
    [CreateAssetMenu(fileName = "Language - Row 0", menuName = "Virtual Keyboard/Blueprints/Row Blueprint")]
    public class RowBlueprint : ScriptableObject, IRowBlueprint
    {
        /// <summary>
        ///     Amount of modes supported by the row
        /// </summary>
        [SerializeField] private int _amountOfModes = 1;

        /// <summary>
        ///     Buttons of the row
        /// </summary>
        [SerializeField] private List<ButtonData> _buttons;

        /// <summary>
        ///     Amount of modes supported by the row
        /// </summary>
        public int AmountOfModes => _amountOfModes;

        /// <summary>
        ///     Buttons of the row
        /// </summary>
        public IEnumerable<IButtonData> Buttons => _buttons;

        #region Decoration

        private void OnValidate()
        {
            Fix();
            UpdateModesSize();
        }

        /// <summary>
        ///     Updates modes size of the buttons
        /// </summary>
        private void UpdateModesSize()
        {
            foreach (var button in Buttons) button.SetModesAmount(AmountOfModes);
        }

        /// <summary>
        ///     Fixes the row data
        /// </summary>
        private void Fix()
        {
            _amountOfModes = Mathf.Max(1, AmountOfModes);

            foreach (var button in _buttons) button.Fix();
        }

        #endregion
    }
}