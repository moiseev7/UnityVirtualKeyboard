using UnityEngine;
using Zenject;

namespace VirtualKeyboard.Objects.Button.Controllers.TypingController
{
    /// <summary>
    /// Installer for <see cref="ButtonTypingController"/>
    /// </summary>
    public class ButtonTypingControllerInstaller : MonoInstaller
    {
        /// <summary>
        /// Reference to the button component 
        /// </summary>
        [Tooltip("Reference to the button component ")]
        [SerializeField] private UnityEngine.UI.Button _button;

        public override void InstallBindings()
        {
            Container.Bind<UnityEngine.UI.Button>().WithId("ButtonTypingController - Typing Button")
                .FromInstance(_button).AsCached();
            Container.BindInterfacesAndSelfTo<ButtonTypingController>().FromNew().AsSingle();

        }
    }
}