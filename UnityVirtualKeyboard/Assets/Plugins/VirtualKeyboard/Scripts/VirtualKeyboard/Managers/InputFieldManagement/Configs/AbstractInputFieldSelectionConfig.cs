using UnityEngine;
using UnityEngine.UI;

namespace VirtualKeyboard.Managers.InputFieldManagement.Configs
{
    public abstract class AbstractInputFieldSelectionConfig : ScriptableObject, IInputFieldSelectionConfig<Selectable>
    {
        public abstract bool CheckIfSelected(Selectable selected);

        public abstract bool CheckIfSupportsSubmit(Selectable selected);

        public abstract Texture2D GetSubmitTexture(Selectable selected);

        public abstract TypingDelegate<Selectable> TypingAction { get; }
        public abstract FieldDelegate<Selectable> DeleteLastSymbolAction { get; }
        public abstract FieldDelegate<Selectable> SubmitAction { get; }
    }
}