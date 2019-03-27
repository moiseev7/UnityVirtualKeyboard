using System.Collections.Generic;
using Helpers.Interfaces;
using UnityEngine;
using VirtualKeyboard.Data.Button;

namespace VirtualKeyboard.Blueprints.KeyboardRow
{
    /// <summary>
    ///     Blueprint of a keyboard row
    /// </summary>
    [CreateAssetMenu(fileName = "Language - Row 0", menuName = "Virtual Keyboard/Blueprints/Row Blueprint")]
    public class RowBlueprint : ScriptableObject, IRowBlueprint, IFixable
    {
        /// <summary>
        ///     Amount of pages supported by the row
        /// </summary>
        [SerializeField] private int _amountOfPages = 1;

        /// <summary>
        ///     Buttons of the row
        /// </summary>
        [SerializeField] private List<ButtonData> _buttons;

        public void Initialize(int amountOfModes, List<ButtonData> buttons)
        {
            _amountOfPages = amountOfModes;
            _buttons = buttons;
        }

        /// <summary>
        ///     Amount of pages supported by the row
        /// </summary>
        public int AmountOfPages => _amountOfPages;

        /// <summary>
        ///     Buttons of the row
        /// </summary>
        public IEnumerable<IButtonData> Buttons => _buttons;

        #region Decoration

        private void OnValidate()
        {
            Fix();
        }

        /// <summary>
        ///     Updates modes size of the buttons
        /// </summary>
        private void UpdateModesSize()
        {
            foreach (var button in Buttons) button.SetPageAmount(AmountOfPages);
        }

        /// <summary>
        ///     Fixes the row data
        /// </summary>
        public void Fix()
        {
            _amountOfPages = Mathf.Max(1, AmountOfPages);

            foreach (var button in Buttons) (button as ButtonData)?.Fix();

            UpdateModesSize();
        }

        #endregion
    }
}