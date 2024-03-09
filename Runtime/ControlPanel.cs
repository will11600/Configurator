using Configurator.Accessors;
using Configurator.Attributes;
using Configurator.Persistence;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Configurator
{
    public class ControlPanel : MonoBehaviour
    {
        public delegate void TunableDelegate(Tunable value);
        public delegate void ControlPanelDelegate();

        private static Dictionary<string, IAccessor> _accessors;

        /// <summary>
        /// An event that is triggered when a tunable value is changed.
        /// </summary>
        public static event TunableDelegate OnChange;

        /// <summary>
        /// An event that is triggered when the tunable values are loaded from persistent storage.
        /// </summary>
        public static event ControlPanelDelegate OnLoad;

        /// <summary>
        /// An event that is triggered when the tunable values are saved to persistent storage.
        /// </summary>
        public static event ControlPanelDelegate OnSave;

        // Defining static properties to control some basic global game settings

        [Tunable("fullscreen")]
        public static bool FullScreen
        {
            get => Screen.fullScreen;
            set => Screen.fullScreen = value;
        }

        [Tunable("resolutionX")]
        public static int ResolutionX
        {
            get => Screen.width;
            set => Screen.SetResolution(value, Screen.height, Screen.fullScreen);
        }

        [Tunable("resolutionY")]
        public static int ResolutionY
        {
            get => Screen.height;
            set => Screen.SetResolution(Screen.width, value, Screen.fullScreen);
        }

        static ControlPanel()
        {
            _accessors = new Dictionary<string, IAccessor>();
            RegisterAccessors();
        }

        private static MemberInfo[] GetMembers(Type type, BindingFlags bindingFlags = BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public)
        {
            return type.GetMembers(bindingFlags);
        }

        private static bool TryGetTunableAttribute(MemberInfo member, out TunableAttribute attribute)
        {
            foreach (var attr in member.GetCustomAttributes())
            {
                if (!(attr is TunableAttribute)) { continue; }

                attribute = (TunableAttribute)attr;
                return true;
            }

            attribute = default;
            return false;
        }

        private static IAccessor CreateAccessor(MemberInfo member, TunableAttribute attribute)
        {
            if (member is FieldInfo field)
            {
                return new FieldAccessor(field);
            }
            else if (member is PropertyInfo property)
            {
                return new PropertyAccessor(property);
            }

            throw new ArgumentException("Member is not a field or property");
        }

        private static void RegisterAccessors()
        {
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();

            foreach (Type type in types)
            {
                foreach (MemberInfo member in GetMembers(type))
                {
                    if (!TryGetTunableAttribute(member, out var attribute)) { continue; }
                    _accessors.Add(attribute.label, CreateAccessor(member, attribute));
                }
            }
        }

        private static IAccessor GetAccessor<T>(string key)
        {
            if (!_accessors.TryGetValue(key, out var accessor)) { throw new KeyNotFoundException($"No tunable with key {key} exists"); }
            if (typeof(T) != accessor.Type) { throw new ArgumentException($"Type mismatch for key {key}"); }
            return accessor;
        }

        /// <summary>
        /// Get the value of a tunable with the specified key.
        /// </summary>
        /// <typeparam name="T">The type of the tunable value.</typeparam>
        /// <param name="key">The key of the tunable value.</param>
        /// <returns>The value of the tunable.</returns>
        public static T GetValue<T>(string key)
        {
            IAccessor accessor = GetAccessor<T>(key);
            return (T)accessor.Value;
        }

        /// <summary>
        /// Set the value of a tunable with the specified key.
        /// </summary>
        /// <typeparam name="T">The type of the tunable value.</typeparam>
        /// <param name="key">The key of the tunable value.</param>
        /// <param name="value">The value of the tunable.</param>
        /// <param name="notify">Whether to notify listeners of the change.</param>
        public static void SetValue<T>(string key, T value, bool notify = true)
        {
            IAccessor accessor = GetAccessor<T>(key);
            accessor.Value = value;
            if (notify) { OnChange?.Invoke(new Tunable(accessor, key)); }
        }

        /// <summary>
        /// Save all tunables to persistent storage, using the specified configuration manager.
        /// </summary>
        /// <typeparam name="T">The configuration manager to use.</typeparam>
        public static void Save<T>() where T : IConfigurationManager, new()
        {
            T manager = new T();
            foreach (var kvp in _accessors)
            {
                manager.Save(kvp.Value, kvp.Key);
            }
            OnSave?.Invoke();
        }

        /// <summary>
        /// Load all tunables from persistent storage, using the specified configuration manager.
        /// </summary>
        /// <typeparam name="T">The configuration manager to use.</typeparam>
        public static void Load<T>() where T : IConfigurationManager, new()
        {
            T manager = new T();
            foreach (var kvp in _accessors)
            {
                kvp.Value.Value = manager.Load(kvp.Value.Type, kvp.Key);
            }
            OnLoad?.Invoke();
        }
    }
}
