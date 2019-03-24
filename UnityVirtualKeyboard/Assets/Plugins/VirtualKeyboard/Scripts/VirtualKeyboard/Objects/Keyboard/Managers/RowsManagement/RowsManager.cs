using System.Collections;
using System.Collections.Generic;
using NSubstitute;
using UnityEngine;
using VirtualKeyboard.Data.Button;

namespace VirtualKeyboard.Objects.Keyboard.Managers.RowsManagement
{
    /// <summary>
    /// Manager for the rows
    /// </summary>
    public class RowsManager : IRowsManager
    {
        /// <summary>
        /// Resets the rows
        /// </summary>
        public void ResetRows() { }

        /// <summary>
        /// Adds a new row
        /// </summary>
        /// <param name="rowParameters">Parameters of the row</param>
        public void AddRow(IRowParameters rowParameters) { }
    }

    /// <summary>
    /// Interface for RowsManager
    /// </summary>
    public interface IRowsManager
    {
        /// <summary>
        /// Resets the rows
        /// </summary>
        void ResetRows();

        /// <summary>
        /// Adds a new row
        /// </summary>
        /// <param name="rowParameters">Parameters of the row</param>
        void AddRow(IRowParameters rowParameters);
    }

    /// <summary>
    /// Parameters needed to add a row in the row manager
    /// </summary>
    public class RowParameters : IRowParameters
    {
        /// <summary>
        /// List of the buttons data
        /// </summary>
        private IEnumerable<IButtonData> _buttons;

        /// <summary>
        /// Parent transform for the rows
        /// </summary>
        private Transform _rowsParent;

        /// <summary>
        /// Page of the layout
        /// </summary>
        private int _page;

        public RowParameters(IEnumerable<IButtonData> buttons, Transform rowsParent, int page)
        {
            _buttons = buttons;
            _rowsParent = rowsParent;
            _page = page;
        }

        /// <summary>
        /// List of the buttons data
        /// </summary>
        public IEnumerable<IButtonData> Buttons => _buttons;

        /// <summary>
        /// Parent transform for the rows
        /// </summary>
        public Transform RowsParent => _rowsParent;

        /// <summary>
        /// Page of the layout
        /// </summary>
        public int Page => _page;
    }

    /// <summary>
    /// Interface for RowParameters
    /// </summary>
    public interface IRowParameters
    {
        /// <summary>
        /// List of the buttons data
        /// </summary>
        IEnumerable<IButtonData> Buttons { get; }

        /// <summary>
        /// Parent transform for the rows
        /// </summary>
        Transform RowsParent { get; }

        /// <summary>
        /// Page of the layout
        /// </summary>
        int Page { get; }
    }


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