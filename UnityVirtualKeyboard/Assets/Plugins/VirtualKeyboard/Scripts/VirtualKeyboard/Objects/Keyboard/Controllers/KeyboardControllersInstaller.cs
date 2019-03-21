using Helpers.Interfaces;
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
        /// </summary>
        [SerializeField]
        [Tooltip("Reference to the keyboard show controller installer")]
        private KeyboardShowControllerInstaller _keyboardShowControllerInstaller;
        public void InstallBindings(DiContainer Container)
        {
            _keyboardShowControllerInstaller.InstallBindings(Container);
        }
    }
}
