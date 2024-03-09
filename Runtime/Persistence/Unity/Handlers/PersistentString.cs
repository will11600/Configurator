using System;
using UnityEngine;

namespace Configurator.Persistence.Unity.Handlers
{
    internal class PersistentString : PersistenceHandler<string>
    {
        public override string Load(string key, string defaultValue = "")
        {
            return PlayerPrefs.GetString(key, defaultValue);
        }

        public override void Save(string value, string key)
        {
            PlayerPrefs.SetString(key, value);
        }
    }
}
