using UnityEngine;

namespace VirtualKeyboard.Styles.ButtonStyle
{
    /// <summary>
    /// Acts as an Enum for button styles
    /// </summary>
    [CreateAssetMenu(fileName = "ButtonStyleEnum",
        menuName = "Virtual Keyboard/Styles/Button Styles/Button Style Enum")]
    public class ButtonStyleEnum : ScriptableObject, IButtonStyleEnum
    {
        [SerializeField] private string _name;

        public string Name => _name;
    }
}
