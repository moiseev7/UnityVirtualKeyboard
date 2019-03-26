namespace VirtualKeyboard.Objects.Button
{
    /// <summary>
    /// Interface for <see cref="VirtualKeyboardButtonPoolInstallerConfig"/>
    /// </summary>
    internal interface IVirtualKeyboardButtonPoolInstallerConfig
    {
        /// <summary>
        /// Reference to the button prefab
        /// </summary>
        VirtualKeyboardButtonObject ButtonPrefab { get; }
    }
}