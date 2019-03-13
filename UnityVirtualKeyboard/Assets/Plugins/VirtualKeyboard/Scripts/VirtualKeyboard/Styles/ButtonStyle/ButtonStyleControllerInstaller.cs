using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace VirtualKeyboard.Styles.ButtonStyle
{
    /// <summary>
    /// Installer for a button style controller
    /// </summary>
    public class ButtonStyleControllerInstaller<TStyleElement> : MonoInstaller
    {
        /// <summary>
        /// Reference to the button style controller
        /// </summary>
        [SerializeField]
        [Tooltip("Reference to the button style controller")]
        private AbstractButtonStyleController<TStyleElement> _buttonStyleController;

        /// <summary>
        /// Refernce to the button that acts as a source of interactable flag
        /// </summary>
        [SerializeField] private Button _sourceButton;

        public override void InstallBindings()
        {
            Container.Bind<Button>().WithId("ButtonStyleController - Button").FromInstance(_sourceButton).AsCached();
            Container.Bind<IButtonStyleController>().FromInstance(_buttonStyleController).AsSingle();
        }
    }
}