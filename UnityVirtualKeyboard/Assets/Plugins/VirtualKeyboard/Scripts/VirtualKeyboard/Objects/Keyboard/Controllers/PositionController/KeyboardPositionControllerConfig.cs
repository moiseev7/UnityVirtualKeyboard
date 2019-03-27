using UnityEngine;

namespace VirtualKeyboard.Objects.Keyboard.Controllers.PositionController
{
    /// <summary>
    /// Config for KeyboardPositionController
    /// </summary>
    [CreateAssetMenu(fileName = "KeyboardPositionControllerConfig", menuName = "Virtual Keyboard/Objects/Controllers/Keyboard Position Controller Config")]
    public class KeyboardPositionControllerConfig : ScriptableObject, IKeyboardPositionControllerConfig
    {
        /// <summary>
        /// Offset of the keyboard position relative to the position initially intended by the position controller.
        /// For instance, if position controller intended to place the keyboard directly bellow the input field,
        /// offset (0,-1) would mean that the keyboard will be placed 1 unity bellow the input field
        /// </summary>
        [Tooltip("Offset of the keyboard position relative to the position initially intended by the position controller")]
        [SerializeField] private Vector3 _positionOffset;

        /// <summary>
        /// Offset of the keyboard position relative to the position initially intended by the position controller.
        /// For instance, if position controller intended to place the keyboard directly bellow the input field,
        /// offset (0,-1) would mean that the keyboard will be placed 1 unity bellow the input field
        /// </summary>
        public Vector3 PositionOffset => _positionOffset;
    }
}