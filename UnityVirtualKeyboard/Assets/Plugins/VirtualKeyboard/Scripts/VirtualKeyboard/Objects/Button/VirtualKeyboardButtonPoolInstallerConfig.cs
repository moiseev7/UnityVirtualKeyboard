using UnityEngine;

namespace VirtualKeyboard.Objects.Button
{
    /// <summary>
    /// Config for the buttons pool
    /// </summary>
    internal class VirtualKeyboardButtonPoolInstallerConfig : IVirtualKeyboardButtonPoolInstallerConfig
    {
        /// <summary>
        /// Reference to the button prefab
        /// </summary>
        [Tooltip("Reference to the button prefab")]
        [SerializeField] private VirtualKeyboardButtonObject _buttonPrefab;


        /// <summary>
        /// Reference to the button prefab
        /// </summary>
        public VirtualKeyboardButtonObject ButtonPrefab => _buttonPrefab;
    }
}