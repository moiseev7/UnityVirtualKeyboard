using Helpers.Interfaces;
using UnityEngine;
using VirtualKeyboard.Managers.InputFieldManagement;
using VirtualKeyboard.Managers.KeyboardSpawnManagement;
using VirtualKeyboard.Managers.LanguageManagement;
using VirtualKeyboard.Managers.LayoutSceneManagement;
using VirtualKeyboard.Managers.SizeManagement;
using Zenject;

namespace VirtualKeyboard.Managers
{
    /// <summary>
    /// Installer for all the virtual keyboard managers
    /// </summary>
    public class ManagersInstaller : MonoBehaviour, IContainerizedInstaller
    {
        /// <summary>
        /// Reference to the installer for input field manager
        /// </summary>
        [SerializeField]
        [Tooltip("Reference to the installer for input field manager")]
        private InputFieldManagementInstaller _inputFieldManagementInstaller;

        /// <summary>
        /// Reference to the spawn manager installer
        /// </summary>
        [SerializeField]
        [Tooltip("Reference to the spawn manager installer")]
        private KeyboardSpawnManagerInstaller _keyboardSpawnManagerInstaller;

        /// <summary>
        /// Reference to the language manager installer
        /// </summary>
        [Tooltip("Reference to the language manager installer")]
        [SerializeField] private LanguageManagerInstaller _languageManagerInstaller;

        /// <summary>
        /// Reference to the scene installer for layout managers
        /// </summary>
        [Tooltip("Reference to the scene installer for layout managers")]
        [SerializeField] private LayoutManagerSceneInstaller _layoutManagerSceneInstaller;

        /// <summary>
        /// Reference to the object size manager installer
        /// </summary>
        [Tooltip("Reference to the object size manager installer")]
        [SerializeField] private ObjectSizeManagerInstaller _objectSizeManagerInstaller;

        public void InstallBindings(DiContainer Container)
        {
            _inputFieldManagementInstaller.InstallBindings(Container);
            _keyboardSpawnManagerInstaller.InstallBindings(Container);
            _languageManagerInstaller.InstallBindings(Container);
            _layoutManagerSceneInstaller.InstallBindings(Container);
            _objectSizeManagerInstaller.InstallBindings(Container);
        }
    }
}
