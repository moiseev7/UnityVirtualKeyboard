using JetBrains.Annotations;

namespace VirtualKeyboard.Managers.InputFieldManagement.Configs
{
    /// <summary>
    ///     Interface for InputFieldSelectionConfigContainer
    /// </summary>
    /// <typeparam name="TInputFieldCommonType">Type of the base class for the input fields</typeparam>
    public interface IInputFieldSelectionConfigContainer<in TInputFieldCommonType>
    {
        /// <summary>
        ///     Returns the suitable input field config. If not suitable configs were found, returns null.
        /// </summary>
        /// <param name="inputFieldCandidate">An object that may be a suitable input field</param>
        /// <returns>Returns the input field config or null</returns>
        [CanBeNull]
        IInputFieldSelectionConfig<TInputFieldCommonType> GetConfig(TInputFieldCommonType inputFieldCandidate);
    }
}