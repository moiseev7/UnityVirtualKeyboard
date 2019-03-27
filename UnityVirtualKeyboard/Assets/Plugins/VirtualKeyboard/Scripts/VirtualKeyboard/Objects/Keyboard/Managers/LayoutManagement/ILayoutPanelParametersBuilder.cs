using NSubstitute;
using UnityEngine;

namespace VirtualKeyboard.Objects.Keyboard.Managers.LayoutManagement
{
    /// <summary>
    /// Builder for <see cref="ILayoutPanelParameters"/>
    /// </summary>
    public class ILayoutPanelParametersBuilder
    {
        private GameObject _panelObject;
        
        private Transform _rowsParenTransform;

        public ILayoutPanelParametersBuilder() : this(null, null)
        {
        }

        private ILayoutPanelParametersBuilder(GameObject panelObject, Transform rowsParenTransform)
        {
            _panelObject = panelObject;
            _rowsParenTransform = rowsParenTransform;
        }

        public ILayoutPanelParametersBuilder WithPanelObject(GameObject panelObject)
        {
            _panelObject = panelObject;
            return this;
        }

        public ILayoutPanelParametersBuilder WithRowsParentTransform(Transform rowsParenTransform)
        {
            _rowsParenTransform = rowsParenTransform;
            return this;
        }

        public ILayoutPanelParameters Build()
        {
            ILayoutPanelParameters parameters = Substitute.For<ILayoutPanelParameters>();
            parameters.PanelObject.Returns(_panelObject);
            parameters.RowsParenTransform.Returns(_rowsParenTransform);

            return parameters;
        }

    }
}