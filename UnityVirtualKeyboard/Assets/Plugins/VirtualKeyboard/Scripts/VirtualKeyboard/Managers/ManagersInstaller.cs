using Helpers.Interfaces;
using UnityEngine;
using VirtualKeyboard.Managers.InputFieldManagement;
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
        [SerializeField] private InputFieldManagementInstaller _inputFieldManagementInstaller;

        public void InstallBindings(DiContainer Container)
        {
            _inputFieldManagementInstaller.InstallBindings(Container);
        }
    }
}
