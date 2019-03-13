using UnityEngine;

namespace VirtualKeyboard.Styles.ButtonStyle.SimpleButtonStyle
{

    public interface ISimpleButtonStyleElement
    {
        /// <summary>
        ///     Background color of the button
        /// </summary>
        Color BackgroundColor { get; }

        /// <summary>
        ///     Color of en element (e.g. text or icon)
        /// </summary>
        Color SymbolColor { get; }
    }
}