using Helpers.Interfaces;
using UnityEngine;
using Zenject;

namespace VirtualKeyboard.Objects.Row.Managers.ButtonsManagement
{
    public class ButtonsManagerInstaller : MonoBehaviour, IContainerizedInstaller
    {
        public void InstallBindings(DiContainer Container)
        {
            Container.BindInterfacesTo<ButtonsManager>().FromNew().AsSingle();
        }
    }
}
