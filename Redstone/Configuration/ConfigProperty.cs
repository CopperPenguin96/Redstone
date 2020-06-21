using System;

namespace Redstone.Configuration
{
	public class ConfigProperty<T>
	{
		public string Name { get; set; }

		public string Description { get; set; }

		private T _value;
		public virtual T Value
		{
			get => _value == null ? DefaultValue : _value;
			set => _value = value == null ? DefaultValue : value;
		}

		public virtual T DefaultValue { get; set; }

		public void SetDefault()
		{
			Value = DefaultValue;
		}

		public ConfigProperty(string name, string description, T defValue)
		{
			Name = name;
			Description = description;
			DefaultValue = defValue;
		}
	}

	public class ConfigBool : ConfigProperty<bool>
	{
		public override bool Value { get; set; }

		public override bool DefaultValue { get; set; }

		public ConfigBool(string name, string description, bool defValue) : base(name, description, defValue)
		{
			
		}
	}

	public class ConfigInt : ConfigProperty<int>
	{
		public int Min = -1;
		public int Max = -1;

		public bool MinSet = false;
		public bool MaxSet = false;

		public void SetMin(int min)
		{
			Min = min;
			MinSet = true;
		}

		public void SetMax(int max)
		{
			Max = max;
			MaxSet = true;
		}

		public void SetMinMax(int min, int max)
		{
			SetMin(min);
			SetMax(max);
		}

		public ConfigInt(string name, string description, int defValue) : base(name, description, defValue)
		{
		}

		public ConfigInt(string name, string description, int defValue, int minMax, bool isMax = true) : this(name, description, defValue)
		{
			if (isMax) SetMax(minMax);
			else SetMin(minMax);
		}

		public ConfigInt(string name, string description, int defValue, int min, int max) : this(name, description,
			defValue)
		{
			SetMinMax(min, max);
		}
	}

	public class ConfigString : ConfigProperty<string>
	{
		public int MinLength = -1;
		public int MaxLength = -1;

		public bool MinSet = false;
		public bool MaxSet = false;

		public void SetMin(int min)
		{
			MinLength = min;
			MinSet = true;
		}

		public void SetMax(int max)
		{
			MaxLength = max;
			MaxSet = true;
		}

		public void SetMinMax(int min, int max)
		{
			SetMin(min);
			SetMax(max);
		}

		public ConfigString(string name, string description, string defValue) : base(name, description, defValue)
		{
		}

		public ConfigString(string name, string description, string defValue, int minMax, bool isMax = true) : this(name, description, defValue)
		{
			if (isMax) SetMax(minMax);
			else SetMin(minMax);
		}

		public ConfigString(string name, string description, string defValue, int min, int max) : this(name, description,
			defValue)
		{
			SetMinMax(min, max);
		}
	}

}
