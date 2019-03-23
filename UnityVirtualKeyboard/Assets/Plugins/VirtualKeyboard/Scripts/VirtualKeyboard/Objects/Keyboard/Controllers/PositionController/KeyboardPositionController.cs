using System;
using JetBrains.Annotations;
using UniRx;
using UnityEngine;
using VirtualKeyboard.Managers.InputFieldManagement.Manager;
using VirtualKeyboard.Objects.Keyboard.Controllers.CanvasController;
using Zenject;

namespace VirtualKeyboard.Objects.Keyboard.Controllers.PositionController
{
    /// <summary>
    ///     Controls position of the keyboard
    /// </summary>
    public class KeyboardPositionController : IInitializable, IDisposable
    {
        /// <summary>
        ///     Injection to the input field selection manager
        /// </summary>
        [Inject] private IInputFieldSelectionManager _fieldSelectionManager;

        /// <summary>
        ///     Injection of the position controller config
        /// </summary>
        [Inject] private IKeyboardPositionControllerConfig _positionControllerConfig;

        /// <summary>
        ///     Injection of the controlled RectTransform
        /// </summary>
        [Inject(Id = "KeyboardPositionController - Controlled RectTransform")]
        private RectTransform _controlledRectTransform;

        /// <summary>
        ///     Disposable
        /// </summary>
        private readonly CompositeDisposable _disposable = new CompositeDisposable();
        

        public void Initialize()
        {
            _disposable.Add(_fieldSelectionManager.SelectedRectTransformAsObservable
                .Where(rectTransform => rectTransform != null)
                .DelayFrame(1) // To make sure that the canvas has been updated
                .Subscribe(rectTransform =>
                {
                    if (rectTransform == null)
                        return;

                    var corners = new Vector3[4];
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