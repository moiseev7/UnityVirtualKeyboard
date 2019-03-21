using System;
using UnityEngine;
using Zenject;

namespace VirtualKeyboard.Objects.Keyboard.Controllers.PositionController
{
    /// <summary>
    /// Controls position of the keyboard
    /// </summary>
    public class KeyboardPositionController : IInitializable, IDisposable
    {
        /// <summary>
        /// Injection of the position controller config
        /// </summary>
        [Inject] private IKeyboardPositionControllerConfig _positionControllerConfig;

        public void Initialize()
        {
            
        }

        public void Dispose()
        {
            
        }
    }
}
