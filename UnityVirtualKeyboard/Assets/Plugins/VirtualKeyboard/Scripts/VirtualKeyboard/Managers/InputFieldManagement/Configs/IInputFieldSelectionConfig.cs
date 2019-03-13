using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace VirtualKeyboard.Managers.InputFieldManagement.Configs
{
    /// <summary>
    /// Interface for a config that stores reaction to an input field selection
    /// </summary>
    public interface IInputFieldSelectionConfig<in TInputFieldCommonType>
    {
        /// <summary>
        /// TRUE is returned if a suitable input field was selected
        /// </summary>
        bool CheckIfSelected(TInputFieldCommonType selected);

        /// <summary>
        /// Checks if the selected field supports submit
        /// </summary>
        /// <param name="selected"></param>
        /// <returns></returns>
        bool CheckIfSupportsSubmit(TInputFieldCommonType selected);

        /// <summary>
        /// Texture to display an icon on the Submit button on the keyboard. Can be null
        /// </summary>
        Texture2D GetSubmitTexture(TInputFieldCommonType selected);

        /// <summary>
        /// Action to type a text into the input field
        /// </summary>
        Action<TInputFieldCommonType, string> Type { get; }

        /// <summary>
        /// Action to delete the last symbol(s) in the suitable input field
        /// </summary>
        Action<TInputFieldCommonType> DeleteLast { get; }

        /// <summary>
        /// Action to send submit to the input field
        /// </summary>
        [CanBeNull] Action<TInputFieldCommonType> Submit { get; }
    }

   
}
