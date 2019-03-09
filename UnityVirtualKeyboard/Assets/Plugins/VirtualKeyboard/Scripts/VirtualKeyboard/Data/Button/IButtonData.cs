using System.Collections.Generic;

namespace VirtualKeyboard.Data.Button
{
    /// <summary>
    ///     Interface for the ButtonData
    /// </summary>
    public interface IButtonData 
    {
        /// <summary>
        ///     IEnumerable of the button characters. Each member of the list represents characters that will be typed when the
        ///     button is
        ///     pressed in a certain mode (e.g. SHIFT or non-SHIFT mode)
        /// </summary>
        IEnumerable<string> ButtonModeCharacters { get; }

        /// <summary>
        ///     Horizontal size of the button in size units. The default size of the button is 1
        /// </summary>
        int ButtonHorizontalSize { get; }

        /// <summary>
        ///     Sets amount of the modes that the button should support
        /// </summary>
        /// <param name="modesAmount">New amount of supported modes</param>
        void SetModesAmount(int modesAmount);
    }
}