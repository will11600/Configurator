using System;
using System.Reflection;

namespace Configurator.Accessors
{
    sealed internal class FieldAccessor : IAccessor
    {
        private readonly object _instance;
        private readonly FieldInfo _fieldInfo;

        public Type Type => _fieldInfo.FieldType;

        public object Value
        {
            get => _fieldInfo.GetValue(_instance);
            set => _fieldInfo.SetValue(_instance, value);
        }

        public FieldAccessor(FieldInfo fieldInfo, object instance = null)
        {
            _instance = instance;
            _fieldInfo = fieldInfo;
        }
    }
}
