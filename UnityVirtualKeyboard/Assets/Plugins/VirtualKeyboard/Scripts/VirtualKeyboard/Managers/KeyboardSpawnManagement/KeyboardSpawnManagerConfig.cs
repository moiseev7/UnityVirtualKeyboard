using UnityEngine;
using VirtualKeyboard.Objects.Keyboard;

namespace VirtualKeyboard.Managers.KeyboardSpawnManagement
{
    /// <summary>
    /// Config for KeyboardSpawnManager
    /// </summary>
    [CreateAssetMenu(fileName = "KeyboardSpawnManagerConfig", menuName = "Virtual Keyboard/Management/Keyboard Spawn Management/Keyboard Spawn Manager Config")]
    public class KeyboardSpawnManagerConfig : ScriptableObject, IKeyboardSpawnManagerConfig
    {
        /// <summary>
        /// Reference to the virtual keyboard prefab
        /// </summary>
        [SerializeField]
        [Tooltip("Reference to the virtual keyboard prefab")]
        private VirtualKeyboardObject _keyboardPrefab;

        /// <summary>
        /// Name of the spawned keyboard object
        /// </summary>
        [SerializeField] private string _keyboardObjectName = "Virtual Keyboard";


        /// <summary>
        /// Reference to the virtual keyboard prefab
        /// </summary>
        public VirtualKeyboardObject KeyboardPrefab => _keyboardPrefab;

        /// <summary>
        /// Name of the spawned keyboard object
        /// </summary>
        public string KeyboardObjectName => _keyboardObjectName;
    }
}