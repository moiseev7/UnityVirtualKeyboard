﻿using System;
using System.Reflection;
using UnityEngine;

namespace Helpers.Components
{
    /// <summary>
    /// Helper for components
    /// </summary>
    public static class ComponentHelper 
    {
        /// <summary>
        /// Copies component's values
        /// </summary>
        /// <typeparam name="T">Component type</typeparam>
        /// <param name="comp">Destination</param>
        /// <param name="other">Source</param>
        /// <returns></returns>
        public static T GetCopyOf<T>(this Component comp, T other) where T : Component
        {
            Type type = comp.GetType();
            if (type != other.GetType()) return null; // type mis-match
            BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Default | BindingFlags.DeclaredOnly;
            PropertyInfo[] pinfos = type.GetProperties(flags);
            foreach (var pinfo in pinfos)
            {
                if (pinfo.CanWrite)
                {
                    try
                    {
                        pinfo.SetValue(comp, pinfo.GetValue(other, null), null);
                    }
                    catch { } // In case of NotImplementedException being thrown. For some reason specifying that exception didn't seem to catch it, so I didn't catch anything specific.
                }
            }
            FieldInfo[] finfos = type.GetFields(flags);
            foreach (var finfo in finfos)
            {
                finfo.SetValue(comp, finfo.GetValue(other));
            }
            return comp as T;
        }

        /// <summary>
        /// Adds a component by copying it
        /// </summary>
        /// <typeparam name="T">Type of the component</typeparam>
        /// <param name="go">Destination</param>
        /// <param name="toAdd">Source</param>
        /// <returns></returns>
        public static T AddComponent<T>(this GameObject go, T toAdd) where T : Component
        {
            return go.AddComponent<T>().GetCopyOf(toAdd) as T;
        }
    }
}
