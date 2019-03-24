using Helpers.Interfaces;
using UnityEngine;
using VirtualKeyboard.Objects.Keyboard.Managers.LayoutManagement;
using VirtualKeyboard.Objects.Keyboard.Managers.RowsManagement;
using Zenject;

namespace VirtualKeyboard.Objects.Keyboard.Managers
{
    /// <summary>
    /// Installer for keyboard managers
    /// </summary>
    public class KeyboardManagersInstaller : MonoBehaviour, IContainerizedInstaller
    {
        /// <summary>
        /// Reference to the rows manager installer
        /// </summary>
        [Tooltip("Reference to the rows manager installer")]
        [SerializeField] private RowsManagerInstaller _rowsManagerInstaller;

        /// <summary>
        /// Reference to the object-specific installer for layout manager
        /// </summary>
        [Tooltip("Reference to the object-specific installer for layout manager")]
        [SerializeField] private LayoutManagerObjectInstaller _layoutManagerObjectInstaller;

        public void InstallBindings(DiContainer Container)
        {
            _rowsManagerInstaller.InstallBindings(Container);
            _layoutManagerObjectInstaller.InstallBindings(Container);

        }
    }
}
