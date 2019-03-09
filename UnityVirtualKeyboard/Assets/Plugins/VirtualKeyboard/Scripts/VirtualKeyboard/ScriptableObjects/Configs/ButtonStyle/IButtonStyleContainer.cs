namespace VirtualKeyboard.ScriptableObjects.Configs.ButtonStyle
{
    /// <summary>
    /// Interface for a generic button style container
    /// </summary>
    /// <typeparam name="TStyleSettings">Settings that belong to the style</typeparam>
    public interface IButtonStyleContainer<out TStyleSettings>
    {
        /// <summary>
        /// Settings that will be applied when the button is in the normal state
        /// </summary>
        TStyleSettings NormalSettings { get; }

        /// <summary>
        /// Settings that will be applied when the button is in the highlighted state
        /// </summary>
        TStyleSettings HighlightedSettings { get; }

        /// <summary>
        /// Settings that will be applied when the button is in the pressed state
        /// </summary>
        TStyleSettings PressedSettings { get; }

        /// <summary>
        /// Settings that will be applied when the button is in the disabled state
        /// </summary>
        TStyleSettings DisabledSettings { get; }
    }
}