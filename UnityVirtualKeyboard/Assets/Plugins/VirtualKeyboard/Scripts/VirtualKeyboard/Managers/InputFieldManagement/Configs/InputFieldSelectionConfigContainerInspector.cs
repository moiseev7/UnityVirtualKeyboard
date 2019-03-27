#if UNITY_EDITOR

using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace VirtualKeyboard.Managers.InputFieldManagement.Configs
{
    /// <summary>
    /// Custom editor for InputFieldSelectionConfigContainer
    /// </summary>
    [CustomEditor((typeof(InputFieldSelectionConfigContainer)))]
    public class InputFieldSelectionConfigContainerInspector : Editor
    {
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
        private ReorderableList _configList;

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
            _configList = new ReorderableList(serializedObject, serializedObject.FindProperty("_configs"), true, false,
                true, true);

            // Callback for drawind the elements
            _configList.drawElementCallback = (rect, index, active, focused) =>
            {
                var element = _configList.serializedProperty.GetArrayElementAtIndex(index);
                EditorGUI.PropertyField(new Rect(rect.x, rect.y, rect.width, _lineHeight), element, GUIContent.none);
            };

            _configList.elementHeightCallback = index => _lineHeightSpace * 1;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            _configList.DoLayoutList();
            serializedObject.ApplyModifiedProperties();
        }
    }
}
#endif