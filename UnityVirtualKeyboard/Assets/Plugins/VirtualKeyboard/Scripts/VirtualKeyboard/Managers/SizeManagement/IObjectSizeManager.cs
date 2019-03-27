using UnityEngine;

namespace VirtualKeyboard.Managers.SizeManagement
{
    /// <summary>
    /// Interface for <see cref="ObjectSizeManager"/>
    /// </summary>
    public interface IObjectSizeManager
    {
        /// <summary>
        /// Size of the button unit
        /// </summary>
        Vector2 ButtonSize { get; }
    }
}