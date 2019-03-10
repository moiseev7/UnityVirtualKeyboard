using System;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace VirtualKeyboard.Scripts.VirtualKeyboard.Styles.ButtonStyle
{
    /// <summary>
    /// Base class for all the style controllers
    /// </summary>
    public abstract class AbstractButtonStyleController<TStyleElement> : MonoBehaviour, IButtonStyleController, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
    {
        /// <summary>
        /// Injection of the button that acts as a source of interactable flag
        /// </summary>
        [Inject(Id = "ButtonStyleController - Button")]
        private Button _sourceButton;

        /// <summary>
        /// Injection of the button style matcher
        /// </summary>
        [Inject] private IButtonStyleMatcher<TStyleElement> _buttonStyleMatcher;

        /// <summary>
        /// Current style enum
        /// </summary>
        protected ButtonStyleEnum CurrentStyleEnum;

        /// <summary>
        /// Reference to the style element
        /// </summary>
        protected IButtonStyleContainer<TStyleElement> StyleContainer;

        void Start()
        {
            SetStyle(null);
            _sourceButton.ObserveEveryValueChanged(button => button.interactable).Subscribe(OnInteractableChange);
        }
        
        public abstract void OnInteractableChange(bool isInteractable);


        public void SetStyle(ButtonStyleEnum style)
        {
            CurrentStyleEnum = style;
            StyleContainer = _buttonStyleMatcher.GetStyleContainer(CurrentStyleEnum);
        }

        public abstract void OnPointerDown(PointerEventData eventData);

        public abstract void OnPointerEnter(PointerEventData eventData);

        public abstract void OnPointerExit(PointerEventData eventData);
    }
}
