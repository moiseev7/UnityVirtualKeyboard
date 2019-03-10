using UnityEngine;
using VirtualKeyboard.Scripts.Helpers.Interfaces;
using Zenject;

namespace VirtualKeyboard.Scripts.VirtualKeyboard.Styles.ButtonStyle.SimpleButtonStyle
{
    /// <summary>
    /// Scene installer for the simple button style
    /// </summary>
    public class SimpleButtonStyleSceneInstaller : AbstractButtonStyleSceneInstaller
    {
        /// <summary>
        /// Reference to the button style matcher config
        /// </summary>
        [SerializeField] private SimpleButtonStyleMatcherConfig _buttonStyleMatcherConfig;

        public override void InstallBindings(DiContainer Container)
        {
            Container.BindInterfacesTo<SimpleButtonStyleMatcherConfig>().FromInstance(_buttonStyleMatcherConfig)
                .AsSingle().NonLazy();

            Container.BindInterfacesTo<SimpleButtonStyleMatcher>().FromNew().AsSingle().NonLazy();
        }
    }
}
