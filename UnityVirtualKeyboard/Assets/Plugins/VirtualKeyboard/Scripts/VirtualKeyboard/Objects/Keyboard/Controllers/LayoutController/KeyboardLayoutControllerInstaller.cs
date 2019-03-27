using Helpers.Interfaces;
using UnityEngine;
using Zenject;

namespace VirtualKeyboard.Objects.Keyboard.Controllers.LayoutController
{
    /// <summary>
    /// Installer for KeyboardLayoutController
    /// </summary>
    public class KeyboardLayoutControllerInstaller : MonoBehaviour, IContainerizedInstaller
    {
        public void InstallBindings(DiContainer Container)
        {
            Container.BindInterfacesTo<KeyboardLayoutController>().FromNew().AsSingle();
        }
    }
}