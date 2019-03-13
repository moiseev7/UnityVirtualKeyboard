using System;
using UnityEngine;

namespace VirtualKeyboard.Managers.InputFieldManagement.Manager
{
    /// <summary>
    /// Interface for input field selection events manager
    /// </summary>
    public interface IInputFieldSelectionManager
    {
        /// <summary>
        /// Observable of field selected flags.
        /// TRUE - means 'a suitable field is selected'
        /// FALSE - means 'no suitable fields are selected'
        /// </summary>
        IObservable<bool> IsFieldSelectedAsObservable { get; }

        /// <summary>
        /// Observable of the selected input field rect
        /// </summary>
        IObservable<Rect> SelectedRectAsObservable { get; }

        /// <summary>
        /// Observable of the parent canvas of the selected input field
        /// </summary>
        IObservable<Canvas> ParentCanvasAsObservable { get; }
    }
}
