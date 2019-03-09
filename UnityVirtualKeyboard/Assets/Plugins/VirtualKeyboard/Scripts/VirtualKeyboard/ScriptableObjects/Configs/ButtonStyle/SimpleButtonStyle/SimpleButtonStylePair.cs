using UnityEngine;

namespace VirtualKeyboard.ScriptableObjects.Configs.ButtonStyle.SimpleButtonStyle
{
    /// <summary>
    /// Class the stores a pair of button style enum and a button style container
    /// </summary>
    [System.Serializable]
    public class SimpleButtonStylePair
    {
        /// <summary>
        /// Button style enum
        /// </summary>
        [SerializeField] private ButtonStyleEnum _buttonStyleEnum;

        /// <summary>
        /// Button style container
        /// </summary>
        [SerializeField] private SimpleButtonStyleContainer _buttonStyleContainer;

        /// <summary>
        /// Button style enum
        /// </summary>
        public ButtonStyleEnum StyleEnum => _buttonStyleEnum;

        /// <summary>
        /// Button style container
        /// </summary>
        public SimpleButtonStyleContainer ButtonStyleContainer => _buttonStyleContainer;
    }
}