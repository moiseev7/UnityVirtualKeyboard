using Helpers.Interfaces;
using UnityEngine;
using VirtualKeyboard.Objects.Row.Managers.ButtonsManagement;
using Zenject;

namespace VirtualKeyboard.Objects.Row.Managers
{
    /// <summary>
    /// Root installer for all row managers installers
    /// </summary>
    public class RowManagersInstaller : MonoBehaviour, IContainerizedInstaller
    {
        /// <summary>
        /// Reference to the button manager installer
        /// </summary>
        [Tooltip("Reference to the button manager installer")]
        [SerializeField] private ButtonsManagerInstaller _buttonsManagerInstaller;

        public void InstallBindings(DiContainer Container)
        {
            _buttonsManagerInstaller.InstallBindings(Container);
        }
    }
}
