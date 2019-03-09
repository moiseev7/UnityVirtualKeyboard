namespace VirtualKeyboard.ScriptableObjects.Configs.ButtonStyle
{
    /// <summary>
    /// An interface that matches a button style enum and a style container
    /// </summary>
    public interface IButtonStyleMatcher<out TStyleSettings>
    {
        /// <summary>
        /// Returns a button style container based on the 
        /// </summary>
        /// <param name="buttonStyleEnum">Button container</param>
        /// <returns>Returns </returns>
        IButtonStyleContainer<TStyleSettings> GetStyleContainer(ButtonStyleEnum buttonStyleEnum);
    }
}
