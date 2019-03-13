using System;
using UnityEngine;

namespace VirtualKeyboard.Managers.InputFieldManagement.Manager
{
    /// <summary>
    /// Interface for the manager that supports input fields with 'Submit' command
    /// </summary>
    public interface IInputFieldSubmitManager
    {
        /// <summary>
        /// Observable of support submit flags. TRUE - means that the filed supports 'Submit'
        /// </summary>
        IObservable<bool> SupportsSubmitAsObservable { get; }

        /// <summary>
        /// Observable of the Textures that should be displayed on the submit button on the keyboard
        /// </summary>
        IObservable<Texture2D> SubmitIconAsObservable { get; }

        /// <summary>
        /// Sends 'Submit' to the input field
        /// </summary>
        void Submit();
    }
}