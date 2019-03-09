#if UNITY_EDITOR
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace VirtualKeyboard.ScriptableObjects.Blueprints.KeyboardLayout
{
    [CustomEditor(typeof(LayoutBlueprint))]
    public class LayoutBlueprintInspector : Editor
    {
        /// <summary>
        ///     Size of the space
        /// </summary>
        private const float SpaceSize = 10.0f;

        /// <summary>
        ///     Reorderable list of the buttons
        /// </summary>
        private ReorderableList _rowsList;

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
            _rowsList = new ReorderableList(serializedObject, serializedObject.FindProperty("_rowBlueprints"), true, false,
                true, true);

            // Callback for drawing the elements
            _rowsList.drawElementCallback = (rect, index, active, focused) =>
            {
                var element = _rowsList.serializedProperty.GetArrayElementAtIndex(index);
                EditorGUI.PropertyField(new Rect(rect.x, rect.y, rect.width, _lineHeight), element, GUIContent.none);
            };

            _rowsList.elementHeightCallback = index => _lineHeightSpace;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(serializedObject.FindProperty("_amountOfModes"));

            _rowsList.DoLayoutList();
            serializedObject.ApplyModifiedProperties();
        }
    }
}
#endif