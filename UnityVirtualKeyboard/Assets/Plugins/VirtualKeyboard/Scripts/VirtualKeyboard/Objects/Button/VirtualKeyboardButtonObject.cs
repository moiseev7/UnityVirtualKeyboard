using UnityEngine;
using VirtualKeyboard.Objects.Row.Managers.ButtonsManagement;
using Zenject;

namespace VirtualKeyboard.Objects.Button
{
    /// <summary>
    /// Root object for the virtual keyboard button prefab
    /// </summary>
    public class VirtualKeyboardButtonObject : MonoBehaviour
    {

        public class Pool : MonoMemoryPool<IButtonsParameters, VirtualKeyboardButtonObject>
        {
            protected override void Reinitialize(IButtonsParameters parameters, VirtualKeyboardButtonObject item)
            {
                item.Reinitialize(parameters);
            }

            protected override void OnDespawned(VirtualKeyboardButtonObject item)
            {
                item.OnDespawned();
            }
        }

        private void OnDespawned()
        {
        
        }

        private void Reinitialize(IButtonsParameters parameters)
        {
    
        }

    
    }
}
