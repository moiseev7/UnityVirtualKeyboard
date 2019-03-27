using System.Collections.Generic;
using UnityEngine;
using VirtualKeyboard.Blueprints.KeyboardRow;

namespace VirtualKeyboard.Blueprints.KeyboardLayout
{
    /// <summary>
    /// Blueprint of the keyboard layout
    /// </summary>
    [CreateAssetMenu(fileName = "Language - Layout", menuName = "Virtual Keyboard/Blueprints/Layout Blueprint")]
    public class LayoutBlueprint : ScriptableObject, ILayoutBlueprint
    {
        /// <summary>
        /// Name of the layout
        /// </summary>
        [SerializeField] private string _name;

        /// <summary>
        /// Amount of pages in the layout
        /// </summary>
        [SerializeField] private int _amountOfPages = 2;

        /// <summary>
        /// List of the row blueprints
        /// </summary>
        [SerializeField] private List<RowBlueprint> _rowBlueprints;

        /// <summary>
        /// List of the row blueprints
        /// </summary>
        public IEnumerable<IRowBlueprint> RowBlueprints => _rowBlueprints;

        public int AmountOfPages => _amountOfPages;

        /// <summary>
        /// Name of the layout
        /// </summary>
        public string Name => _name;

        void OnValidate()
        {
            _amountOfPages = Mathf.Max(1, AmountOfPages);
            for (var index = 0; index < _rowBlueprints.Count; index++)
            {
                var rowBlueprint = _rowBlueprints[index];
                if(rowBlueprint == null) continue;

                if (rowBlueprint.AmountOfPages != AmountOfPages)
                {
                    Debug.LogError("A row amount of modes should correspond to the layout amount of modes",
                        rowBlueprint);
                    _rowBlueprints[index] = null;
                }
            }
        }
    }
}
