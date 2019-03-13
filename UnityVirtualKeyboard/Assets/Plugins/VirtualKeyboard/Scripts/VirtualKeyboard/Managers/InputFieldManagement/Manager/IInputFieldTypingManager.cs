namespace VirtualKeyboard.Managers.InputFieldManagement.Manager
{
    /// <summary>
    /// Interface that receives typing commands for an input field
    /// </summary>
    public interface IInputFieldTypingManager
    {
        /// <summary>
        /// Typing a symbol to the selected input field
        /// </summary>
        /// <param name="symbolToType">Symbol to type</param>
        void Type(string symbolToType);

        /// <summary>
        /// Deletes last symbol in the input field
        /// </summary>
        void DeleteLast();
    }
}