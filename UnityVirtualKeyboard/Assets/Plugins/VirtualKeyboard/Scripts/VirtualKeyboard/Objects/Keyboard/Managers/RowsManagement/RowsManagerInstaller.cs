using Helpers.Interfaces;
using UnityEngine;
using Zenject;

namespace VirtualKeyboard.Objects.Keyboard.Managers.RowsManagement
{
    /// <summary>
    /// Installer for row manager
    /// </summary>
    public class RowsManagerInstaller : MonoBehaviour, IContainerizedInstaller
    {
        public void InstallBindings(DiContainer Container)
        {
            Container.BindInterfacesTo<RowsManager>().FromNew().AsSingle().NonLazy();
        }
    }
}