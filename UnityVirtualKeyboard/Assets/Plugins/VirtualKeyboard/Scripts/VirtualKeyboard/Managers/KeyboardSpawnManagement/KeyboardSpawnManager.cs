using System;
using System.Collections.Generic;
using VirtualKeyboard.Objects.Keyboard;
using Zenject;

namespace VirtualKeyboard.Managers.KeyboardSpawnManagement
{
    /// <summary>
    /// Spawns an instance of the virtual keyboard
    /// </summary>
    public class KeyboardSpawnManager : IInitializable, IDisposable
    {
        /// <summary>
        /// Injection of the keyboard pool
        /// </summary>
        [Inject] private VirtualKeyboardObject.Pool _pool;

        /// <summary>
        /// Injection of the spawn config
        /// </summary>
        [Inject] private IKeyboardSpawnManagerConfig _keyboardSpawnManagerConfig;

        /// <summary>
        /// List of the spawned objects
        /// </summary>
        private List<VirtualKeyboardObject> _spawnedObjects = new List<VirtualKeyboardObject>();

        public void Initialize()
        {
            var virtualKeyboardObject = _pool.Spawn();
            virtualKeyboardObject.name = _keyboardSpawnManagerConfig.KeyboardObjectName;
            _spawnedObjects.Add(virtualKeyboardObject);
        }

        public void Dispose()
        {
            foreach (var keyboardObject in _spawnedObjects.AsReadOnly())
            {
                if( keyboardObject!= null)
                    _pool.Despawn(keyboardObject);
            }

            _spawnedObjects.Clear();
        }
    }
}
