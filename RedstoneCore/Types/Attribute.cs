using Redstone.Core.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Nodes;

namespace Redstone.Core.Types
{
    public struct Attribute : IJsonProvider
    {
        public string Name { get; private set; }

        public Identifier Resource { get; private set; }

        public double Min { get; set; }

        public double Max { get; set; }

        public double Default { get; set; }

        public Attribute(string name, Identifier resource, double defaultValue)
        {
            Name = name;
            Resource = resource;
            Default = defaultValue;
        }

        public Attribute(string json)
        {
            FromJson(json);
        }

        public void FromJson(string json)
        {
            JsonObject obj = JsonNode.Parse(json)!.AsObject();
            Name = obj["name"]!.GetValue<string>();
            Resource = new Identifier(obj["attribute"]!.GetValue<string>());
            Min = obj["min"]!.GetValue<double>();
            Max = obj["max"]!.GetValue<double>();
            Default = obj["default"]!.GetValue<double>();
        }

        public readonly string JsonString()
        {
            JsonObject obj = new()
            {
                ["name"] = Name,
                ["attribute"] = Resource.ToString(),
                ["min"] = Min,
                ["max"] = Max,
                ["default"] = Default
            };

            return obj.ToString();
        }


    }
}
