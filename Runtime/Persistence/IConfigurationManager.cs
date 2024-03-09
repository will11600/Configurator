using Configurator.Accessors;
using System;

namespace Configurator.Persistence
{
    public interface IConfigurationManager
    {
        /// <summary>
        /// Saves a Tunable value to persistent storage.
        /// </summary>
        /// <param name="type">The type of the Tunable to save.</typeparam>
        /// <param name="value">The value to save.</param>
        /// <param name="key">The key to save the value under.</param>
        public void Save(Type type, object value, string key);

        /// <summary>
        /// Saves a Tunable value to persistent storage.
        /// </summary>
        /// <typeparam name="T">The type of the Tunable to save.</typeparam>
        /// <param name="value">The value to save.</param>
        /// <param name="key">The key to save the value under.</param>
        public void Save<T>(T value, string key);

        /// <summary>
        /// Loads a Tunable value from persistent storage.
        /// </summary>
        /// <param name="type">The type of the Tunable to load.</param>
        /// <param name="key">The key of the Tunable to load.</param>
        /// <returns></returns>
        public object Load(Type type, string key);

        /// <summary>
        /// Loads a Tunable value from persistent storage.
        /// </summary>
        /// <typeparam name="T">The type of the Tunable to load.</param>
        /// <param name="key">The key of the Tunable to load.</param>
        /// <returns></returns>
        public T Load<T>(string key);
    }
}
