using Helpers.Interfaces;
using UnityEngine;
using Zenject;

namespace VirtualKeyboard.Objects.Keyboard.Controllers.PositionController
{
    /// <summary>
    /// Installer for KeyboardPositionController
    /// </summary>
    public class KeyboardPositionControllerInstaller : MonoBehaviour, IContainerizedInstaller
    {
        /// <summary>
        /// Reference to the position controller config
        /// </summary>
        [SerializeField]
        [Tooltip("Reference to the position controller config")]
        private KeyboardPositionControllerConfig _positionControllerConfig;

        public void InstallBindings(DiContainer Container)
        {
            Container.BindInterfacesTo<KeyboardPositionControllerConfig>().FromInstance(_positionControllerConfig)
                .AsSingle();
            Container.BindInterfacesTo<KeyboardPositionController>().FromNew().AsSingle();
        }
    }
}