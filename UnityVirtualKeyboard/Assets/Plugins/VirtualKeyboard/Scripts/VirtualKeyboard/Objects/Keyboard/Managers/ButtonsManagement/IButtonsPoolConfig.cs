using VirtualKeyboard.Objects.Button;

namespace VirtualKeyboard.Objects.Keyboard.Managers.ButtonsManagement
{
    /// <summary>
    /// interface for <see cref="ButtonsPoolConfig"/>
    /// </summary>
    internal interface IButtonsPoolConfig
    {
        /// <summary>
        /// Reference to the button prefab
        /// </summary>
        VirtualKeyboardButtonObject ButtonPrefab { get; }
    }
}