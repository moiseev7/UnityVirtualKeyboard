using System.Collections.Generic;
using VirtualKeyboard.Blueprints.KeyboardLayout;

namespace VirtualKeyboard.Blueprints.KeyboardLayoutCollection
{
    public interface IKeyboardLayoutCollection
    {
        /// <summary>
        /// List of the language layouts
        /// </summary>
        IEnumerable<ILayoutBlueprint> Languages { get; }

        /// <summary>
        /// Symbols layout
        /// </summary>
        ILayoutBlueprint Symbols { get; }

        /// <summary>
        /// Digits layout
        /// </summary>
        ILayoutBlueprint Digits { get;}
    }
}