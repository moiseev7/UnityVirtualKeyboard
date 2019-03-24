#if UNITY_EDITOR
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using VirtualKeyboard.Blueprints.KeyboardLayout;


namespace VirtualKeyboard.Blueprints.KeyboardLayoutCollection
{
    [CustomEditor(typeof(KeyboardLayoutCollection))]
    public class KeyboardLayoutCollectionInspector : Editor
    {
        /// <summary>
        ///     Size of the space
        /// </summary>
        private const float SpaceSize = 10.0f;

        /// <summary>
        ///     Reorderable list of the buttons
        /// </summary>
        private ReorderableList _languagesList;

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
            _languagesList = new ReorderableList(serializedObject, serializedObject.FindProperty("_languages"), true, false,
                true, true);

            // Callback for drawing the elements
            _languagesList.drawElementCallback = (rect, index, active, focused) =>
            {
                var element = _languagesList.serializedProperty.GetArrayElementAtIndex(index);
                EditorGUI.PropertyField(new Rect(rect.x, rect.y, rect.width, _lineHeight), element, GUIContent.none);
            };

            _languagesList.elementHeightCallback = index => _lineHeightSpace;
        }


        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.LabelField("Languages: ");
            _languagesList.DoLayoutList();

            EditorGUILayout.PropertyField(serializedObject.FindProperty("_symbols"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("_digits"));
            serializedObject.ApplyModifiedProperties();
        }
    }
}
#endif