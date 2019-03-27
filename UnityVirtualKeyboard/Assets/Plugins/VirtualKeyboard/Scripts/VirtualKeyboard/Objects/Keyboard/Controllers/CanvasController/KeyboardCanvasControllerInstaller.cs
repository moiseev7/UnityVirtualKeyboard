using Helpers.Interfaces;
using UnityEngine;
using Zenject;

namespace VirtualKeyboard.Objects.Keyboard.Controllers.CanvasController
{
    /// <summary>
    /// Installer for KeyboardCanvasController
    /// </summary>
    public class KeyboardCanvasControllerInstaller : MonoBehaviour, IContainerizedInstaller
    {
        /// <summary>
        /// Reference to the controlled canvas
        /// </summary>
        [SerializeField]
        [Tooltip("Reference to the controlled canvas")]
        private Canvas _controlledCanvas;

        public void InstallBindings(DiContainer Container)
        {
            Container.Bind<Canvas>().WithId("KeyboardCanvasController - Controlled Canvas")
                .FromInstance(_controlledCanvas).AsSingle();
            Container.BindInterfacesTo<KeyboardCanvasController>().FromNew().AsSingle();
        }
    }
}