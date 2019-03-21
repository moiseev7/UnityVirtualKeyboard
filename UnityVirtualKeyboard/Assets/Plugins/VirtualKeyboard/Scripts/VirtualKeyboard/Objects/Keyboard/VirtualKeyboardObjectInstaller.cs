using UnityEngine;
using VirtualKeyboard.Objects.Keyboard.Controllers;
using Zenject;

namespace VirtualKeyboard.Objects.Keyboard
{
    /// <summary>
    /// Root installer for the keyboard object
    /// </summary>
    public class VirtualKeyboardObjectInstaller : MonoInstaller
    {
        /// <summary>
        /// Reference to the keyboard controllers installer
        /// </summary>
        [SerializeField]
        [Tooltip("Reference to the keyboard controllers installer")]
        private KeyboardControllersInstaller _keyboardControllersInstaller;

        public override void InstallBindings()
        {
            _keyboardControllersInstaller.InstallBindings(Container);
        }
    }
}
