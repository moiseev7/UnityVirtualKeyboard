using System.Linq;
using UnityEngine;
using VirtualKeyboard.Blueprints.KeyboardLayout;
using VirtualKeyboard.Blueprints.KeyboardLayoutCollection;
using VirtualKeyboard.Data.Button;
using VirtualKeyboard.Managers.LanguageManagement;
using VirtualKeyboard.Objects.Keyboard.Managers.RowsManagement;
using Zenject;

namespace VirtualKeyboard.Objects.Keyboard.Managers.LayoutManagement
{
    /// <summary>
    /// Manager of the keyboard layout
    /// </summary>
    public class LayoutManager : ILayoutManager
    {
        /// <summary>
        /// Injection of the layout collection
        /// </summary>
        [Inject] private IKeyboardLayoutCollection _layoutCollection;

        /// <summary>
        /// Injection of the rows manager
        /// </summary>
        [Inject] private IRowsManager _rowsManager;

        /// <summary>
        /// Injection of the language manager
        /// </summary>
        [Inject] private ILanguageManager _languageManager;

        /// <summary>
        /// Injection of the parameters of the letters panel
        /// </summary>
        [Inject(Id = "LayoutManager - Letters Panel Parameters")]
        private ILayoutPanelParameters _lettersPanelParameters;

        /// <summary>
        /// Injection of the parameters of the symbols panel
        /// </summary>
        [Inject(Id = "LayoutManager - Symbols Panel Parameters")]
        private ILayoutPanelParameters _symbolsPanelParameters;

        /// <summary>
        /// Injection of the parameters of the digits panel
        /// </summary>
        [Inject(Id = "LayoutManager - Digits Panel Parameters")]
        private ILayoutPanelParameters _digitsPanelParameters;

        

        /// <summary>
        /// Number of the current page
        /// </summary>
        private int _currentPageNumber = 0;

        /// <summary>
        /// Current state of the layout manager
        /// </summary>
        private LayoutManagerState _currentState = LayoutManagerState.Letters;

        /// <summary>
        /// Reference to the current layout
        /// </summary>
        private ILayoutBlueprint _currentLayout;

        /// <summary>
        /// Sets layout state
        /// </summary>
        /// <param name="state">New layout state</param>
        public void SetState(LayoutManagerState state)
        {
            _currentState = state;
            _currentPageNumber = 0;
            switch (state)
            {
                case LayoutManagerState.Letters:
                    SwitchToLetters();
                    break;
                case LayoutManagerState.Symbols:
                    SwitchToSymbols();
                    break;
                case LayoutManagerState.Digits:
                    SwitchToDigits();
                    break;
            }
        }

        /// <summary>
        /// Switch to the digits layout
        /// </summary>
        private void SwitchToDigits()
        {
            _currentLayout = _layoutCollection.Digits;

            _lettersPanelParameters.PanelObject.SetActive(false);
            _symbolsPanelParameters.PanelObject.SetActive(false);
            _digitsPanelParameters.PanelObject.SetActive(true);

            SpawnCurrentLayout();
        }

        /// <summary>
        /// Switches to the symbols layout
        /// </summary>
        private void SwitchToSymbols()
        {
            _currentLayout = _layoutCollection.Symbols;

            _lettersPanelParameters.PanelObject.SetActive(false);
            _symbolsPanelParameters.PanelObject.SetActive(true);
            _digitsPanelParameters.PanelObject.SetActive(false);

            SpawnCurrentLayout();
        }

        /// <summary>
        /// Switches to the letters layout
        /// </summary>
        private void SwitchToLetters()
        {
            _lettersPanelParameters.PanelObject.SetActive(true);
            _symbolsPanelParameters.PanelObject.SetActive(false);
            _digitsPanelParameters.PanelObject.SetActive(false);

            _currentLayout = _layoutCollection.Languages.ToList()[_languageManager.CurrentLanguageIndex];
            SpawnCurrentLayout();

        }

        private void SpawnCurrentLayout()
        {
            _rowsManager.ResetRows();

            foreach (var rowBlueprint in _currentLayout.RowBlueprints)
            {
                var builder = new IRowParametersBuilder();
                builder = builder.WithPage(_currentPageNumber)
                    .WithParentTransform(_lettersPanelParameters.RowsParenTransform);
                foreach (var button in rowBlueprint.Buttons)
                {
                    builder = builder.WithNewButton(button);
                }

                _rowsManager.AddRow(builder.Build());
            }
        }

        /// <summary>
        /// Sets layout page by the index. For instance non-shift-layout has the page index '0' and shift-layout has the index '1'
        /// </summary>
        /// <param name="number"></param>
        public void SetLayoutPageByIndex(int number)
        {
            if (_currentLayout.AmountOfPages < 1)
            {
                Debug.LogError($"Layout manager: amount of pages in the current layout should be >= 1, but is was {_currentLayout.AmountOfPages}");
                return;
            }
            _currentPageNumber = number % _currentLayout.AmountOfPages;

            SpawnCurrentLayout();
        }

        /// <summary>
        /// Sets the layout page to the next available. If the current page has the max index, sets the index back to '0'
        /// </summary>
        public void SetNextLayoutPage()
        {
           SetLayoutPageByIndex(++_currentPageNumber);
        }
    }

    /// <summary>
    /// Interface for ILayoutManager
    /// </summary>
    public interface ILayoutManager
    {

        /// <summary>
        /// Sets layout state
        /// </summary>
        /// <param name="state">New layout state</param>
        void SetState(LayoutManagerState state);

        /// <summary>
        /// Sets layout page by the index. For instance non-shift-layout has the page index '0' and shift-layout has the index '1'
        /// </summary>
        /// <param name="number"></param>
        void SetLayoutPageByIndex(int number);

        /// <summary>
        /// Sets the layout page to the next available. If the current page has the max index, sets the index back to '0'
        /// </summary>
        void SetNextLayoutPage();
    }
}
