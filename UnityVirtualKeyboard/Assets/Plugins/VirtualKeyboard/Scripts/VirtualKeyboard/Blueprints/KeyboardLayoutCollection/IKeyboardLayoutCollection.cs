using System.Collections.Generic;
using VirtualKeyboard.Blueprints.KeyboardLayout;

namespace VirtualKeyboard.Blueprints.KeyboardLayoutCollection
{
    public interface IKeyboardLayoutCollection
    {
        /// <summary>
        /// List of the language layouts
        /// </summary>
        List<LayoutBlueprint> Languages { get; }

        /// <summary>
        /// Symbols layout
        /// </summary>
        LayoutBlueprint Symbols { get; }

        /// <summary>
        /// Digits layout
        /// </summary>
        LayoutBlueprint Digits { get;}
    }
}