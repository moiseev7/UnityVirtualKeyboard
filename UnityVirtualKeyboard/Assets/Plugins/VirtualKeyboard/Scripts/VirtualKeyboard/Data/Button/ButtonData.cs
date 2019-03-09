using System;
using System.Collections.Generic;
using System.Linq;
using Helpers.Interfaces;
using UnityEngine;

namespace VirtualKeyboard.Data.Button
{
    /// <summary>
    ///     Stores data related to a keyboard button
    /// </summary>
    [Serializable]
    public class ButtonData : IButtonData, IFixable
    {
        /// <summary>
        ///     List of the button characters. Each member of the list represents characters that will be typed when the button is
        ///     pressed in a certain mode (e.g. SHIFT or non-SHIFT mode)
        /// </summary>
        [SerializeField] private List<string> _buttonModeCharacters;

        /// <summary>
        ///     Horizontal size of the button in size units. The default size of the button is 1
        /// </summary>
        [SerializeField] private int _buttonHorizontalSize;

        public ButtonData(List<string> buttonModeCharacters, int buttonHorizontalSize)
        {
            _buttonModeCharacters = buttonModeCharacters;
            _buttonHorizontalSize = buttonHorizontalSize;
        }

        /// <summary>
        ///     IEnumerable of the button characters. Each member of the list represents characters that will be typed when the
        ///     button is
        ///     pressed in a certain mode (e.g. SHIFT or non-SHIFT mode)
        /// </summary>
        public IEnumerable<string> ButtonModeCharacters => _buttonModeCharacters;

        /// <summary>
        ///     Horizontal size of the button in size units. The default size of the button is 1
        /// </summary>
        public int ButtonHorizontalSize => _buttonHorizontalSize;

        #region Decoration

        /// <summary>
        ///     Sets amount of the modes that the button should support
        /// </summary>
        /// <param name="modesAmount">New amount of supported modes</param>
        public void SetModesAmount(int modesAmount)
        {
            var delta = modesAmount - _buttonModeCharacters.Count;

            if (delta < 0) // Reduce amount of the buttons modes
                _buttonModeCharacters = _buttonModeCharacters.Take(modesAmount).ToList();
            else if (delta > 0) // Increase amount of the buttons modes
                for (var i = 0; i < delta; i++)
                    _buttonModeCharacters.Add("");
        }

        /// <summary>
        ///     Fixes the button data
        /// </summary>
        public void Fix()
        {
            _buttonHorizontalSize = Mathf.Max(1, _buttonHorizontalSize);
        }

        #endregion
    }
}