


using System;
using UniRx;
using UnityEngine;
using VirtualKeyboard.Managers.InputFieldManagement.Manager;
using VirtualKeyboard.Objects.Keyboard.Managers.LayoutManagement;
using Zenject;

namespace VirtualKeyboard.Objects.Keyboard.Controllers.LayoutController
{
    /// <summary>
    /// Responsible for updating the layout when an input field is selected
    /// </summary>
    public class KeyboardLayoutController : IInitializable, IDisposable
    {
        /// <summary>
        /// Injection of the field selection manager
        /// </summary>
        [Inject] private IInputFieldSelectionManager _inputFieldSelectionManager;

        /// <summary>
        /// Reference to the layout manager
        /// </summary>
        [Inject] private ILayoutManager _layoutManager;

        private CompositeDisposable _disposable;

        public void Initialize()
        {
            _disposable = new CompositeDisposable
            {
                //TODO: Add logic to switch to the digits layout when a numeric input field is selected
                _inputFieldSelectionManager.IsFieldSelectedAsObservable.Where(value => value).Subscribe(value => _layoutManager.SetState(LayoutManagerState.Letters))
            };

        }

        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}
