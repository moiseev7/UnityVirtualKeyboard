using UnityEngine;
using VirtualKeyboard.Data.Button;

namespace VirtualKeyboard.Objects.Row.Managers.ButtonsManagement
{
    /// <summary>
    /// Interface for <see cref="ButtonsParameters"/>
    /// </summary>
    public interface IButtonsParameters
    {
        /// <summary>
        /// Button data
        /// </summary>
        IButtonData ButtonData { get; }

        /// <summary>
        /// Page of the button to show
        /// </summary>
        int Page { get; }

        /// <summary>
        /// Parent of the button
        /// </summary>
        Transform ButtonParent { get; }
    }
}