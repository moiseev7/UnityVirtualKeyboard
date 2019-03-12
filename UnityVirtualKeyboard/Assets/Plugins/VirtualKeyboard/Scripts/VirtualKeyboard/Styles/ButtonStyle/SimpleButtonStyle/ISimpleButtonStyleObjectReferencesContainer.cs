using System.Collections.Generic;
using UnityEngine.UI;

namespace VirtualKeyboard.Scripts.VirtualKeyboard.Styles.ButtonStyle.SimpleButtonStyle
{
    /// <summary>
    /// Interface for SimpleButtonStyleObjectReferencesContainer
    /// </summary>
    public interface ISimpleButtonStyleObjectReferencesContainer
    {
        /// <summary>
        /// Reference to the background
        /// </summary>
        IEnumerable<MaskableGraphic> Backgrounds { get; }

        /// <summary>
        /// Reference to the symbol
        /// </summary>
        IEnumerable<MaskableGraphic> Symbols { get; }
    }
}
