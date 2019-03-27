using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace VirtualKeyboard.Objects.Button
{
    public class VirtualKeyboardButtonObjectInstaller : MonoInstaller
    {
        /// <summary>
        /// References to the text meshes of the button
        /// </summary>
        [SerializeField] private List<TextMeshProUGUI> _textMeshes;
        
        public override void InstallBindings()
        {
            Container.Bind<List<TextMeshProUGUI>>().WithId("VirtualKeyboardButtonObject - Text Meshes")
                .FromInstance(_textMeshes).AsCached();
        }
    }
}
