using UnityEngine;

namespace VirtualKeyboard.Scripts.VirtualKeyboard.Styles.ButtonStyle.SimpleButtonStyle
{
    /// <summary>
    ///     Stores settings element for a simple button
    /// </summary>
    [System.Serializable]
    public struct SimpleButtonStyleElement : ISimpleButtonStyleElement
    {
        /// <summary>
        ///     Background color of the button
        /// </summary>
        [SerializeField] private Color _backgroundColor;

        /// <summary>
        ///     Color of en element (e.g. text or icon)
        /// </summary>
        [SerializeField] private Color _symbolColor;

        public SimpleButtonStyleElement(Color backgroundColor, Color symbolColor)
        {
            _backgroundColor = backgroundColor;
            _symbolColor = symbolColor;
        }

        /// <summary>
        ///     Background color of the button
        /// </summary>
        public Color BackgroundColor => _backgroundColor;

        /// <summary>
        ///     Color of en element (e.g. text or icon)
        /// </summary>
        public Color SymbolColor => _symbolColor;
    }
}