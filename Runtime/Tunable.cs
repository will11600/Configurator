using Configurator.Accessors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator
{
    sealed public class Tunable
    {
        public readonly string name;
        private readonly IAccessor _accessor;

        internal Tunable(IAccessor accessor, string name)
        {
            _accessor = accessor;
            this.name = name;
        }

        public object Value
        {
            get => _accessor.Value;
            set => _accessor.Value = value;
        }

        public Type Type => _accessor.Type;
    }
}
