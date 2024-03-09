using Configurator.Persistence.Unity.Handlers;
using Configurator.Persistence.Unity.Handlers.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Configurator.Persistence.Unity
{
    public sealed class PlayerPrefsConfigurationManager : IConfigurationManager
    {
        private static readonly Dictionary<Type, object> handlers;

        /// <summary>
        /// <para>A property to toggle strict type checking of Tunable values.</para>
        /// <para>
        /// If true, an exception will be thrown when trying to save an unsupported type.
        /// If false, the value type will fall back to the closest supported type.<br/>
        /// <see href="https://docs.unity3d.com/ScriptReference/PlayerPrefs.html">See the Unity documentation for a list of supported types.</see>
        /// </para>
        /// </summary>
        public static bool modeStrict;

        static PlayerPrefsConfigurationManager()
        {
            Type persistenceHandlerType = typeof(PersistenceHandler<>);
            handlers = new Dictionary<Type, object>();

            foreach (var type in persistenceHandlerType.Assembly.GetTypes())
            {
                if (type.IsSubclassOf(persistenceHandlerType))
                {
                    var instance = Activator.CreateInstance(type);
                    handlers.Add(type.GetGenericArguments()[0], instance);
                }
            }
        }

        private static object GetFallbackHandler(Type type)
        {
            foreach (var kvp in handlers)
            {
                FallbackAttribute[] attributes = (FallbackAttribute[])kvp.Value.GetType().GetCustomAttributes(typeof(FallbackAttribute), false);
                if (!attributes.Any(a => a.FallbackType == type)) { continue; }
                Debug.LogWarning($"PlayerPrefs does not support type {type.Name}. The value will be saved as a {kvp.Key.Name}.");
                return kvp.Value;
            }

            return null;
        }

        private static AnonymousPersistenceHandler GetHandler(Type type)
        {
            if (handlers.TryGetValue(type, out object handler))
            {
                return new AnonymousPersistenceHandler(handler);
            }

            if (modeStrict) { throw new ArgumentException($"No handler found for type {type.Name}."); }
            Debug.LogWarning($"No handler found for type {type.Name}.");

            return new AnonymousPersistenceHandler(GetFallbackHandler(type)) ?? throw new ArgumentException($"No fallback handler found for type {type.Name}.");
        }

        public object Load(Type type, string key)
        {
            var handler = GetHandler(type);
            return handler.Load(key);
        }

        public T Load<T>(string key)
        {
            return (T)Load(typeof(T), key);
        }

        public void Save(Type type, object value, string key)
        {
            var handler = GetHandler(type);
            handler.Save(type, value, key);
        }

        public void Save<T>(T value, string key)
        {
            throw new NotImplementedException();
        }
    }
}
