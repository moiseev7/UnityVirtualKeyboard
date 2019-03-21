using UnityEngine;

namespace VirtualKeyboard.Objects.Keyboard.Controllers.PositionController
{
    /// <summary>
    /// Config for KeyboardPositionController
    /// </summary>
    public class KeyboardPositionControllerConfig : ScriptableObject, IKeyboardPositionControllerConfig
    {
        /// <summary>
        /// Offset of the keyboard position relative to the position initially intended by the position controller.
        /// For instance, if position controller intended to place the keyboard directly bellow the input field,
        /// offset (0,-1) would mean that the keyboard will be placed 1 unity bellow the input field
        /// </summary>
        [Tooltip("Offset of the keyboard position relative to the position initially intended by the position controller")]
        [SerializeField] private Vector2 _positionOffset;

        /// <summary>
        /// Offset of the keyboard position relative to the position initially intended by the position controller.
        /// For instance, if position controller intended to place the keyboard directly bellow the input field,
        /// offset (0,-1) would mean that the keyboard will be placed 1 unity bellow the input field
        /// </summary>
        public Vector2 PositionOffset => _positionOffset;
    }

    /// <summary>
    /// Interface for KeyboardPositionControllerConfig
    /// </summary>
    public interface IKeyboardPositionControllerConfig
    {
        /// <summary>
        /// Offset of the keyboard position relative to the position initially intended by the position controller.
        /// </summary>
        Vector2 PositionOffset { get; }
    }
}