using System;

namespace Configurator.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class TunableAttribute : Attribute
    {
        public string label;

        public TunableAttribute(string settingLabel = "")
        {
            label = settingLabel;
        }
    }
}
