using JetBrains.Annotations;
using UnityEngine;

namespace VirtualKeyboard.Managers.InputFieldManagement.Configs
{
    /// <summary>
    ///     Interface for a config that stores reaction to an input field selection
    /// </summary>
    public interface IInputFieldSelectionConfig<in TInputFieldCommonType>
    {
        /// <summary>
        ///     TRUE is returned if a suitable input field was selected
        /// </summary>
        bool CheckIfSelected(TInputFieldCommonType selected);

        /// <summary>
        ///     Checks if the selected field supports submit
        /// </summary>
        /// <param name="selected"></param>
        /// <returns></returns>
        bool CheckIfSupportsSubmit(TInputFieldCommonType selected);

        /// <summary>
        ///     Texture to display an icon on the Submit button on the keyboard. Can be null
        /// </summary>
        Texture2D GetSubmitTexture(TInputFieldCommonType selected);

        /// <summary>
        ///     Action to type a text into the input field
        /// </summary>
        TypingDelegate<TInputFieldCommonType> TypingAction { get; }

        /// <summary>
        ///     Action to delete the last symbol(s) in the suitable input field
        /// </summary>
        FieldDelegate<TInputFieldCommonType> DeleteLastSymbolAction { get; }

        /// <summary>
        ///     Action to send submit to the input field
        /// </summary>
        FieldDelegate<TInputFieldCommonType> SubmitAction { get; }
    }

    /// <summary>
    ///     Delegate for typing in an input field
    /// </summary>
    /// /// <typeparam name="TInputFieldCommonType">Base type for the potential input field</typeparam>
    /// <param name="potentialField">Potential input field</param>
    /// <param name="text">Text to type</param>
    public delegate void TypingDelegate<in TInputFieldCommonType>(TInputFieldCommonType potentialField, string text);

    /// <summary>
    ///     General delegate for an input field
    /// </summary>
    /// /// <typeparam name="TInputFieldCommonType">Base type for the potential input field</typeparam>
    /// <param name="potentialField">Potential input field</param>
    public delegate void FieldDelegate<in TInputFieldCommonType>(TInputFieldCommonType potentialField);
}