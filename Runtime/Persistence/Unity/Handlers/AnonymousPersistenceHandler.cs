using System;
using System.Reflection;

namespace Configurator.Persistence.Unity.Handlers
{
    internal class AnonymousPersistenceHandler
    {
        private object _handler;
        private MethodInfo _load;
        private MethodInfo _save;

        public readonly Type acceptType;

        public AnonymousPersistenceHandler(object handler)
        {
            _handler = handler;

            Type type = handler.GetType();
            acceptType = type.GetGenericArguments()[0];

            _load = type.GetMethod("Load");
            _save = type.GetMethod("Save");
        }

        public object Load(string key)
        {
            return _load.Invoke(_handler, new object[] { key });
        }

        public void Save(Type type, object value, string key)
        {
            _save.Invoke(_handler, new object[] { type, value, key });
        }
    }
}
