using System.Collections.Generic;
using NSubstitute;
using VirtualKeyboard.Blueprints.KeyboardRow;

namespace VirtualKeyboard.Blueprints.KeyboardLayout
{
    /// <summary>
    /// Builder for <see cref="ILayoutBlueprint"/>
    /// </summary>
    public class ILayoutBlueprintBuilder
    {
        private string _name;

        private List<IRowBlueprint> _rows;

        private int _amountOfPages;

        public ILayoutBlueprintBuilder() : this(new List<IRowBlueprint>(), "", 0)
        {
        }

        private ILayoutBlueprintBuilder(List<IRowBlueprint> rows, string name, int amountOfPages)
        {
            _rows = rows;
            _name = name;
            _amountOfPages = amountOfPages;
        }

        public ILayoutBlueprintBuilder WithNewRow(IRowBlueprint row)
        {
            _rows.Add(row);
            return this;
        }

        public ILayoutBlueprintBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public ILayoutBlueprintBuilder WithAmountOfPages(int amountOfPages)
        {
            _amountOfPages = amountOfPages;
            return this;
        }

        public ILayoutBlueprint Build()
        {
            ILayoutBlueprint layout = Substitute.For<ILayoutBlueprint>();
            layout.RowBlueprints.Returns(_rows);
            layout.AmountOfPages.Returns(_amountOfPages);
            layout.Name.Returns(_name);

            return layout;
        }
    }
}