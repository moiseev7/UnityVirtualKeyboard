using System;
using UniRx;
using UnityEngine;
using VirtualKeyboard.Managers.InputFieldManagement.Manager;
using Zenject;

namespace VirtualKeyboard.Objects.Keyboard.Controllers.PositionController
{
    /// <summary>
    /// Controls position of the keyboard
    /// </summary>
    public class KeyboardPositionController : IInitializable, IDisposable
    {
        /// <summary>
        /// Injection to the input field selection manager
        /// </summary>
        [Inject] private IInputFieldSelectionManager _fieldSelectionManager;

        /// <summary>
        /// Injection of the position controller config
        /// </summary>
        [Inject] private IKeyboardPositionControllerConfig _positionControllerConfig;

        /// <summary>
        /// Injection of the controlled RectTransform
        /// </summary>
        [Inject(Id = "KeyboardPositionController - Controlled RectTransform")]
        private RectTransform _controlledRectTransform;

        /// <summary>
        /// Disposable
        /// </summary>
        private CompositeDisposable _disposable = new CompositeDisposable();

        public void Initialize()
        {
            _disposable.Add(_fieldSelectionManager.SelectedRectAsObservable.Where(rect => rect != null).Subscribe(rect =>
            {
                //_controlledRectTransform.position = rect.
                //TODO: Replace Rect? with RectTransform in IInputFieldSelectionManager
            }));
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}
