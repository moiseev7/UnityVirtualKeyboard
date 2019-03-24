using UnityEngine;

namespace VirtualKeyboard.Objects.Keyboard.Managers.LayoutManagement
{
    /// <summary>
    /// Manager of the keyboard layout
    /// </summary>
    public class LayoutManager : ILayoutManager
    {
        /// <summary>
        /// Sets the language by the index
        /// </summary>
        /// <param name="index">Index of the language to set</param>
        public void SetLanguage(int index)
        {

        }

        /// <summary>
        /// Sets layout state
        /// </summary>
        /// <param name="state">New layout state</param>
        public void SetState(LayoutManagerState state)
        {

        }

        /// <summary>
        /// Sets layout page by the index. For instance non-shift-layout has the page index '0' and shift-layout has the index '1'
        /// </summary>
        /// <param name="number"></param>
        public void SetLayoutPageByIndex(int number)
        {

        }

        /// <summary>
        /// Sets the layout page to the next available. If the current page has the max index, sets the index back to '0'
        /// </summary>
        public void SetNextLayoutPage()
        {

        }
    }

    /// <summary>
    /// Interface for ILayoutManager
    /// </summary>
    public interface ILayoutManager
    {
        /// <summary>
        /// Sets the language by the index
        /// </summary>
        /// <param name="index">Index of the language to set</param>
        void SetLanguage(int index);

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
