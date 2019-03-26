using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using VirtualKeyboard.Objects.Button.Controllers.SizeController;
using VirtualKeyboard.Objects.Row.Managers.ButtonsManagement;
using Zenject;

namespace VirtualKeyboard.Objects.Button
{
    /// <summary>
    /// Root object for the virtual keyboard button prefab
    /// </summary>
    public class VirtualKeyboardButtonObject : MonoBehaviour
    {
        [Inject(Id = "VirtualKeyboardButtonObject - Text Meshes")]
        private List<TextMeshProUGUI> _textMeshes;

        /// <summary>
        /// Injection of the button size controller
        /// </summary>
        [Inject] private IButtonObjectSizeController _buttonObjectSizeController;

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
            gameObject.SetActive(false);
        }

        private void Reinitialize(IButtonsParameters parameters)
        {
            gameObject.SetActive(true);
            transform.SetParent(parameters.ButtonParent);
            transform.SetAsLastSibling();
            foreach (var textMesh in _textMeshes)
            {
                if(textMesh != null)
                    textMesh.text = parameters.ButtonData.ButtonPageCharacters.ToList()[parameters.Page];
            }

            _buttonObjectSizeController.SetSize(parameters.ButtonData.ButtonHorizontalSize);
        }

    
    }
}
