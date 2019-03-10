using System.Collections.Generic;
using UnityEngine;
using VirtualKeyboard.Scripts.VirtualKeyboard.Blueprints.KeyboardRow;

namespace VirtualKeyboard.Scripts.VirtualKeyboard.Blueprints.KeyboardLayout
{
    /// <summary>
    /// Blueprint of the keyboard layout
    /// </summary>
    [CreateAssetMenu(fileName = "Language - Layout", menuName = "Virtual Keyboard/Blueprints/Layout Blueprint")]
    public class LayoutBlueprint : ScriptableObject, ILayoutBlueprint
    {
        [SerializeField] private int _amountOfModes = 1;

        /// <summary>
        /// List of the row blueprints
        /// </summary>
        [SerializeField] private List<RowBlueprint> _rowBlueprints;

        /// <summary>
        /// List of the row blueprints
        /// </summary>
        public IEnumerable<IRowBlueprint> RowBlueprints => _rowBlueprints;

        void OnValidate()
        {
            _amountOfModes = Mathf.Max(1, _amountOfModes);
            for (var index = 0; index < _rowBlueprints.Count; index++)
            {
                var rowBlueprint = _rowBlueprints[index];
                if(rowBlueprint == null) continue;

                if (rowBlueprint.AmountOfModes != _amountOfModes)
                {
                    Debug.LogError("A row amount of modes should correspond to the layout amount of modes",
                        rowBlueprint);
                    _rowBlueprints[index] = null;
                }
            }
        }
    }

    public interface ILayoutBlueprint
    {
        /// <summary>
        /// List of the row blueprints
        /// </summary>
        IEnumerable<IRowBlueprint> RowBlueprints { get; }
    }
}
