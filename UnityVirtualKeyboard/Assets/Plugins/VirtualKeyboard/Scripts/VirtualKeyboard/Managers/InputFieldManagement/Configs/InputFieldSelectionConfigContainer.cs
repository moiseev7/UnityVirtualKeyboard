using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace VirtualKeyboard.Managers.InputFieldManagement.Configs
{
    /// <summary>
    ///     Container for objects that implement<see cref="IInputFieldSelectionConfig{TInputFieldCommonType}" />
    /// </summary>
    [CreateAssetMenu(fileName = "InputFieldSelectionConfigContainer",
        menuName = "Virtual Keyboard/Management/Input Field Management/InputField Selection Config Container")]
    public class InputFieldSelectionConfigContainer : ScriptableObject, IInputFieldSelectionConfigContainer<Selectable>
    {
        [SerializeField] private List<AbstractInputFieldSelectionConfig> _configs;

        public IInputFieldSelectionConfig<Selectable> GetConfig(Selectable inputFieldCandidate)
        {
            foreach (var config in _configs)
            {
                if (config.CheckIfSelected(inputFieldCandidate))
                    return config;
            }

            return null;
        }

        /// <summary>
        /// Initializes the container (used for tests)
        /// </summary>
        /// <param name="configs">New configs</param>
        public void Initialize(List<AbstractInputFieldSelectionConfig> configs)
        {
            _configs = configs;
        }
    }
}