using Helpers.Interfaces;
using UnityEngine;
using VirtualKeyboard.Objects.Keyboard;
using Zenject;

namespace VirtualKeyboard.Managers.KeyboardSpawnManagement
{
    /// <summary>
    /// Installer for KeyboardSpawnManager
    /// </summary>
    public class KeyboardSpawnManagerInstaller : MonoBehaviour, IContainerizedInstaller
    {
        /// <summary>
        /// Reference to the spawner config
        /// </summary>
        [SerializeField] private KeyboardSpawnManagerConfig _keyboardSpawnManagerConfig;

        public void InstallBindings(DiContainer Container)
        {
            Container.BindMemoryPool<VirtualKeyboardObject, VirtualKeyboardObject.Pool>().WithFixedSize(1)
                .FromComponentInNewPrefab(_keyboardSpawnManagerConfig.KeyboardPrefab);
            Container.BindInterfacesTo<KeyboardSpawnManagerConfig>().FromInstance(_keyboardSpawnManagerConfig)
                .AsSingle();
            Container.BindInterfacesTo<KeyboardSpawnManager>().FromNew().AsSingle();
        }
    }
}