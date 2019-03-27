using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace VirtualKeyboard.Objects.Button.Controllers.SizeController
{
    /// <summary>
    /// Installer for <see cref="ButtonObjectSizeController"/>
    /// </summary>
    public class ButtonObjectSizeControllerInstaller : MonoInstaller
    {
        /// <summary>
        /// Reference to the button layout element
        /// </summary>
        [Tooltip("Reference to the button layout element")]
        [SerializeField] private LayoutElement _layoutElement;

        /// <summary>
        /// Reference to the button size controller
        /// </summary>
        [Tooltip("Reference to the button size controller")]
        [SerializeField] private ButtonObjectSizeController _buttonObjectSizeController;

        public override void InstallBindings()
        {
            Container.Bind<LayoutElement>().WithId("ButtonObjectSizeController - Layout element")
                .FromInstance(_layoutElement).AsCached();

            Container.BindInterfacesTo<ButtonObjectSizeController>().FromInstance(_buttonObjectSizeController)
                .AsCached();

        }
    }
}