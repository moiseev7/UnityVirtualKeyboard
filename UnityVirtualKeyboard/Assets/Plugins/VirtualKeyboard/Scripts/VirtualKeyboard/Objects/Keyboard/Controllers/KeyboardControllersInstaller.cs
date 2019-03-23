using Helpers.Interfaces;
using JetBrains.Annotations;
using UnityEngine;
using VirtualKeyboard.Objects.Keyboard.Controllers.CanvasController;
using VirtualKeyboard.Objects.Keyboard.Controllers.PositionController;
using VirtualKeyboard.Objects.Keyboard.Controllers.ShowController;
using Zenject;

namespace VirtualKeyboard.Objects.Keyboard.Controllers
{
    /// <summary>
    /// Installer for all the keyboard controllers
    /// </summary>
    public class KeyboardControllersInstaller : MonoBehaviour, IContainerizedInstaller
    {
        /// <summary>
        /// Reference to the keyboard show controller installer.
        /// Optional - leave it empty if you don't want to use KeyboardShowController
        /// </summary>
        [SerializeField]
        [Tooltip("Reference to the keyboard show controller installer.\nOptional - leave it empty if you don't want to use KeyboardShowController")]
        [CanBeNull] private KeyboardShowControllerInstaller _keyboardShowControllerInstaller;

        /// <summary>
        /// Reference to the keyboard position controller installer.
        /// Optional - leave it empty if you do not want to use KeyboardPositionController
        /// </summary>
        [Tooltip("Reference to the keyboard position controller installer.\nOptional - leave it empty if you do not want to use KeyboardPositionController")]
        [SerializeField]
        [CanBeNull] private KeyboardPositionControllerInstaller _keyboardPositionControllerInstaller;
        /// <summary>
        /// Reference to the keyboard canvas controller installer.
        /// Optional - leave it empty if you do not want to use KeyboardController
        /// </summary>
        [Tooltip("Reference to the keyboard canvas controller installer.\nOptional - leave it empty if you do not want to use KeyboardController")]
        [SerializeField]
        [CanBeNull] private KeyboardCanvasControllerInstaller _keyboardCanvasControllerInstaller;

        public void InstallBindings(DiContainer Container)
        {
            _keyboardShowControllerInstaller?.InstallBindings(Container);
            _keyboardPositionControllerInstaller?.InstallBindings(Container);
            _keyboardCanvasControllerInstaller?.InstallBindings(Container);
        }
    }
}
