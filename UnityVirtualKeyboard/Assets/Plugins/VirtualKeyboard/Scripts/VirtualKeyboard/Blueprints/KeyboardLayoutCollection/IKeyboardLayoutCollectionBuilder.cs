using System.Collections.Generic;
using NSubstitute;
using VirtualKeyboard.Blueprints.KeyboardLayout;

namespace VirtualKeyboard.Blueprints.KeyboardLayoutCollection
{
    /// <summary>
    /// Builder for <see cref="IKeyboardLayoutCollection"/>
    /// </summary>
    public class IKeyboardLayoutCollectionBuilder
    {
        private List<ILayoutBlueprint> _languages;
        
        private ILayoutBlueprint _symbols;
        
        private ILayoutBlueprint _digits;

        public IKeyboardLayoutCollectionBuilder(): this(new List<ILayoutBlueprint>(),null, null )
        {
        }

        private IKeyboardLayoutCollectionBuilder(List<ILayoutBlueprint> languages, ILayoutBlueprint symbols, ILayoutBlueprint digits)
        {
            _languages = languages;
            _symbols = symbols;
            _digits = digits;
        }

        public IKeyboardLayoutCollectionBuilder WithNewLanguage(ILayoutBlueprint language)
        {
            _languages.Add(language);
            return this;
        }

        public IKeyboardLayoutCollectionBuilder WithSymbols(ILayoutBlueprint symbols)
        {
            _symbols = symbols;
            return this;
        }

        public IKeyboardLayoutCollectionBuilder WithDigits(ILayoutBlueprint digits)
        {
            _digits = digits;
            return this;
        }

        public IKeyboardLayoutCollection Build()
        {
            IKeyboardLayoutCollection collection = Substitute.For<IKeyboardLayoutCollection>();
            collection.Digits.Returns(_digits);
            collection.Languages.Returns(_languages);
            collection.Symbols.Returns(_symbols);

            return collection;
        }
    }
}