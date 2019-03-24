using Helpers.Interfaces;
using UnityEngine;
using Zenject;

namespace VirtualKeyboard.Objects.Keyboard.Managers.LayoutManagement
{
    /// <summary>
    /// Object-specific installer for layout manager
    /// </summary>
    public class LayoutManagerObjectInstaller : MonoBehaviour, IContainerizedInstaller
    {
        /// <summary>
        /// Reference to the panel parameters related to the letters layout
        /// </summary>
        [Tooltip("Reference to the panel parameters related to the letters layout")]
        [SerializeField] private LayoutPanelParameters _lettersPanelParameters;

        /// <summary>
        /// Reference to the panel parameters related to the symbols layout
        /// </summary>
        [Tooltip("Reference to the panel parameters related to the symbols layout")]
        [SerializeField] private LayoutPanelParameters _symbolsPanelParameters;

        /// <summary>
        /// Reference to the panel parameters related to the digits layout
        /// </summary>
        [Tooltip("Reference to the panel parameters related to the digits layout")]
        [SerializeField] private LayoutPanelParameters _digitsPanelParameters;


        public void InstallBindings(DiContainer Container)
        {
            Container.Bind<ILayoutPanelParameters>().WithId("LayoutManager - Letters Panel Parameters")
                .FromInstance(_lettersPanelParameters).AsCached();

            Container.Bind<ILayoutPanelParameters>().WithId("LayoutManager - Symbols Panel Parameters")
                .FromInstance(_symbolsPanelParameters).AsCached();

            Container.Bind<ILayoutPanelParameters>().WithId("LayoutManager - Digits Panel Parameters")
                .FromInstance(_digitsPanelParameters).AsCached();

            Container.BindInterfacesTo<LayoutManager>().FromNew().AsSingle().NonLazy();
        }
    }
}