using VirtualKeyboard.Blueprints.KeyboardLayoutCollection;
using Zenject;

namespace VirtualKeyboard.Objects.Keyboard.Managers.LanguageManagement
{
    /// <summary>
    /// Manager for the keyboard languages
    /// </summary>
    public class LanguageManager : ILanguageManager
    {
        /// <summary>
        /// Injection of the layout collection
        /// </summary>
        [Inject] private IKeyboardLayoutCollection _layoutCollection;

        /// <summary>
        /// Index of the current language
        /// </summary>
        private int _currentLanguageIndex;


        /// <summary>
        /// Index of the current language
        /// </summary>
        public int CurrentLanguageIndex => _currentLanguageIndex;

        /// <summary>
        /// Selects the language by the name
        /// </summary>
        /// <param name="name">Name of the language to select</param>
        public void SelectLanguageByName(string name)
        {
            
        }
    }

    /// <summary>
    /// Interface for LanguageManager
    /// </summary>
    public interface ILanguageManager
    {
        /// <summary>
        /// Index of the current language
        /// </summary>
        int CurrentLanguageIndex { get; }

        /// <summary>
        /// Selects the language by the name
        /// </summary>
        /// <param name="name">Name of the language to select</param>
        void SelectLanguageByName(string name);
    }
}
