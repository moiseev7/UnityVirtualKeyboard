using Helpers.Interfaces;
using UnityEngine;
using VirtualKeyboard.Managers.InputFieldManagement.Configs;
using VirtualKeyboard.Managers.InputFieldManagement.Manager;
using Zenject;

namespace VirtualKeyboard.Managers.InputFieldManagement
{
    /// <summary>
    /// Installer for input field manager
    /// </summary>
    public class InputFieldManagementInstaller : MonoBehaviour, IContainerizedInstaller
    {
        /// <summary>
        /// Reference to the input field configs container
        /// </summary>
        [SerializeField]
        [Tooltip("Reference to the input field configs container")]
        private InputFieldSelectionConfigContainer _configContainer;

        public void InstallBindings(DiContainer Container)
        {
            Container.BindInterfacesTo<InputFieldSelectionConfigContainer>().FromInstance(_configContainer).AsSingle();
            Container.BindInterfacesTo<InputFieldManager>().FromNew().AsSingle();
        }
    }
}
