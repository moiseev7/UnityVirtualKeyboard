using UnityEngine;
using VirtualKeyboard.Scripts.Helpers.Interfaces;
using Zenject;

namespace VirtualKeyboard.Scripts.VirtualKeyboard.Styles.ButtonStyle
{
    /// <summary>
    /// Base class for all the button style scene installers
    /// </summary>
    public abstract class AbstractButtonStyleSceneInstaller : MonoBehaviour, IContainerizedInstaller
    {
        public abstract void InstallBindings(DiContainer Container);
    }
}
