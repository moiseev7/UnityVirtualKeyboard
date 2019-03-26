using Helpers.Interfaces;
using UnityEngine;
using VirtualKeyboard.Objects.Button;
using Zenject;

namespace VirtualKeyboard.Objects.Keyboard.Managers.ButtonsManagement
{
    /// <summary>
    /// Installer for the buttons pool
    /// </summary>
    public class ButtonsPoolInstaller : MonoBehaviour, IContainerizedInstaller
    {
        /// <summary>
        /// Reference to the buttons parent transform
        /// </summary>
        [Header("Scene References")]
        [Tooltip("Reference to the buttons parent transform")]
        [SerializeField] private Transform _buttonsParent;

        /// <summary>
        /// Reference to the buttons pool config
        /// </summary>
        [Header("Assets References")] [SerializeField]
        private ButtonsPoolConfig _buttonsPoolConfig;

        public void InstallBindings(DiContainer Container)
        {
            Container.Bind<Transform>().WithId("ButtonsPool - Default Parent").FromInstance(_buttonsParent).AsCached();
            Container.BindMemoryPool<VirtualKeyboardButtonObject, VirtualKeyboardButtonObject.Pool>()
                .WithInitialSize(20).ExpandByOneAtATime().FromComponentInNewPrefab(_buttonsPoolConfig.ButtonPrefab)
                .UnderTransform(_buttonsParent).AsCached();
        }
    }
}
