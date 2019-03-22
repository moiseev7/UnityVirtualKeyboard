using System;
using UnityEngine;
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

        public void Initialize()
        {
            
        }

        public void Dispose()
        {
            
        }
    }
}
