using UnityEngine;

namespace VirtualKeyboard.Objects.Keyboard.Managers.LayoutManagement
{
    /// <summary>
    /// 
    /// </summary>
    [System.Serializable]
    public class LayoutPanelParameters : ILayoutPanelParameters
    {
        /// <summary>
        /// Root object of the panel
        /// </summary>
        [SerializeField]
        [Tooltip("Root object of the panel")]
        private GameObject _panelObject;

        /// <summary>
        /// Parent transform for all the rows in the panel
        /// </summary>
        [SerializeField]
        [Tooltip("Parent transform for all the rows in the panel")]
        private Transform _rowsParenTransform;

        /// <summary>
        /// Root object of the panel
        /// </summary>
        public GameObject PanelObject => _panelObject;

        /// <summary>
        /// Parent transform for all the rows in the panel
        /// </summary>
        public Transform RowsParenTransform => _rowsParenTransform;
    }
}