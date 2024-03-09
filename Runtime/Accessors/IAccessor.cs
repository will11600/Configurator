using System;

namespace Configurator.Accessors
{
    internal interface IAccessor
    {
        public Type Type { get; }
        public object Value { get; set; }
    }
}
