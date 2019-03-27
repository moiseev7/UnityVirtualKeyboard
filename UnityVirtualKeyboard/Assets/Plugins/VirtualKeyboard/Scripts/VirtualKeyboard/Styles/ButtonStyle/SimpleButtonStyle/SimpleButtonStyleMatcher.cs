using System.Linq;
using Zenject;

namespace VirtualKeyboard.Styles.ButtonStyle.SimpleButtonStyle
{
    /// <summary>
    /// Matches a <see cref="ButtonStyleEnum"/> and a style
    /// </summary>
    public class SimpleButtonStyleMatcher : IButtonStyleMatcher<ISimpleButtonStyleElement>
    {
        /// <summary>
        /// Injection of the config
        /// </summary>
        [Inject] private ISimpleButtonStyleMatcherConfig _buttonStyleMatcherConfig;

        public IButtonStyleContainer<ISimpleButtonStyleElement> GetStyleContainer(IButtonStyleEnum buttonStyleEnum)
        {
            var foundStyleContainers = (from p in _buttonStyleMatcherConfig.ButtonStylePairs where p.StyleEnum == buttonStyleEnum select p).ToList();
            return foundStyleContainers.Any() ? foundStyleContainers.First().ButtonStyleContainer : _buttonStyleMatcherConfig.DefaultStyle;
        }
    }
}