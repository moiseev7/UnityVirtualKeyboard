using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace VirtualKeyboard.Scripts.VirtualKeyboard.Styles.ButtonStyle.SimpleButtonStyle
{
    public class SimpleButtonStyleMatcher : ScriptableObject, IButtonStyleMatcher<ISimpleButtonStyleElement>
    {
        /// <summary>
        /// The default style container
        /// </summary>
        [SerializeField] private SimpleButtonStyleContainer _defaultStyle;

        [SerializeField] private List<SimpleButtonStylePair> _buttonStylePairs;
        public IButtonStyleContainer<ISimpleButtonStyleElement> GetStyleContainer(ButtonStyleEnum buttonStyleEnum)
        {
            var foundStyleContainers = (from p in _buttonStylePairs where p.StyleEnum == buttonStyleEnum select p).ToList();
            return foundStyleContainers.Any() ? foundStyleContainers.First().ButtonStyleContainer : _defaultStyle;
        }
    }
}
