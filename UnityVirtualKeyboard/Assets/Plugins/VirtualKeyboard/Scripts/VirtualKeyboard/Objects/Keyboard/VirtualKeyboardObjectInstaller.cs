using JetBrains.Annotations;
using UnityEngine;
using VirtualKeyboard.Objects.Keyboard.Controllers;
using VirtualKeyboard.Objects.Keyboard.Managers;
using Zenject;

namespace VirtualKeyboard.Objects.Keyboard
{
    /// <summary>
    /// Root installer for the keyboard object
    /// </summary>
    public class VirtualKeyboardObjectInstaller : MonoInstaller
    {
        /// <summary>
        /// Reference to the keyboard controllers installer.
        /// Optional - leave it empty if you do not want to use any controllers.
        /// </summary>
        [SerializeField]
        [Tooltip("Reference to the keyboard controllers installer. \nOptional - leave it empty if you do not want to use any controllers.")]
        [CanBeNull] private KeyboardControllersInstaller _keyboardControllersInstaller;

        /// <summary>
        /// Reference to the keyboard managers installer
        /// </summary>
        [Tooltip("Reference to the keyboard managers installer")]
        [SerializeField] private KeyboardManagersInstaller _keyboardManagersInstaller;

        public override void InstallBindings()
        {
            _keyboardControllersInstaller?.InstallBindings(Container);
            _keyboardManagersInstaller.InstallBindings(Container);
        }
    }
}
