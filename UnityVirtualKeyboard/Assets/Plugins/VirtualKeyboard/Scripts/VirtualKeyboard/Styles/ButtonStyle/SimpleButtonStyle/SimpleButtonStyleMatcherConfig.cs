using System.Collections.Generic;
using UnityEngine;

namespace VirtualKeyboard.Scripts.VirtualKeyboard.Styles.ButtonStyle.SimpleButtonStyle
{
    /// <summary>
    /// Config for the simple button style matcher
    /// </summary>
    [CreateAssetMenu(fileName = "SimpleButtonStyleMatcherConfig", menuName = "Virtual Keyboard/Styles/Button Styles/Simple/Simple Button Style Matcher Config")]
    public class SimpleButtonStyleMatcherConfig : ScriptableObject, ISimpleButtonStyleMatcherConfig
    {
        /// <summary>
        /// The default style container
        /// </summary>
        [SerializeField]
        [Tooltip("The default style container")]
        private SimpleButtonStyleContainer _defaultStyle;

        /// <summary>
        /// Lis of the style pairs
        /// </summary>
        [SerializeField]
        [Tooltip("Lis of the style pairs")]
        private List<SimpleButtonStylePair> _buttonStylePairs;
      
        /// <summary>
        /// The default style container
        /// </summary>
        public SimpleButtonStyleContainer DefaultStyle => _defaultStyle;

        /// <summary>
        /// Lis of the style pairs
        /// </summary>
        public List<SimpleButtonStylePair> ButtonStylePairs => _buttonStylePairs;
    }
}
