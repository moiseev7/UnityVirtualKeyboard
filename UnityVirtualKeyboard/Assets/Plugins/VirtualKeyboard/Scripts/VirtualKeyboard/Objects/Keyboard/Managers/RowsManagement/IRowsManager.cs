namespace VirtualKeyboard.Objects.Keyboard.Managers.RowsManagement
{
    /// <summary>
    /// Interface for RowsManager
    /// </summary>
    public interface IRowsManager
    {
        /// <summary>
        /// Resets the rows
        /// </summary>
        void ResetRows();

        /// <summary>
        /// Adds a new row
        /// </summary>
        /// <param name="rowParameters">Parameters of the row</param>
        void AddRow(IRowParameters rowParameters);
    }
}