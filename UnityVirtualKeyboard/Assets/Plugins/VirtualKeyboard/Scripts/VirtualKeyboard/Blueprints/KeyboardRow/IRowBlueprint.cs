using System.Collections.Generic;
using VirtualKeyboard.Data.Button;

namespace VirtualKeyboard.Blueprints.KeyboardRow
{
    /// <summary>
    ///     Interface for the keyboard row blueprint
    /// </summary>
    public interface IRowBlueprint
    {
        /// <summary>
        ///     Amount of modes supported by the row
        /// </summary>
        int AmountOfPages { get; }

        /// <summary>
        ///     Buttons of the row
        /// </summary>
        IEnumerable<IButtonData> Buttons { get; }
    }
}