using UnityEngine;
using VirtualKeyboard.Objects.Button;

namespace VirtualKeyboard.Objects.Keyboard.Managers.ButtonsManagement
{
    /// <summary>
    /// Config for the buttons pool
    /// </summary>
    [CreateAssetMenu(fileName = "ButtonsPoolConfig", menuName = "Virtual Keyboard/Objects/Managers/Buttons Pool Config")]
    internal class ButtonsPoolConfig :ScriptableObject, IButtonsPoolConfig
    {
        /// <summary>
        /// Reference to the button prefab
        /// </summary>
        [Tooltip("Reference to the button prefab")]
        [SerializeField] private VirtualKeyboardButtonObject _buttonPrefab;

        /// <summary>
        /// Reference to the button prefab
        /// </summary>
        public VirtualKeyboardButtonObject ButtonPrefab => _buttonPrefab;
    }
}