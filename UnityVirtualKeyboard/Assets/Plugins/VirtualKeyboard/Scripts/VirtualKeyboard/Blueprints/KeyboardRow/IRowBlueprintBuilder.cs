using System.Collections.Generic;
using NSubstitute;
using VirtualKeyboard.Data.Button;

namespace VirtualKeyboard.Blueprints.KeyboardRow
{
    /// <summary>
    /// Builder for <see cref="IRowBlueprintBuilder"/>
    /// </summary>
    public class IRowBlueprintBuilder
    {
        private List<IButtonData> _buttons;

        public IRowBlueprintBuilder() : this(new List<IButtonData>())
        {
        }

        private IRowBlueprintBuilder(List<IButtonData> buttons)
        {
            _buttons = buttons;
        }

        public IRowBlueprintBuilder WithNewButton(IButtonData data)
        {
            _buttons.Add(data);
            return this;
        }

        public IRowBlueprint Build()
        {
            IRowBlueprint blueprint = Substitute.For<IRowBlueprint>();
            blueprint.Buttons.Returns(_buttons);
            return blueprint;
        }

    }
}