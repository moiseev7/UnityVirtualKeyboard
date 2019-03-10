#if UNITY_EDITOR
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace VirtualKeyboard.Scripts.VirtualKeyboard.Blueprints.KeyboardRow
{
    /// <summary>
    ///     Custom inspector for <see cref="VirtualKeyboard.ScriptableObjects.Blueprints.KeyboardRow.RowBlueprint" />
    /// </summary>
    [CustomEditor(typeof(RowBlueprint))]
    public class RowBlueprintInspector : Editor
    {
        #region Editor code

        /// <summary>
        ///     Size of the space
        /// </summary>
        private const float SpaceSize = 10.0f;

        /// <summary>
        ///     Max width of the mode field
        /// </summary>
        private const float ModeFieldMaxWidth = 50.0f;

        /// <summary>
        ///     Reorderable list of the buttons
        /// </summary>
        private ReorderableList _buttonsList;

        /// <summary>
        ///     Height of the line o the editor
        /// </summary>
        private float _lineHeight;

        /// <summary>
        ///     Height of the line with a space in the editor
        /// </summary>
        private float _lineHeightSpace;

        

        private void OnEnable()
        {
            if (target == null)
                return;

            // Update line heights
            _lineHeight = EditorGUIUtility.singleLineHeight;
            _lineHeightSpace = _lineHeight + SpaceSize;

            //Create list
            _buttonsList = new ReorderableList(serializedObject, serializedObject.FindProperty("_buttons"), true, false,
                true, true);

            // Callback for drawind the elements
            _buttonsList.drawElementCallback = (rect, index, active, focused) =>
            {
                // Draw border
                EditorGUI.DrawRect(new Rect(rect.x - 18, rect.y, rect.width + 22, 1), Color.gray);

                // Y position of the current line in the list element
                var yPosition = 0;

                var element = _buttonsList.serializedProperty.GetArrayElementAtIndex(index);

                //Draw Modes label
                EditorGUI.LabelField(new Rect(rect.x, rect.y + yPosition * _lineHeightSpace, rect.width, _lineHeight),
                    "Mode characters:");
                yPosition++;

                // Draw modes PropertyFields
                var characters = element.FindPropertyRelative("_buttonModeCharacters");
                var amountOfModes = characters.arraySize;
                var step = Mathf.Min((rect.width - SpaceSize * (amountOfModes - 1)) / amountOfModes,
                    ModeFieldMaxWidth);
                var stepSpace = step + SpaceSize;
                for (var i = 0; i < amountOfModes; i++)
                    EditorGUI.PropertyField(
                        new Rect(rect.x + stepSpace * i, rect.y + yPosition * _lineHeightSpace, step, _lineHeight),
                        characters.GetArrayElementAtIndex(i), GUIContent.none);

                yPosition++;

                // Draw horizontal size property
                var size = element.FindPropertyRelative("_buttonHorizontalSize");
                EditorGUI.PropertyField(
                    new Rect(rect.x, rect.y + yPosition * _lineHeightSpace, rect.width, _lineHeight),
                    size);
            };

            _buttonsList.elementHeightCallback = index => _lineHeightSpace * 3;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(serializedObject.FindProperty("_amountOfModes"));
            
            
            _buttonsList.DoLayoutList();
            serializedObject.ApplyModifiedProperties();
        }

        #endregion
    }
}
#endif