using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VirtualKeyboard.Data.Button;

namespace VirtualKeyboard.Objects.Keyboard.Managers.RowsManagement
{
    /// <summary>
    /// Manager for the rows
    /// </summary>
    public class RowsManager : IRowsManager
    {
        /// <summary>
        /// Resets the rows
        /// </summary>
        public void ResetRows() { }

        /// <summary>
        /// Adds a new row
        /// </summary>
        /// <param name="buttons">List of the button</param>
        public void AddRow(IEnumerable<IButtonData> buttons) { }
    }

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
        /// <param name="buttons">List of the button</param>
        void AddRow(IEnumerable<IButtonData> buttons);
    }
}