using UnityEngine;
using VirtualKeyboard.Data.Button;

namespace VirtualKeyboard.Objects.Keyboard.Managers.ButtonsManagement
{
    /// <summary>
    /// Parameters used to spawn a button
    /// </summary>
    public class ButtonsParameters : IButtonsParameters
    {
        /// <summary>
        /// Button data
        /// </summary>
        private IButtonData _buttonData;

        /// <summary>
        /// Page of the button to show
        /// </summary>
        private int _page;

        /// <summary>
        /// Parent of the button
        /// </summary>
        private Transform _buttonParent;

        public ButtonsParameters(IButtonData buttonData, int page, Transform buttonParent)
        {
            _buttonData = buttonData;
            _page = page;
            _buttonParent = buttonParent;
        }

        /// <summary>
        /// Button data
        /// </summary>
        public IButtonData ButtonData => _buttonData;

        /// <summary>
        /// Page of the button to show
        /// </summary>
        public int Page => _page;

        /// <summary>
        /// Parent of the button
        /// </summary>
        public Transform ButtonParent => _buttonParent;
    }
}