using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace VirtualKeyboard.Scripts.VirtualKeyboard.Styles.ButtonStyle.SimpleButtonStyle
{
    /// <summary>
    /// Controller for the simple button style.
    /// It is responsible for applying the style to the button
    /// </summary>
    public class SimpleButtonStyleController : AbstractButtonStyleController<ISimpleButtonStyleElement>
    {
        

        /// <summary>
        /// Injection of the container of references
        /// </summary>
        [Inject] private ISimpleButtonStyleObjectReferencesContainer _referencesContainer;

        public override void OnInteractableChange(bool isInteractable)
        {
            if (isInteractable)
            {
                OnStyleUpdate();
            }
            else
            {
                SetColor(StyleContainer.DisabledSettings.BackgroundColor, StyleContainer.DisabledSettings.SymbolColor);
            }
        }

        protected override void OnStyleUpdate()
        {
            SetColor(StyleContainer.NormalSettings.BackgroundColor, StyleContainer.NormalSettings.SymbolColor);
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            SetColor(StyleContainer.PressedSettings.BackgroundColor, StyleContainer.PressedSettings.SymbolColor);
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            SetColor(StyleContainer.HighlightedSettings.BackgroundColor, StyleContainer.HighlightedSettings.SymbolColor);
        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            SetColor(StyleContainer.HighlightedSettings.BackgroundColor, StyleContainer.HighlightedSettings.SymbolColor);
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            SetColor(StyleContainer.NormalSettings.BackgroundColor, StyleContainer.NormalSettings.SymbolColor);
        }

        /// <summary>
        /// Sets color of the symbol and background
        /// </summary>
        /// <param name="backgroundColor">Background color</param>
        /// <param name="symbolColor">Symbol Color</param>
        private void SetColor(Color backgroundColor, Color symbolColor)
        {
            foreach (var background in _referencesContainer.Backgrounds)
            {
                background.color = backgroundColor;
            }

            foreach (var symbol in _referencesContainer.Symbols)
            {
                symbol.color = symbolColor;
            }
        }
    }
}
