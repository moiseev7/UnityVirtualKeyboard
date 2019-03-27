using UnityEngine;
using Zenject;

namespace VirtualKeyboard.Objects.Keyboard
{
    /// <summary>
    ///     Root object for the virtual keyboard prefab
    /// </summary>
    public class VirtualKeyboardObject : MonoBehaviour
    {
        /// <summary>
        ///     Pool for VirtualKeyboardObject
        /// </summary>
        public class Pool : MonoMemoryPool<VirtualKeyboardObject>
        {
        }
    }
}