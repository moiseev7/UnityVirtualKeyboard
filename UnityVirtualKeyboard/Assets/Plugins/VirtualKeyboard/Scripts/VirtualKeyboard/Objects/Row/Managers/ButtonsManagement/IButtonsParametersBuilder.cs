using NSubstitute;
using UnityEngine;
using VirtualKeyboard.Data.Button;

namespace VirtualKeyboard.Objects.Row.Managers.ButtonsManagement
{
    /// <summary>
    /// Builder for <see cref="IButtonsParameters"/>
    /// </summary>
    public class IButtonsParametersBuilder
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

        public IButtonsParametersBuilder() : this(null, 0, null)
        {
        }

        private IButtonsParametersBuilder(IButtonData buttonData, int page, Transform buttonParent)
        {
            _buttonData = buttonData;
            _page = page;
            _buttonParent = buttonParent;
        }

        public IButtonsParametersBuilder WithButtonData(IButtonData buttondata)
        {
            _buttonData = buttondata;
            return this;
        }

        public IButtonsParametersBuilder WithPageNumber(int page)
        {
            _page = page;
            return this;
        }

        public IButtonsParametersBuilder WithButtonParent(Transform buttonParent)
        {
            _buttonParent = buttonParent;
            return this;
        }

        public IButtonsParameters Build()
        {
            var result = Substitute.For<IButtonsParameters>();
            result.ButtonData.Returns(_buttonData);
            result.ButtonParent.Returns(_buttonParent);
            result.Page.Returns(_page);

            return result;
        }

    }
}