using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace VirtualKeyboard.Scripts.VirtualKeyboard.Styles.ButtonStyle.SimpleButtonStyle
{
    /// <summary>
    /// Contains references to the objects required by the <see cref="SimpleButtonStyleController"/>
    /// </summary>
    [System.Serializable]
    public class SimpleButtonStyleObjectReferencesContainer : ISimpleButtonStyleObjectReferencesContainer
    {
        /// <summary>
        /// Reference to the background
        /// </summary>
        [SerializeField]
        [Tooltip("Reference to the background")]
        private List<MaskableGraphic> _backgrounds;

        /// <summary>
        /// Reference to the symbol
        /// </summary>
        [SerializeField]
        [Tooltip("Reference to the symbol")]
        private List<MaskableGraphic> _symbols;

        /// <summary>
        /// Reference to the background
        /// </summary>
        public IEnumerable<MaskableGraphic> Backgrounds => _backgrounds;

        /// <summary>
        /// Reference to the symbol
        /// </summary>
        public IEnumerable<MaskableGraphic> Symbols => _symbols;
    }
}