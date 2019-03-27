using System.Collections.Generic;
using UnityEngine;
using VirtualKeyboard.Data.Button;

namespace VirtualKeyboard.Objects.Keyboard.Managers.RowsManagement
{
    /// <summary>
    /// Interface for RowParameters
    /// </summary>
    public interface IRowParameters
    {
        /// <summary>
        /// List of the buttons data
        /// </summary>
        IEnumerable<IButtonData> Buttons { get; }

        /// <summary>
        /// Parent transform for the rows
        /// </summary>
        Transform RowsParent { get; }

        /// <summary>
        /// Page of the layout
        /// </summary>
        int Page { get; }
    }
}