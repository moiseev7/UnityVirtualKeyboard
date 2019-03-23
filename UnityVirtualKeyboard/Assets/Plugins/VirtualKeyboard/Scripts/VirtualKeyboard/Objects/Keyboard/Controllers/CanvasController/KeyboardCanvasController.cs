﻿using System;
using Helpers.Components;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using VirtualKeyboard.Managers.InputFieldManagement.Manager;
using Zenject;

namespace VirtualKeyboard.Objects.Keyboard.Controllers.CanvasController
{
    /// <summary>
    /// Controller for the keyboard canvas
    /// </summary>
    public class KeyboardCanvasController : IInitializable, IDisposable
    {
        /// <summary>
        /// Injection of the controlled canvas
        /// </summary>
        [Inject(Id = "KeyboardCanvasController - Controlled Canvas")]
        private Canvas _controlledCanvas;

        /// <summary>
        /// Injection of the field selection manager
        /// </summary>
        [Inject] private IInputFieldSelectionManager _fieldSelectionManager;

        private CompositeDisposable _disposable;

        private bool _isShuttingDown;

        public void Initialize()
        {
            _disposable = new CompositeDisposable();
            _disposable.Add(_fieldSelectionManager.ParentCanvasAsObservable.Where(canvas => canvas != null).Subscribe(canvas =>
            {
                Debug.Log("Updated canvas");
                _controlledCanvas.worldCamera = canvas.worldCamera;
                _controlledCanvas.renderMode = canvas.renderMode;
                _controlledCanvas.GetComponent<CanvasScaler>()?.GetCopyOf(canvas.GetComponent<CanvasScaler>());
                _controlledCanvas.GetCopyOf(canvas);
                _controlledCanvas.GetComponent<RectTransform>()?.GetCopyOf(canvas.GetComponent<RectTransform>());
                _controlledCanvas.transform.localScale = canvas.transform.lossyScale;
                _controlledCanvas.transform.rotation = canvas.transform.rotation;
                Canvas.ForceUpdateCanvases();
            }));
        }

        void OnApplicationQuit()
        {
            _isShuttingDown = true;
        }

        public void Dispose()
        {
            if (_isShuttingDown)
                return;

            _disposable.Dispose();
        }
    }
}
