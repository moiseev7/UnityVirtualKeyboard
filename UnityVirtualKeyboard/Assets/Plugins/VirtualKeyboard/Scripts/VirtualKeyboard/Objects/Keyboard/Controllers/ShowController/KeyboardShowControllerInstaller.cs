using Helpers.Interfaces;
using UnityEngine;
using Zenject;

namespace VirtualKeyboard.Objects.Keyboard.Controllers.ShowController
{
    /// <summary>
    /// Installer for the keyboard show controller
    /// </summary>
    public class KeyboardShowControllerInstaller : MonoBehaviour, IContainerizedInstaller
    {
        /// <summary>
        /// Reference to the game object controlled by the show controller
        /// </summary>
        [SerializeField] private GameObject _controlledGameObject;

        public void InstallBindings(DiContainer Container)
        {
            Container.Bind<GameObject>().WithId("KeyboardShowController - Controlled Object")
                .FromInstance(_controlledGameObject).AsCached();

            Container.BindInterfacesTo<KeyboardShowController>().FromNew().AsSingle();
        }
    }
}