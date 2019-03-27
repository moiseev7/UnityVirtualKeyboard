using UnityEngine;
using Zenject;

namespace VirtualKeyboard.Managers.SizeManagement
{
    public class ObjectSizeManager : IObjectSizeManager
    {
        /// <summary>
        /// Injection of the size manager config
        /// </summary>
        [Inject] private IObjectSizeManagerConfig _objectSizeManagerConfig;

        /// <summary>
        /// Size of the button unit
        /// </summary>
        public Vector2 ButtonSize => _objectSizeManagerConfig.ButtonUnitSize;
    }
}