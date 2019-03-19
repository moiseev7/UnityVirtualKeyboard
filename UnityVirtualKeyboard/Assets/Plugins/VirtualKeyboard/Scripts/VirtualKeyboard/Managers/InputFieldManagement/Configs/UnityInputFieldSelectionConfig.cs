using System;
using UnityEngine;
using UnityEngine.UI;

namespace VirtualKeyboard.Managers.InputFieldManagement.Configs
{
    /// <summary>
    ///     Config that supports the standard Unity InputField
    /// </summary>
    [CreateAssetMenu(fileName = "UnityInputFieldSelectionConfig", menuName = "Virtual Keyboard/Management/Input Field Management/Unity InputField Selection Config") ]
    public class UnityInputFieldSelectionConfig : AbstractInputFieldSelectionConfig
    {
        public override bool CheckIfSelected(Selectable selected)
        {
            return selected as InputField != null;
        }

        public override bool CheckIfSupportsSubmit(Selectable selected)
        {
            return false;
        }

        public override Texture2D GetSubmitTexture(Selectable selected)
        {
            return null;
        }

        public override TypingDelegate<Selectable> TypingAction =>
            (selectable, text) =>
            {
                if (selectable == null) throw new ArgumentNullException(nameof(selectable));
                if (selectable as InputField == null) throw new ArgumentException(nameof(selectable));
                if (string.IsNullOrEmpty(text))
                    throw new ArgumentException("Value cannot be null or empty.", nameof(text));

                var inputField = (InputField) selectable;
                inputField.text += text;
            };

        public override FieldDelegate<Selectable> DeleteLastSymbolAction =>
            selectable =>
            {
                if (selectable == null) throw new ArgumentNullException(nameof(selectable));
                if (selectable as InputField == null) throw new ArgumentException(nameof(selectable));

                var inputField = (InputField) selectable;
                var inputFieldText = inputField.text;
                var length = inputFieldText.Length;
                if (length > 0)
                    inputField.text = inputFieldText.Remove(length - 1);
            };

        public override FieldDelegate<Selectable> SubmitAction => selectable =>
        {
            if (selectable == null) throw new ArgumentNullException(nameof(selectable));
            if (selectable as InputField == null) throw new ArgumentException(nameof(selectable));
        };
    }
}