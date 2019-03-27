using UnityEngine;

namespace VirtualKeyboard.Objects.Keyboard.Managers.LayoutManagement
{
    /// <summary>
    /// Interface for LayoutPanelParameters
    /// </summary>
    public interface ILayoutPanelParameters
    {
        /// <summary>
        /// Root object of the panel
        /// </summary>
        GameObject PanelObject { get; }

        /// <summary>
        /// Parent transform for all the rows in the panel
        /// </summary>
        Transform RowsParenTransform { get; }
    }
}