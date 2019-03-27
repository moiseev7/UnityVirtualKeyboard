using System.Collections.Generic;
using NSubstitute;
using UnityEngine;
using VirtualKeyboard.Data.Button;

namespace VirtualKeyboard.Objects.Keyboard.Managers.RowsManagement
{
    /// <summary>
    /// Builder for <see cref="IRowParameters"/>
    /// </summary>
    public class IRowParametersBuilder
    {

        private List<IButtonData> _buttons;

        private Transform _rowsParent;

        private int _page;

        public IRowParametersBuilder() : this(new List<IButtonData>(), null, 0 )
        {
        }

        private IRowParametersBuilder(List<IButtonData> buttons, Transform rowsParent, int page)
        {
            _buttons = buttons;
            _rowsParent = rowsParent;
            _page = page;
        }

        public IRowParametersBuilder WithParentTransform(Transform parentTransform)
        {
            _rowsParent = parentTransform;
            return this;
        }

        public IRowParametersBuilder WithNewButton(IButtonData data)
        {
            _buttons.Add(data);
            return this;
        }

        public IRowParametersBuilder WithPage(int page)
        {
            _page = page;
            return this;
        }


        public IRowParameters Build()
        {
            IRowParameters parameters = Substitute.For<IRowParameters>();
            parameters.Buttons.Returns(_buttons);
            parameters.RowsParent.Returns(_rowsParent);
            parameters.Page.Returns(_page);

            return parameters;
        }

    }
}