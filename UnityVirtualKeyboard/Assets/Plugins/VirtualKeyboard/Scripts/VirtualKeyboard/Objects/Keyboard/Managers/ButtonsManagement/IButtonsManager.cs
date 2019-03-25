namespace VirtualKeyboard.Objects.Keyboard.Managers.ButtonsManagement
{
    /// <summary>
    /// Interface for <see cref="ButtonsManager"/>
    /// </summary>
    public interface IButtonsManager
    {
        /// <summary>
        /// Resets the buttons
        /// </summary>
        void Reset();

        /// <summary>
        /// Spawns a button based on the parameters
        /// </summary>
        /// <param name="buttonsParameters">Parameters used to spawn a button</param>
        void AddButton(IButtonsParameters buttonsParameters);
    }
}