using Helpers.Interfaces;
using UnityEngine;
using VirtualKeyboard.Objects.Row;
using Zenject;

namespace VirtualKeyboard.Objects.Keyboard.Managers.RowsManagement
{
    /// <summary>
    /// Installer for row manager
    /// </summary>
    public class RowsManagerInstaller : MonoBehaviour, IContainerizedInstaller
    {
        /// <summary>
        /// Reference to the default rows parent transform
        /// </summary>
        [Header("Scene References")]
        [Tooltip("Reference to the default rows parent transform")]
        [SerializeField]
        Transform _rowsParent;


        [Header("Assets")] [SerializeField] private RowsManagerConfig _config;

        public void InstallBindings(DiContainer Container)
        {
            Container.Bind<Transform>().WithId("RowsManager - Pool Parent Transform").FromInstance(_rowsParent)
                .AsCached();
            Container.BindMemoryPool<VirtualKeyboardRowObject, VirtualKeyboardRowObject.Pool>().WithInitialSize(5)
                .ExpandByOneAtATime().FromComponentInNewPrefab(_config.RowPrefab).UnderTransform(_rowsParent)
                .AsSingle();

            Container.BindInterfacesTo<RowsManager>().FromNew().AsSingle().NonLazy();
        }
    }
}