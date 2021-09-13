using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;
using Redstone.Utils;

namespace Redstone.Configuration
{
	/// <summary>
	/// Represents the config items and their values.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class ConfigItem<T>
	{
		/// <summary>
		/// Creates the config type.
		/// </summary>
		/// <param name="name">The name of the item.</param>
		/// <param name="defaultValue">The default value of the item.</param>
		public ConfigItem(string name, T defaultValue)
		{
			Name = name;
			DefaultValue = defaultValue;
		}

		/// <summary>
		/// The name of the item.
		/// </summary>
		public string Name { get; set; }
		
		private T? _value;

		/// <summary>
		/// The value of the item.
		/// </summary>
		public T? Value
		{
			get => _value ?? DefaultValue;
			set => _value = value ?? DefaultValue;
		}

		/// <summary>
		/// The default value of the item.
		/// </summary>
		[NotNull] public T DefaultValue { get; set; }

		/// <summary>
		/// Allows for ease-of-reading.
		/// </summary>
		/// <param name="obj"></param>
		public static implicit operator T(ConfigItem<T> obj)
		{
			if (obj == null) throw new ArgumentNullException(nameof(obj));
			return obj.Value!;
		}
		
	}

	/// <summary>
	/// Basic object to make config loading/saving easier.
	/// </summary>
	public class ConfigObject : ConfigItem<object>
	{
		public ConfigObject(string name, object defaultValue) : base(name, defaultValue)
		{
		}

		#region Config Object Implicit Conversions
		
		// Note: Any time a new ConfigItem<> type is made, it should be included in these

		public static implicit operator ConfigItem<string>(ConfigObject obj)
		{
			ConfigItemList list = new();
			list.Add(obj);
			return list.GetAsString(0);
		}

		public static implicit operator ConfigObject(ConfigItem<string> obj)
		{
			ConfigObject newObject = new(obj.Name, obj.DefaultValue)
			{
				Value = obj.Value
			};

			return newObject;
		}

		public static implicit operator ConfigItem<int>(ConfigObject obj)
		{
			ConfigItemList list = new();
			list.Add(obj);
			return list.GetAsInt(0);
		}

		public static implicit operator ConfigObject(ConfigItem<int> obj)
		{
			ConfigObject newObject = new(obj.Name, obj.DefaultValue)
			{
				Value = obj.Value
			};

			return newObject;
		}

		public static implicit operator ConfigItem<bool>(ConfigObject obj)
		{
			ConfigItemList list = new();
			list.Add(obj);
			return list.GetAsBool(0);
		}

		public static implicit operator ConfigObject(ConfigItem<bool> obj)
		{
			ConfigObject newObject = new(obj.Name, obj.DefaultValue)
			{
				Value = obj.Value
			};

			return newObject;
		}

		public static implicit operator ConfigItem<MinecraftColor>(ConfigObject obj)
		{
			ConfigItemList list = new();
			list.Add(obj);
			return list.GetAsColor(0);
		}

		public static implicit operator ConfigObject(ConfigItem<MinecraftColor> obj)
		{
			ConfigObject newObject = new(obj.Name, obj.DefaultValue)
			{
				Value = obj.Value
			};

			return newObject;
		}

		#endregion
	}

	public class ConfigItemList : IEnumerable<ConfigObject>, IEnumerator<ConfigObject>
	{
		private readonly List<ConfigObject> _items;
		private int _pos = -1;
#pragma warning disable 649
		private ConfigObject _current;
#pragma warning restore 649

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
		public ConfigItemList()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
		{
			_items = new();
		}

		IEnumerator<ConfigObject> IEnumerable<ConfigObject>.GetEnumerator()
		{
			return _items.GetEnumerator();
		}

		public IEnumerator GetEnumerator()
		{
			return this;
		}

		public bool MoveNext()
		{
			_pos++;
			return _pos  <_items.Count;
		}

		public void Reset()
		{
			_pos = 0;
		}

		ConfigObject IEnumerator<ConfigObject>.Current => _current;

		public object Current => _items[_pos];

		public int Count => _items.Count;

		public ConfigObject this[int index]
		{
			get => _items[index];
			set => _items[index] = value;
		}

		public void Add(ConfigObject obj)
		{
			_items.Add(obj);
		}

		public void RemoveAt(int index)
		{
			_items.RemoveAt(index);
		}

		public ConfigItem<int> GetAsInt(int index)
		{
			ConfigObject obj = this[index];
			return new ConfigItem<int>(obj.Name, (int) obj.DefaultValue)
			{
				Value = (int) obj.Value!
			};
		}

		public ConfigItem<bool> GetAsBool(int index)
		{
			ConfigObject obj = this[index];
			return new ConfigItem<bool>(obj.Name, (bool) obj.DefaultValue)
			{
				Value = (bool) obj.Value!
			};
		}

		public ConfigItem<string> GetAsString(int index)
		{
			ConfigObject obj = this[index];
			return new ConfigItem<string>(obj.Name, (string) obj.DefaultValue)
			{
				Value = (string) obj.Value!
			};
		}

		public ConfigItem<MinecraftColor> GetAsColor(int index)
		{
			ConfigObject obj = this[index];
			return new ConfigItem<MinecraftColor>(obj.Name, (MinecraftColor) obj.DefaultValue)
			{
				Value = (MinecraftColor) obj.Value!
			};
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}
}
