using UnityEngine;

namespace VirtualKeyboard.Objects.Keyboard.Controllers.PositionController
{
    /// <summary>
    /// Interface for KeyboardPositionControllerConfig
    /// </summary>
    public interface IKeyboardPositionControllerConfig
    {
        /// <summary>
        /// Offset of the keyboard position relative to the position initially intended by the position controller.
        /// </summary>
        Vector3 PositionOffset { get; }
    }
}