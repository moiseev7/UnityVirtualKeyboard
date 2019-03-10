using UnityEngine;

namespace VirtualKeyboard.Scripts.VirtualKeyboard.Styles.ButtonStyle.SimpleButtonStyle
{
    /// <summary>
    /// A generic container of a certain button style 
    /// </summary>
    [CreateAssetMenu(fileName = "SimpleButtonStyleContainer", menuName = "Virtual Keyboard/Configs/Button Styles/Simple/Style Container")]
    public class SimpleButtonStyleContainer : ScriptableObject, IButtonStyleContainer<ISimpleButtonStyleElement>
    {
        /// <summary>
        /// Settings that will be applied when the button is in the normal state
        /// </summary>
        [SerializeField] private SimpleButtonStyleElement _normalSettings = new SimpleButtonStyleElement(Color.white, Color.black); 

        /// <summary>
        /// Settings that will be applied when the button is in the highlighted state
        /// </summary>
        [SerializeField] private SimpleButtonStyleElement _highlightedSettings = new SimpleButtonStyleElement(Color.white, Color.black);

        /// <summary>
        /// Settings that will be applied when the button is in the pressed state
        /// </summary>
        [SerializeField] private SimpleButtonStyleElement _pressedSettings = new SimpleButtonStyleElement(Color.white, Color.black);

        /// <summary>
        /// Settings that will be applied when the button is in the disabled state
        /// </summary>
        [SerializeField] private SimpleButtonStyleElement _disabledSettings = new SimpleButtonStyleElement(Color.white, Color.black);

        public ISimpleButtonStyleElement NormalSettings => _normalSettings;
        public ISimpleButtonStyleElement HighlightedSettings => _highlightedSettings;
        public ISimpleButtonStyleElement PressedSettings => _pressedSettings;
        public ISimpleButtonStyleElement DisabledSettings => _disabledSettings;
    }
}