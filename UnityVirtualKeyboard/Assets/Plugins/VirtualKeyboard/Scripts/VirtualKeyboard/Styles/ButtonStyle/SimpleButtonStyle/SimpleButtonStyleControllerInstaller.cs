using UnityEngine;

namespace VirtualKeyboard.Scripts.VirtualKeyboard.Styles.ButtonStyle.SimpleButtonStyle
{
    public class SimpleButtonStyleControllerInstaller : ButtonStyleControllerInstaller<SimpleButtonStyleElement>
    {
        [SerializeField] private SimpleButtonStyleObjectReferencesContainer _referencesContainer;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<SimpleButtonStyleObjectReferencesContainer>().FromInstance(_referencesContainer)
                .AsSingle();
            base.InstallBindings();
        }
    }
}
