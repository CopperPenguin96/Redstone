using Redstone.Core.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Redstone.Core.Registries
{
    public struct Registry
    {
        public Identifier ID { get; private set; }

        public Dictionary<Identifier, object> Entries { get; set; } = new Dictionary<Identifier, object>();

        public object this[Identifier id]
        {
            get
            {
                if (!Entries.TryGetValue(id, out object? value))
                {
                    throw new RedstoneException(new KeyNotFoundException($"The registry '{ID}' does not contain an entry with the identifier '{id}'."));
                }

                return value;
            }
        }

        public Registry(Identifier id, Dictionary<Identifier, object> entries = null!)
        {
            ID = id;
            Entries = entries ?? new Dictionary<Identifier, object>();
        }
    }
}
