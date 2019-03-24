using System.Collections.Generic;
using VirtualKeyboard.Blueprints.KeyboardRow;

namespace VirtualKeyboard.Blueprints.KeyboardLayout
{
    public interface ILayoutBlueprint
    {
        /// <summary>
        /// List of the row blueprints
        /// </summary>
        IEnumerable<IRowBlueprint> RowBlueprints { get; }

        /// <summary>
        /// Name of the layout
        /// </summary>
        string Name { get; }
    }
}