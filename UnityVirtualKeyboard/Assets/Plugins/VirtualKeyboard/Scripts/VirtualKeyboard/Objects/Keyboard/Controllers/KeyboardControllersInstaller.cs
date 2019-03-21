using Helpers.Interfaces;
using JetBrains.Annotations;
using UnityEngine;
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
        /// Reference to the keyboard show controller installer
        /// Optional - leave it empty if you don't want to use KeyboardShowController
        /// </summary>
        [SerializeField]
        [Tooltip("Reference to the keyboard show controller installer.\nOptional - leave it empty if you don't want to use KeyboardShowController")]
        [CanBeNull] private KeyboardShowControllerInstaller _keyboardShowControllerInstaller;

        public void InstallBindings(DiContainer Container)
        {
            _keyboardShowControllerInstaller?.InstallBindings(Container);
        }
    }
}
