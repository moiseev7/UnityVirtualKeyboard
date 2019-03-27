using System.Collections.Generic;
using NSubstitute;

namespace VirtualKeyboard.Data.Button
{
    /// <summary>
    /// Builder for <see cref="IButtonData"/>
    /// </summary>
    public class IButtonDataBuilder
    {
        private List<string> _buttonPageCharacters;

        /// <summary>
        ///     Horizontal size of the button in size units. The default size of the button is 1
        /// </summary>
        private int _buttonHorizontalSize;

        private IButtonDataBuilder(List<string> buttonPageCharacters, int buttonHorizontalSize)
        {
            _buttonPageCharacters = buttonPageCharacters;
            _buttonHorizontalSize = buttonHorizontalSize;
        }

        public IButtonDataBuilder() : this(new List<string>(), 1) { }

        public IButtonDataBuilder WithNewCharacter(string character)
        {
            _buttonPageCharacters.Add(character);
            return this;
        }

        public IButtonDataBuilder WithHorizontalSize(int size)
        {
            _buttonHorizontalSize = size;
            return this;
        }

        public IButtonData Build()
        {
            var data = Substitute.For<IButtonData>();
            data.ButtonPageCharacters.Returns(_buttonPageCharacters);
            data.ButtonHorizontalSize.Returns(_buttonHorizontalSize);
            return data;
        }
    }
}