using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace VirtualKeyboard.Managers.InputFieldManagement.Configs
{
    /// <summary>
    /// Config that supports TextMeshPro input field
    /// </summary>
    [CreateAssetMenu(fileName = "TMP_InputFieldSelectionConfig", menuName = "Virtual Keyboard/Management/Input Field Management/TMP_InputField Selection Config")]
    public class TMP_InputFieldSelectionConfig : AbstractInputFieldSelectionConfig
    {
        public override bool CheckIfSelected(Selectable selected)
        {
            return selected as TMP_InputField != null;
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
                if(selectable as TMP_InputField == null) throw new ArgumentException(nameof(selectable));
                if (string.IsNullOrEmpty(text))
                    throw new ArgumentException("Value cannot be null or empty.", nameof(text));


                var inputField = (TMP_InputField) selectable;
                inputField.text += text;
            };

        public override FieldDelegate<Selectable> DeleteLastSymbolAction =>
            selectable =>
            {
                if (selectable == null) throw new ArgumentNullException(nameof(selectable));
                if (selectable as TMP_InputField == null) throw new ArgumentException(nameof(selectable));

                var inputField = (TMP_InputField) selectable;
                var inputFieldText = inputField.text;
                var length = inputFieldText.Length;
                if (length > 0) inputField.text = inputFieldText.Remove(length - 1);
            };

        public override FieldDelegate<Selectable> SubmitAction => selectable =>
        {
            if (selectable == null) throw new ArgumentNullException(nameof(selectable));
            if (selectable as TMP_InputField == null) throw new ArgumentException(nameof(selectable));
        };
    }
}