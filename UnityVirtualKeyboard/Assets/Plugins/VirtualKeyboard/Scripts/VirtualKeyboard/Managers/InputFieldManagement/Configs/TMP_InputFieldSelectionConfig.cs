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
    public class TMP_InputFieldSelectionConfig : ScriptableObject, IInputFieldSelectionConfig<Selectable>
    {
        public bool CheckIfSelected(Selectable selected)
        {
            return selected as TMP_InputField != null;
        }

        public bool CheckIfSupportsSubmit(Selectable selected)
        {
            return false;
        }

        public Texture2D GetSubmitTexture(Selectable selected)
        {
            return null;
        }

        public TypingDelegate<Selectable> TypingAction =>
            (selectable, text) =>
            {
                if (selectable == null) throw new ArgumentNullException(nameof(selectable));
                if(selectable as TMP_InputField == null) throw new ArgumentException(nameof(selectable));
                if (string.IsNullOrEmpty(text))
                    throw new ArgumentException("Value cannot be null or empty.", nameof(text));


                var inputField = (TMP_InputField) selectable;
                inputField.text += text;
            };

        public FieldDelegate<Selectable> DeleteLastSymbolAction =>
            selectable =>
            {
                if (selectable == null) throw new ArgumentNullException(nameof(selectable));
                if (selectable as TMP_InputField == null) throw new ArgumentException(nameof(selectable));

                var inputField = (TMP_InputField) selectable;
                var inputFieldText = inputField.text;
                var length = inputFieldText.Length;
                if (length > 0) inputField.text = inputFieldText.Remove(length - 1);
            };

        public FieldDelegate<Selectable> SubmitAction => selectable =>
        {
            if (selectable == null) throw new ArgumentNullException(nameof(selectable));
            if (selectable as TMP_InputField == null) throw new ArgumentException(nameof(selectable));
        };
    }
}