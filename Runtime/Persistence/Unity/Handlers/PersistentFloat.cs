using Configurator.Persistence.Unity.Handlers.Attributes;
using UnityEngine;

namespace Configurator.Persistence.Unity.Handlers
{
    [Fallback(typeof(double))]
    [Fallback(typeof(decimal))]
    internal class PersistentFloat : PersistenceHandler<float>
    {
        public override void Save(float value, string key)
        {
            PlayerPrefs.SetFloat(key, value);
        }

        public override float Load(string key, float defaultValue)
        {
            return PlayerPrefs.GetFloat(key, defaultValue);
        }
    }
}
