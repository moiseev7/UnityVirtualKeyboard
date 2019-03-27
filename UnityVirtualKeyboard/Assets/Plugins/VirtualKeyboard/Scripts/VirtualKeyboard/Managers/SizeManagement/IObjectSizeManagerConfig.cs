using UnityEngine;

namespace VirtualKeyboard.Managers.SizeManagement
{
    /// <summary>
    /// Interface for <see cref="ObjectSizeManagerConfig"/>
    /// </summary>
    public interface IObjectSizeManagerConfig
    {
        /// <summary>
        /// Size of the button unit
        /// </summary>
        Vector2 ButtonUnitSize { get; }
    }
}