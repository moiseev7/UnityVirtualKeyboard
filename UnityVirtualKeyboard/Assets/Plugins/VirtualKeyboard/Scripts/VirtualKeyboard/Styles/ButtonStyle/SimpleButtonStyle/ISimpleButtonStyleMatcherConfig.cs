using System.Collections.Generic;

namespace VirtualKeyboard.Scripts.VirtualKeyboard.Styles.ButtonStyle.SimpleButtonStyle
{
    /// <summary>
    /// Interface for 
    /// </summary>
    public interface ISimpleButtonStyleMatcherConfig
    {
        /// <summary>
        /// The default style container
        /// </summary>
        SimpleButtonStyleContainer DefaultStyle { get; }

        /// <summary>
        /// Lis of the style pairs
        /// </summary>
        List<SimpleButtonStylePair> ButtonStylePairs { get; }
    }
}