﻿using UnityEngine;
using VirtualKeyboard.Scripts.Helpers.Interfaces;
using VirtualKeyboard.Scripts.VirtualKeyboard.Styles.ButtonStyle;
using Zenject;

namespace VirtualKeyboard.Scripts.VirtualKeyboard.Styles
{
    /// <summary>
    /// Installer for the keyboard styles
    /// </summary>
    public class StylesInstaller : MonoBehaviour, IContainerizedInstaller
    {
        /// <summary>
        /// Reference to a button style scene installer
        /// </summary>
        [SerializeField]
        [Tooltip("Reference to a button style scene installer")]
        private AbstractButtonStyleSceneInstaller _buttonStyleSceneInstaller;

        public void InstallBindings(DiContainer Container)
        {
            _buttonStyleSceneInstaller.InstallBindings(Container);
        }
    }
}
