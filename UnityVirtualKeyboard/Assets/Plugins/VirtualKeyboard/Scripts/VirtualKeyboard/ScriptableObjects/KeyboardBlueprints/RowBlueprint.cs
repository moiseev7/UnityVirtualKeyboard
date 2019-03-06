using System.Collections.Generic;
using System.Text;
using UnityEditorInternal;
using UnityEngine;
using VirtualKeyboard.Data.Button;
#if UNITY_EDITOR
using UnityEditor;

#endif


namespace VirtualKeyboard.ScriptableObjects.KeyboardBlueprints
{
    /// <summary>
    ///     Blueprint of a keyboard row
    /// </summary>
    public class RowBlueprint : MonoBehaviour, IRowBlueprint
    {
        /// <summary>
        ///     Separator for the button name
        /// </summary>
        private const string NameSeparator = " - ";

        /// <summary>
        ///     Amount of modes supported by the row
        /// </summary>
        [SerializeField] private int _amountOfModes = 1;

        /// <summary>
        ///     Buttons of the row
        /// </summary>
        [SerializeField] private List<ButtonData> _buttons;

        /// <summary>
        ///     Amount of modes supported by the row
        /// </summary>
        public int AmountOfModes => _amountOfModes;

        #region Decoration

        private void OnValidate()
        {
            Fix();
            UpdateModesSize();
            SetButtonName();
        }

        /// <summary>
        ///     Sets names of the buttons
        /// </summary>
        private void SetButtonName()
        {
            var nameBuilder = new StringBuilder(32);
            int i;
            foreach (var button in _buttons)
            {
                i = 0;
                nameBuilder.Clear();
                foreach (var characters in button.ButtonModeCharacters)
                {
                    if (i++ > 0)
                        nameBuilder.Append(NameSeparator);

                    nameBuilder.Append(characters);
                }

                button.SetName(nameBuilder.ToString());
            }
        }

        /// <summary>
        ///     Updates modes size of the buttons
        /// </summary>
        private void UpdateModesSize()
        {
            foreach (var button in _buttons) button.SetModesAmount(_amountOfModes);
        }

        /// <summary>
        ///     Fixes the row data
        /// </summary>
        private void Fix()
        {
            _amountOfModes = Mathf.Max(1, AmountOfModes);

            foreach (var button in _buttons) button.Fix();
        }

        #endregion
    }

#if UNITY_EDITOR
    /// <summary>
    ///     Custom inspector for <see cref="RowBlueprint" />
    /// </summary>
    [CustomEditor(typeof(RowBlueprint))]
    public class RowBlueprintInspector : Editor
    {
        /// <summary>
        /// Height of the space
        /// </summary>
        private const float SpaceHeight = 10.0f;
        /// <summary>
        /// Reorderable list of the buttons
        /// </summary>
        private ReorderableList _buttonsList;

        /// <summary>
        /// Current RowBlueprint
        /// </summary>
        private RowBlueprint _rowBlueprint;

        /// <summary>
        /// Height of the line o the editor
        /// </summary>
        private float _lineHeight;

        /// <summary>
        /// Height of the line with a space in the editor
        /// </summary>
        private float _lineHeightSpace;

        void OnEnable()
        {
            if (target == null)
                return;

            _lineHeight = EditorGUIUtility.singleLineHeight;
            _lineHeightSpace = _lineHeight + SpaceHeight;

            _rowBlueprint = (RowBlueprint) target;

            _buttonsList = new ReorderableList(serializedObject, serializedObject.FindProperty("_buttons"), true, true,
                true, true);

            _buttonsList.drawElementCallback = (rect, index, active, focused) =>
            {
                var element = _buttonsList.serializedProperty.GetArrayElementAtIndex(index);

                var propertyIterator = element.Copy();

                var i = 0;
                while (propertyIterator.NextVisible(true))
                {
                    if (propertyIterator.displayName != "Size")
                    {
                        EditorGUI.PropertyField(
                            new Rect(rect.x, rect.y + _lineHeightSpace * i, rect.width, _lineHeight),
                            propertyIterator);
                        i++;
                    }
                }
            };
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            _buttonsList.DoLayoutList();
        }
    }
#endif

    /// <summary>
    ///     Interface for the keyboard row blueprint
    /// </summary>
    public interface IRowBlueprint
    {
        /// <summary>
        ///     Amount of modes supported by the row
        /// </summary>
        int AmountOfModes { get; }
    }
}