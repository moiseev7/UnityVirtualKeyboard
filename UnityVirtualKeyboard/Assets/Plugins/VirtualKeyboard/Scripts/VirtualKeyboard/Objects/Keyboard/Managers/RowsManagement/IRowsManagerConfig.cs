using VirtualKeyboard.Objects.Row;

namespace VirtualKeyboard.Objects.Keyboard.Managers.RowsManagement
{
    /// <summary>
    /// Interface for RowsManagerConfig
    /// </summary>
    internal interface IRowsManagerConfig
    {
        /// <summary>
        /// Reference to the row prefab
        /// </summary>
        VirtualKeyboardRowObject RowPrefab { get; }
    }
}