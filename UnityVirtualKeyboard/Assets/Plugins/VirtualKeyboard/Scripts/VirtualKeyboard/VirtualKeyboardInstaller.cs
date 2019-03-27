using UnityEngine;
using VirtualKeyboard.Managers;
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

        /// <summary>
        /// Reference to the virtual keyboard managers installer
        /// </summary>
        [SerializeField]
        [Tooltip("Reference to the virtual keyboard managers installer")]
        private ManagersInstaller _managersInstaller;

        public override void InstallBindings()
        {
            _stylesInstaller.InstallBindings(Container);
            _managersInstaller.InstallBindings(Container);
        }
    }
}