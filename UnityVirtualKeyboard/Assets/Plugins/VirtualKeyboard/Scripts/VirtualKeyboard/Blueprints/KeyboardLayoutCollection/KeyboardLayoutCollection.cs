using System.Collections.Generic;
using UnityEngine;
using VirtualKeyboard.Blueprints.KeyboardLayout;

namespace VirtualKeyboard.Blueprints.KeyboardLayoutCollection
{
    /// <summary>
    /// Collection of the keyboard layouts
    /// </summary>
    [CreateAssetMenu(fileName = "KeyboardLayoutCollection", menuName = "Virtual Keyboard/Blueprints/Keyboard Layout Collection")]
    public class KeyboardLayoutCollection : ScriptableObject, IKeyboardLayoutCollection
    {
        /// <summary>
        /// List of the language layouts
        /// </summary>
        [Tooltip("List of the language layouts")]
        [SerializeField] private List<LayoutBlueprint> _languages;

        /// <summary>
        /// Symbols layout
        /// </summary>
        [Tooltip("Symbols layout")]
        [SerializeField] private LayoutBlueprint _symbols;

        /// <summary>
        /// Digits layout
        /// </summary>
        [Tooltip("Digits layout")]
        [SerializeField] private LayoutBlueprint _digits;

        /// <summary>
        /// List of the language layouts
        /// </summary>
        public List<LayoutBlueprint> Languages => _languages;

        /// <summary>
        /// Symbols layout
        /// </summary>
        public LayoutBlueprint Symbols => _symbols;

        /// <summary>
        /// Digits layout
        /// </summary>
        public LayoutBlueprint Digits => _digits;

        void OnValidate()
        {
            if(_languages.Count<2)
                return;

            int? amountOfPages = null;

            for (var index = 0; index < _languages.Count; index++)
            {
                var language = _languages[index];
                if (language == null)
                    continue;

                if (amountOfPages == null)
                {
                    amountOfPages = language.AmountOfPages;
                }
                else if (amountOfPages != language.AmountOfPages)
                {
                    Debug.LogError($"A language named {language.Name} has different page amount then the other languages in the collection");

                    _languages[index] = null;
                    
                }
            }
        }
    }
}
