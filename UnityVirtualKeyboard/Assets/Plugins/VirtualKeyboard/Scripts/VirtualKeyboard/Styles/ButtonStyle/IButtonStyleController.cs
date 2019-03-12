namespace VirtualKeyboard.Scripts.VirtualKeyboard.Styles.ButtonStyle
{
    /// <summary>
    /// Interface for SimpleButtonStyleController
    /// </summary>
    public interface IButtonStyleController
    {
        /// <summary>
        /// Sets style to the button
        /// </summary>
        /// <param name="style">Style enum</param>
        void SetStyle(IButtonStyleEnum style);
    }
}