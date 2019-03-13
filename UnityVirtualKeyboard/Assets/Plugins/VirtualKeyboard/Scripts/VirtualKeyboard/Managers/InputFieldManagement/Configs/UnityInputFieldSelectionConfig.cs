using System;
using UnityEngine;
using UnityEngine.UI;

namespace VirtualKeyboard.Managers.InputFieldManagement.Configs
{
    /// <summary>
    ///     Config that supports the standard Unity InputField
    /// </summary>
    [CreateAssetMenu(fileName = "UnityInputFieldSelectionConfig", menuName = "Virtual Keyboard/Management/Input Field Management/Unity InputField Selection Config"), ]
    public class UnityInputFieldSelectionConfig : ScriptableObject, IInputFieldSelectionConfig<Selectable>
    {
        public bool CheckIfSelected(Selectable selected)
        {
            return selected as InputField != null;
        }

        public bool CheckIfSupportsSubmit(Selectable selected)
        {
            return false;
        }

        public Texture2D GetSubmitTexture(Selectable selected)
        {
            return null;
        }

        public Action<Selectable, string> Type =>
            (selectable, text) =>
            {
                var inputField = selectable as InputField;
                if (inputField != null) inputField.text += text;
            };

        public Action<Selectable> DeleteLast =>
            selectable =>
            {
                var inputField = selectable as InputField;
                if (inputField != null)
                {
                    var inputFieldText = inputField.text;
                    var length = inputFieldText.Length;
                    if (length > 0) inputFieldText.Remove(length - 1);
                }
            };

        public Action<Selectable> Submit => null;
    }
}