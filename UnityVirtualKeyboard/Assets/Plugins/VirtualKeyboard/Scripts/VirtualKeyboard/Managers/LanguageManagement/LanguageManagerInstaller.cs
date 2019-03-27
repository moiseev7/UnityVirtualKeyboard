using Helpers.Interfaces;
using UnityEngine;
using Zenject;

namespace VirtualKeyboard.Managers.LanguageManagement
{
    public class LanguageManagerInstaller : MonoBehaviour, IContainerizedInstaller
    {
        public void InstallBindings(DiContainer Container)
        {
            Container.BindInterfacesTo<LanguageManager>().FromNew().AsSingle().NonLazy();
        }
    }
}