using UnityEngine;
using VirtualKeyboard.Objects.Keyboard.Managers.RowsManagement;
using Zenject;

namespace VirtualKeyboard.Objects.Row
{
    /// <summary>
    /// Root object for the virtual keyboard row prefab
    /// </summary>
    public class VirtualKeyboardRowObject : MonoBehaviour
    {
        /// <summary>
        /// Injection of the default pool parent
        /// </summary>
        [Inject(Id = "RowsManager - Pool Parent Transform")]
        private Transform _poolParent;


        public class Pool : MonoMemoryPool<IRowParameters, VirtualKeyboardRowObject>
        {
            protected override void Reinitialize(IRowParameters parameters, VirtualKeyboardRowObject item)
            {
                item.Reinitialize(parameters);
            }

            protected override void OnDespawned(VirtualKeyboardRowObject item)
            {
                item.OnDespawned();
            }
        }

        private void OnDespawned()
        {
            transform?.SetParent(_poolParent);
        }

        private void Reinitialize(IRowParameters parameters)
        {
            transform?.SetParent(parameters.RowsParent);
            transform?.SetAsLastSibling();
            SpawnButtons();
        }

        private void SpawnButtons()
        {
            
        }
    }
}
