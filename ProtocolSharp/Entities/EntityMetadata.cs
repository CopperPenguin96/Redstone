using System;
using System.Collections.Generic;
using System.Text;

namespace ProtocolSharp.Entities
{
	public class EntityMetadata<T>
	{
		public string Name { get; set; }

		public int Index { get; set; }

		public virtual T DefaultValue { get; set; }

		private T _value;
		public virtual T Value
		{
			get => _value == null ? DefaultValue : _value;
			set => _value = value == null ? DefaultValue : value;
		}

		public EntityMetadata(string name)
		{
			if (name == null) throw new ArgumentNullException(nameof(name));
			if (!(Nullable.GetUnderlyingType(typeof(T)) != null))
			{
				Value = DefaultValue;
			}
		}
	}

	public class EntityMetaInt : EntityMetadata<int>
	{
		public override int DefaultValue { get; set; }

		public override int Value { get; set; }

		public EntityMetaInt(string name) : base(name)
		{
		}
	}

	public class EntityMetaFloat : EntityMetadata<float>
	{
		public override float DefaultValue { get; set; }

		public override float Value { get; set; }

		public EntityMetaFloat(string name) : base(name)
		{
		}
	}

	public class EntityMetaBool : EntityMetadata<bool>
	{
		public override bool DefaultValue { get; set; }

		public override bool Value { get; set; }

		public EntityMetaBool(string name) : base(name)
		{
		}
	}

	public class EntityMetaByte : EntityMetadata<byte>
	{
		public override byte DefaultValue { get; set; }

		public override byte Value { get; set; }

		public EntityMetaByte(string name) : base(name)
		{
		}
	}

	public class EntityMetaPose : EntityMetadata<EntityPose>
	{
		public override EntityPose DefaultValue { get; set; }

		public override EntityPose Value { get; set; }

		public EntityMetaPose(string name) : base(name)
		{
		}
	}
}


