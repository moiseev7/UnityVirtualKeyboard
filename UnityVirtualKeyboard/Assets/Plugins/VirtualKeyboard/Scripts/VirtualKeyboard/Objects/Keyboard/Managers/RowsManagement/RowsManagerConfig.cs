using UnityEngine;
using VirtualKeyboard.Objects.Row;

namespace VirtualKeyboard.Objects.Keyboard.Managers.RowsManagement
{
    [CreateAssetMenu(fileName = "RowsManagerConfig", menuName = "Virtual Keyboard/Objects/Managers/Rows Manager Config")]
    internal class RowsManagerConfig : ScriptableObject, IRowsManagerConfig
    {
        /// <summary>
        /// Reference to the row prefab
        /// </summary>
        [SerializeField]
        private VirtualKeyboardRowObject _rowPrefab;

        /// <summary>
        /// Reference to the row prefab
        /// </summary>
        public VirtualKeyboardRowObject RowPrefab => _rowPrefab;
    }
}