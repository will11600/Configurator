using System;
using UnityEngine;

namespace Configurator.Persistence.Unity.Handlers
{
    internal class PersistentBoolean : PersistenceHandler<bool>
    {
        public override void Save(bool value, string key)
        {
            PlayerPrefs.SetInt(key, value ? 1 : 0);
        }

        public override bool Load(string key, bool defaultValue = false)
        {
            return PlayerPrefs.GetInt(key, defaultValue ? 1 : 0) == 1;
        }
    }
}
