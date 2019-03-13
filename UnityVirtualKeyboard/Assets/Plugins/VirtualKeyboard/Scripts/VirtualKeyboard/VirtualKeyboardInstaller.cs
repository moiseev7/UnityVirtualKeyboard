using UnityEngine;
using VirtualKeyboard.Styles;
using Zenject;

namespace VirtualKeyboard
{
    /// <summary>
    /// Installer for the virtual keyboard 
    /// </summary>
    public class VirtualKeyboardInstaller : MonoInstaller
    {
        /// <summary>
        /// Reference to the virtual keyboard styles installer
        /// </summary>
        [SerializeField]
        [Tooltip("Reference to the virtual keyboard styles installer")]
        private StylesInstaller _stylesInstaller;

        public override void InstallBindings()
        {
            _stylesInstaller.InstallBindings(Container);
        }
    }
}