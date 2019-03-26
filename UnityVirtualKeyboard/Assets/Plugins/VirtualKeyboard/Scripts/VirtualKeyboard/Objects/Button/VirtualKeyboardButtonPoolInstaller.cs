using Helpers.Interfaces;
using UnityEngine;
using Zenject;

namespace VirtualKeyboard.Objects.Button
{
    /// <summary>
    /// Installer for the <see cref="VirtualKeyboardButtonObject.Pool"/>
    /// </summary>
    public class VirtualKeyboardButtonPoolInstaller : MonoBehaviour, IContainerizedInstaller
    {
        
        /// <summary>
        /// Reference to the default parent for all the buttons in the keyboard
        /// </summary>
        [Header("Scene References")]
        [Tooltip("Reference to the default parent for all the buttons in the keyboard")]
        [SerializeField] private Transform _buttonParent;

        /// <summary>
        /// Reference to the button pool config
        /// </summary>
        [Header("Assets References")]
        [Tooltip("Reference to the button pool config")]
        [SerializeField] private VirtualKeyboardButtonPoolInstallerConfig _buttonPoolConfig;

        public void InstallBindings(DiContainer Container)
        {
            
        }
    }
}