using System;
using UniRx;
using UnityEngine;
using VirtualKeyboard.Managers.InputFieldManagement.Manager;
using Zenject;

namespace VirtualKeyboard.Objects.Keyboard.Controllers
{
    /// <summary>
    /// Responsible for showing and hiding the keyboard
    /// </summary>
    public class KeyboardShowController : IInitializable, IDisposable
    {
        /// <summary>
        /// Injection fo the controlled game object
        /// </summary>
        [Inject(Id = "KeyboardShowController - Controlled Object")]
        private GameObject _controlledGameObject;

        /// <summary>
        /// Injection of the input field selection manager
        /// </summary>
        [Inject] private IInputFieldSelectionManager _selectionManager;

        /// <summary>
        /// Disposables related to the object
        /// </summary>
        private readonly CompositeDisposable _disposable = new CompositeDisposable();

        public void Initialize()
        {
            _disposable.Add(_selectionManager.IsFieldSelectedAsObservable.Subscribe(_controlledGameObject.SetActive));
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }
    }
}
