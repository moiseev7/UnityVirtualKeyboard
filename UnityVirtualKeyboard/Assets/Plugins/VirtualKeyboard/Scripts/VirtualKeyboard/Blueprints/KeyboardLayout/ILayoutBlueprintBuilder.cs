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
        private List<IRowBlueprint> _rows;

        public ILayoutBlueprintBuilder() : this(new List<IRowBlueprint>())
        {
        }

        private ILayoutBlueprintBuilder(List<IRowBlueprint> rows)
        {
            _rows = rows;
        }

        public ILayoutBlueprintBuilder WithNewRow(IRowBlueprint row)
        {
            _rows.Add(row);
            return this;
        }

        public ILayoutBlueprint Build()
        {
            ILayoutBlueprint layout = Substitute.For<ILayoutBlueprint>();
            layout.RowBlueprints.Returns(_rows);

            return layout;
        }
    }
}