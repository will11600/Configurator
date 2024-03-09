using System;
using System.Reflection;

namespace Configurator.Accessors
{
    sealed internal class PropertyAccessor : IAccessor
    {
        private readonly object _instance;
        private readonly PropertyInfo _propertyInfo;

        public Type Type => _propertyInfo.PropertyType;

        public object Value
        {
            get => _propertyInfo.GetValue(_instance);
            set => _propertyInfo.SetValue(_instance, value);
        }

        public PropertyAccessor(PropertyInfo propertyInfo, object instance = null)
        {
            _instance = instance;
            _propertyInfo = propertyInfo;
        }
    }
}
