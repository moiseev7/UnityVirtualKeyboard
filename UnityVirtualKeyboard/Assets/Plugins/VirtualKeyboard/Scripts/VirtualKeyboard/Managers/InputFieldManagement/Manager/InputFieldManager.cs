using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace VirtualKeyboard.Managers.InputFieldManagement.Manager
{
    /// <summary>
    /// Simple input field manager, that doesn't support 'Submit'
    /// </summary>
    public class InputFieldManager : IInitializable, IInputFieldSelectionManager, IInputFieldTypingManager, IInputFieldSubmitManager
    {


        #region Observables
        /// <summary>
        /// Observable of field selected flags.
        /// TRUE - means 'a suitable field is selected'
        /// FALSE - means 'no suitable fields are selected'
        /// </summary>
        private Subject<bool> _isFieldSelectedAsObservable = new Subject<bool>();

        /// <summary>
        /// Observable of the selected input field rect
        /// </summary>
        private Subject<Rect> _selectedRectAsObservable = new Subject<Rect>();

        /// <summary>
        /// Observable of the parent canvas of the selected input field
        /// </summary>
        private Subject<Canvas> _parentCanvasAsObservable  = new Subject<Canvas>();

        /// <summary>
        /// Observable of support submit flags. TRUE - means that the filed supports 'Submit'
        /// </summary>
        private Subject<bool> _supportsSubmitAsObservable = new Subject<bool>();

        /// <summary>
        /// Observable of the Textures that should be displayed on the submit button on the keyboard
        /// </summary>
        private Subject<Texture2D> _submitIconAsObservable = new Subject<Texture2D>();

        /// <summary>
        /// Observable of field selected flags.
        /// TRUE - means 'a suitable field is selected'
        /// FALSE - means 'no suitable fields are selected'
        /// </summary>
        public IObservable<bool> IsFieldSelectedAsObservable => _isFieldSelectedAsObservable;

        /// <summary>
        /// Observable of the selected input field rect
        /// </summary>
        public IObservable<Rect> SelectedRectAsObservable => _selectedRectAsObservable;

        /// <summary>
        /// Observable of the parent canvas of the selected input field
        /// </summary>
        public IObservable<Canvas> ParentCanvasAsObservable => _parentCanvasAsObservable;

        /// <summary>
        /// Observable of support submit flags. TRUE - means that the filed supports 'Submit'
        /// </summary>
        public IObservable<bool> SupportsSubmitAsObservable => _supportsSubmitAsObservable;

        /// <summary>
        /// Observable of the Textures that should be displayed on the submit button on the keyboard
        /// </summary>
        public IObservable<Texture2D> SubmitIconAsObservable => _submitIconAsObservable;
        #endregion

        public void Initialize()
        {
            
        }
        
        public void Type(string symbolToType)
        {
            
        }

        public void DeleteLast()
        {
            
        }
        
        public void Submit()
        {
            
        }
    }
}
