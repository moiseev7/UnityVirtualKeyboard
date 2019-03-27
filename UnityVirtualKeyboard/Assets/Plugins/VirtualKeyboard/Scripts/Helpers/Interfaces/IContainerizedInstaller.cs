using Zenject;

namespace Helpers.Interfaces
{
    /// <summary>
    /// Interface for a Zenject Installer with container provided
    /// </summary>
    public interface IContainerizedInstaller
    {
        /// <summary>
        /// Install bindings into the container provided as a parameter
        /// </summary>
        /// <param name="Container">Container to install bindings to</param>
        void InstallBindings(DiContainer Container);
    }
}
