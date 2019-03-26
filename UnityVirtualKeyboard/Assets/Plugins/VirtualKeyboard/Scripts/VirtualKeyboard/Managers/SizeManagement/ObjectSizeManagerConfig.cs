using UnityEngine;

namespace VirtualKeyboard.Managers.SizeManagement
{
    /// <summary>
    /// Config for <see cref="ObjectSizeManager"/>
    /// </summary>
    [CreateAssetMenu(fileName = "ObjectSizeManagerConfig", menuName = "Virtual Keyboard/Management/Size Management/Object Size Manager Config")]
    public class ObjectSizeManagerConfig : ScriptableObject, IObjectSizeManagerConfig
    {
        /// <summary>
        /// Size of the button unit
        /// </summary>
        [SerializeField] private Vector2 _buttonUnitSize = new Vector2(30,30);

        /// <summary>
        /// Size of the button unit
        /// </summary>
        public Vector2 ButtonUnitSize => _buttonUnitSize;

        void OnValidate()
        {
            var x = Mathf.Max(1, ButtonUnitSize.x);
            var y = Mathf.Max(1, ButtonUnitSize.y);
            _buttonUnitSize = new Vector2(x, y);
        }
    }
}