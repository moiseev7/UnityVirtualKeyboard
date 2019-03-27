using System.Collections.Generic;
using UnityEngine;
using VirtualKeyboard.Data.Button;

namespace VirtualKeyboard.Objects.Keyboard.Managers.RowsManagement
{
    /// <summary>
    /// Parameters needed to add a row in the row manager
    /// </summary>
    public class RowParameters : IRowParameters
    {
        /// <summary>
        /// List of the buttons data
        /// </summary>
        private IEnumerable<IButtonData> _buttons;

        /// <summary>
        /// Parent transform for the rows
        /// </summary>
        private Transform _rowsParent;

        /// <summary>
        /// Page of the layout
        /// </summary>
        private int _page;

        public RowParameters(IEnumerable<IButtonData> buttons, Transform rowsParent, int page)
        {
            _buttons = buttons;
            _rowsParent = rowsParent;
            _page = page;
        }

        /// <summary>
        /// List of the buttons data
        /// </summary>
        public IEnumerable<IButtonData> Buttons => _buttons;

        /// <summary>
        /// Parent transform for the rows
        /// </summary>
        public Transform RowsParent => _rowsParent;

        /// <summary>
        /// Page of the layout
        /// </summary>
        public int Page => _page;
    }
}