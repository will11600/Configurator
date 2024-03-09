using System;
using UnityEngine;

namespace Configurator.Persistence.Unity.Handlers
{
    internal abstract class PersistenceHandler<T>
    {
        public abstract void Save(T value, string key);

        abstract public T Load(string key, T defaultValue);
    }
}
