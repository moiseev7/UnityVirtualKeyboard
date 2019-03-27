using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VirtualKeyboard.Objects.Button;
using Zenject;

namespace VirtualKeyboard.Objects.Row.Managers.ButtonsManagement
{
    /// <summary>
    /// Manager for the keyboard buttons
    /// </summary>
    public class ButtonsManager : IButtonsManager
    {
        /// <summary>
        /// Injection of the default parent for the buttons
        /// </summary>
        [Inject(Id = "ButtonsPool - Default Parent")] private Transform _defaultParent;

        [Inject] private VirtualKeyboardButtonObject.Pool _pool;

        /// <summary>
        /// List of the spawned buttons
        /// </summary>
        private List<VirtualKeyboardButtonObject> _spawned = new List<VirtualKeyboardButtonObject>();

        public void Reset()
        {
            foreach (var buttonObject in _spawned.ToList())
            {
                _pool.Despawn(buttonObject);
                buttonObject.transform.SetParent(_defaultParent);
            }

            _spawned.Clear();
        }

        public void AddButton(IButtonsParameters buttonsParameters)
        {
            _spawned.Add(_pool.Spawn(buttonsParameters));

        }
    }
}
