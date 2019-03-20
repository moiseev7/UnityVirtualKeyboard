using Helpers.Interfaces;
using UnityEngine;
using Zenject;

namespace VirtualKeyboard.Managers.KeyboardSpawnManagement
{
    /// <summary>
    /// Installer for KeyboardSpawnManager
    /// </summary>
    public class KeyboardSpawnManagerInstaller : MonoBehaviour, IContainerizedInstaller
    {
        public void InstallBindings(DiContainer Container)
        {
            Container.BindInterfacesTo<KeyboardSpawnManager>().FromNew().AsSingle();
        }
    }
}