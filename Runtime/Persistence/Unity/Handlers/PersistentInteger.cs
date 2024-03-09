using Configurator.Persistence.Unity.Handlers.Attributes;
using UnityEngine;

namespace Configurator.Persistence.Unity.Handlers
{
    [Fallback(typeof(long))]
    [Fallback(typeof(byte))]
    [Fallback(typeof(short))]
    [Fallback(typeof(uint))]
    [Fallback(typeof(ushort))]
    [Fallback(typeof(ulong))]
    [Fallback(typeof(sbyte))]
    internal class PersistentInteger : PersistenceHandler<int>
    {
        public override int Load(string key, int defaultValue = -1)
        {
            return PlayerPrefs.GetInt(key, defaultValue);
        }

        public override void Save(int value, string key)
        {
            PlayerPrefs.SetInt(key, value);
        }
    }
}
