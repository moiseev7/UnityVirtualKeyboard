using Helpers.Interfaces;
using UnityEngine;
using Zenject;

namespace VirtualKeyboard.Managers.SizeManagement
{
    /// <summary>
    /// Installer for <see cref="ObjectSizeManager"/>
    /// </summary>
    public class ObjectSizeManagerInstaller: MonoBehaviour, IContainerizedInstaller
    {
        /// <summary>
        /// Reference to the object size manager config
        /// </summary>
        [Tooltip("Reference to the object size manager config")]
        [SerializeField] private ObjectSizeManagerConfig _objectSizeManagerConfig;

        public void InstallBindings(DiContainer Container)
        {
            Container.BindInterfacesTo<ObjectSizeManagerConfig>().FromInstance(_objectSizeManagerConfig).AsSingle();
            Container.BindInterfacesTo<ObjectSizeManager>().FromNew().AsSingle();
        }
    }
}