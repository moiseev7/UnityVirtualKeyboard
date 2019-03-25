using Helpers.Interfaces;
using UnityEngine;
using VirtualKeyboard.Objects.Keyboard.Managers.RowsManagement;
using VirtualKeyboard.Objects.Row.Managers;
using Zenject;

namespace VirtualKeyboard.Objects.Row
{
    /// <summary>
    /// Root installer for all the row related installers
    /// </summary>
    public class VirtualKeyboardRowObjectInstaller : MonoInstaller
    {
        /// <summary>
        /// Reference to the row managers installer
        /// </summary>
        [Tooltip("Reference to the row managers installer")]
        [SerializeField] private RowManagersInstaller _rowManagersInstaller;

        public override void InstallBindings()
        {
            _rowManagersInstaller.InstallBindings(Container);
        }
    }
}