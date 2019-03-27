using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VirtualKeyboard.Managers.SizeManagement;
using Zenject;

namespace VirtualKeyboard.Objects.Button.Controllers.SizeController
{
    /// <summary>
    /// Controller of the button size
    /// </summary>
    public class ButtonObjectSizeController : MonoBehaviour, IButtonObjectSizeController
    {
        /// <summary>
        /// Alignment of the button size controller
        /// </summary>
        [Tooltip("Alignment of the button size controller")]
        [SerializeField] private SizeControllerAlignment _alignment = SizeControllerAlignment.Horizontal;

        /// <summary>
        /// Size of the button
        /// </summary>
        [SerializeField] private int _size = 1;

        /// <summary>
        /// Injection of the button layout element
        /// </summary>
        [Inject(Id = "ButtonObjectSizeController - Layout element")] private LayoutElement _layoutElement;

        /// <summary>
        /// Injection of the object size manager
        /// </summary>
        [Inject] private IObjectSizeManager _objectSizeManager;


        public void SetSize(int size)
        {
            if (size <= 0) throw new ArgumentOutOfRangeException(nameof(size));
            _size = size;

            _layoutElement.preferredWidth = _objectSizeManager.ButtonSize.x * (_alignment == SizeControllerAlignment.Vertical?1:_size) ;
            _layoutElement.preferredHeight = _objectSizeManager.ButtonSize.y * (_alignment == SizeControllerAlignment.Horizontal ? 1 : _size);
        }

        void OnValidate()
        {
            if (_size < 1)
                _size = 1;
        }
    }

    /// <summary>
    /// Interface for <see cref="ButtonObjectSizeController"/>
    /// </summary>
    public interface IButtonObjectSizeController
    {
        void SetSize(int size);
    }

    /// <summary>
    /// Alignment of the button size controller
    /// </summary>
    public enum SizeControllerAlignment
    {
        Vertical, Horizontal
    }
}