using VirtualKeyboard.Objects.Keyboard;

namespace VirtualKeyboard.Managers.KeyboardSpawnManagement
{
    /// <summary>
    /// Interface for KeyboardSpawnManagerConfig
    /// </summary>
    public interface IKeyboardSpawnManagerConfig
    {
        /// <summary>
        /// Reference to the virtual keyboard prefab
        /// </summary>
        VirtualKeyboardObject KeyboardPrefab { get; }

        /// <summary>
        /// Name of the spawned keyboard object
        /// </summary>
        string KeyboardObjectName { get; }
    }
}