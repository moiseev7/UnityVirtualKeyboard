using System.Collections;
using System.Collections.Generic;
using System.Linq;
using VirtualKeyboard.Objects.Row;
using Zenject;

namespace VirtualKeyboard.Objects.Keyboard.Managers.RowsManagement
{
    /// <summary>
    /// Manager for the rows
    /// </summary>
    public class RowsManager : IRowsManager
    {
        /// <summary>
        /// Injection of the rows pool
        /// </summary>
        [Inject] private VirtualKeyboardRowObject.Pool _pool;

        /// <summary>
        /// List of the spawned rows
        /// </summary>
        private List<VirtualKeyboardRowObject> _spawned = new List<VirtualKeyboardRowObject>();

        /// <summary>
        /// Index of the row
        /// </summary>
        private int _rowIndex = 0;

        /// <summary>
        /// Resets the rows
        /// </summary>
        public void ResetRows()
        {
            _rowIndex = 0;
            foreach (var rowObject in _spawned.ToList())
            {
                _pool.Despawn(rowObject);
            }

            _spawned.Clear();
        }

        /// <summary>
        /// Adds a new row
        /// </summary>
        /// <param name="rowParameters">Parameters of the row</param>
        public void AddRow(IRowParameters rowParameters)
        {
            var spawned = _pool.Spawn(rowParameters);
            spawned.name = $"Row - {_rowIndex++}";
            _spawned.Add(spawned);
        }
    }
}