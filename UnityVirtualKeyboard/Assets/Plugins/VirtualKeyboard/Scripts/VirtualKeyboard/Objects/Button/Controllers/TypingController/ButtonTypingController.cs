using System;
using UniRx;
using VirtualKeyboard.Managers.InputFieldManagement.Manager;
using Zenject;

namespace VirtualKeyboard.Objects.Button.Controllers.TypingController
{
    /// <summary>
    /// Controller for a button typing
    /// </summary>
    public class ButtonTypingController : IInitializable, IDisposable, IButtonTypingController
    {
        /// <summary>
        /// Injection of the input field typing manager
        /// </summary>
        [Inject] private IInputFieldTypingManager _inputFieldTypingManager;

        /// <summary>
        /// Injection of the typing button
        /// </summary>
        [Inject(Id = "ButtonTypingController - Typing Button")]
        private UnityEngine.UI.Button _button;

        /// <summary>
        /// Disposable 
        /// </summary>
        private CompositeDisposable _disposable;

        /// <summary>
        /// Symbols that will be typed when the button is clicked
        /// </summary>
        private string _symbolsToType;

        public void Initialize()
        {
            _disposable = new CompositeDisposable();
            _button.OnClickAsObservable().Subscribe(_ => _inputFieldTypingManager.Type(_symbolsToType));
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }

        public void SetTypingSymbols(string symbols)
        {
            _symbolsToType = symbols;
        }
    }

    /// <summary>
    /// Interface for <see cref="ButtonTypingController"/>
    /// </summary>
    public interface IButtonTypingController
    {
        /// <summary>
        /// Sets the typing symbols for the button
        /// </summary>
        /// <param name="symbols">Typing symbols</param>
        void SetTypingSymbols(string symbols);
    }
}
