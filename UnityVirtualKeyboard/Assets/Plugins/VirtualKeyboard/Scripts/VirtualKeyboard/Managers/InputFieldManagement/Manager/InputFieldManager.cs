using System;
using JetBrains.Annotations;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using VirtualKeyboard.Managers.InputFieldManagement.Configs;
using Zenject;

namespace VirtualKeyboard.Managers.InputFieldManagement.Manager
{
    /// <summary>
    /// Simple input field manager, that doesn't support 'Submit'
    /// </summary>
    public class InputFieldManager : IInitializable, IInputFieldSelectionManager, IInputFieldTypingManager, IInputFieldSubmitManager
    {
        /// <summary>
        /// Injection fo the config container
        /// </summary>
        [Inject] private IInputFieldSelectionConfigContainer<Selectable> _configContainer;

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
        private Subject<RectTransform> _selectedRectTransformAsObservable = new Subject<RectTransform>();

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
        public IObservable<RectTransform> SelectedRectTransformAsObservable => _selectedRectTransformAsObservable;

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

        /// <summary>
        /// Current config
        /// </summary>
        [CanBeNull] private IInputFieldSelectionConfig<Selectable> _currentConfig;

        /// <summary>
        /// Currently selected selectable
        /// </summary>
        private Selectable _currentSelectable;

        public void Initialize()
        {
            EventSystem.current.ObserveEveryValueChanged(system => system.currentSelectedGameObject)
                .Select(obj => obj?.GetComponent<Selectable>())
                .Subscribe(selectable =>
                {
                    _currentConfig = _configContainer.GetConfig(selectable);
                    _currentSelectable = _currentConfig != null ? selectable : null;

                    var componentInParent = _currentSelectable?.GetComponentInParent<Canvas>();
                    _parentCanvasAsObservable.OnNext(componentInParent);

                    _isFieldSelectedAsObservable.OnNext(_currentConfig != null);
                    _selectedRectTransformAsObservable.OnNext(_currentSelectable?.GetComponent<RectTransform>());
                    _supportsSubmitAsObservable.OnNext(_currentConfig?.CheckIfSupportsSubmit(selectable) ?? false);
                });
        }
        
        public void Type(string symbolToType)
        {
            if (_currentConfig != null && _currentSelectable != null)
            {
                _currentConfig.TypingAction(_currentSelectable, symbolToType);
            }
        }

        public void DeleteLast()
        {
            if (_currentConfig != null && _currentSelectable != null)
            {
                _currentConfig.DeleteLastSymbolAction(_currentSelectable);
            }
        }
        
        public void Submit()
        {
            
        }
    }
}
