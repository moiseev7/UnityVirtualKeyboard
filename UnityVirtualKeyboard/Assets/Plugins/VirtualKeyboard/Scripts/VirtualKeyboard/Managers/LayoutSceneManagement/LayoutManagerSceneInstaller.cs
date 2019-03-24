using Helpers.Interfaces;
using UnityEngine;
using VirtualKeyboard.Blueprints.KeyboardLayoutCollection;
using Zenject;

namespace VirtualKeyboard.Managers.LayoutSceneManagement
{
    /// <summary>
    /// Installs common data for all the layout managers
    /// </summary>
    public class LayoutManagerSceneInstaller : MonoBehaviour, IContainerizedInstaller
    {
        /// <summary>
        /// Reference to the layout collection
        /// </summary>
        [Tooltip("Reference to the layout collection")]
        [SerializeField] private KeyboardLayoutCollection _layoutCollection;

        public void InstallBindings(DiContainer Container)
        {
            Container.BindInterfacesTo<KeyboardLayoutCollection>().FromInstance(_layoutCollection).AsSingle();
        }
    }
}
