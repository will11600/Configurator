using System;

namespace Configurator.Persistence.Unity.Handlers.Attributes
{
    /// <summary>
    /// Attribute to specify fallback types for a persistence handler.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    internal class FallbackAttribute : Attribute
    {
        public Type FallbackType { get; private set; }

        public FallbackAttribute(Type fallbackType)
        {
            FallbackType = fallbackType;
        }
    }
}
