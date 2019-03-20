using Helpers.Interfaces;
using UnityEngine;
using VirtualKeyboard.Managers.InputFieldManagement;
using VirtualKeyboard.Managers.KeyboardSpawnManagement;
using Zenject;

namespace VirtualKeyboard.Managers
{
    /// <summary>
    /// Installer for all the virtual keyboard managers
    /// </summary>
    public class ManagersInstaller : MonoBehaviour, IContainerizedInstaller
    {
        /// <summary>
        /// Reference to the installer for input field manager
        /// </summary>
        [SerializeField]
        [Tooltip("Reference to the installer for input field manager")]
        private InputFieldManagementInstaller _inputFieldManagementInstaller;

        /// <summary>
        /// Reference to the spawn manager installer
        /// </summary>
        [SerializeField]
        [Tooltip("Reference to the spawn manager installer")]
        private KeyboardSpawnManagerInstaller _keyboardSpawnManagerInstaller;

        public void InstallBindings(DiContainer Container)
        {
            _inputFieldManagementInstaller.InstallBindings(Container);
            _keyboardSpawnManagerInstaller.InstallBindings(Container);
        }
    }
}
