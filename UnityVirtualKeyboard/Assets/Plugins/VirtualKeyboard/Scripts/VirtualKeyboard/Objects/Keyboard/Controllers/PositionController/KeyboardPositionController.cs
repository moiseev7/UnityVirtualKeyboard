using System;
using UniRx;
using UnityEngine;
using VirtualKeyboard.Managers.InputFieldManagement.Manager;
using Zenject;
using Debug = UnityEngine.Debug;

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
            _disposable.Add(_fieldSelectionManager.SelectedRectTransformAsObservable.Where(rectTransform => rectTransform != null).Subscribe(rectTransform =>
            {
                Vector3[] corners = new Vector3[4];
                rectTransform.GetWorldCorners(corners);
                _controlledRectTransform.position = corners[0] 
                                                    + rectTransform.right * _positionControllerConfig.PositionOffset.x
                                                    + rectTransform.up * _positionControllerConfig.PositionOffset.y
                                                   + rectTransform.forward * _positionControllerConfig.PositionOffset.z;
            }));
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}
