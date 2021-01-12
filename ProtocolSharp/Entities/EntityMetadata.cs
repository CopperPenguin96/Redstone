using System;
using System.Collections.Generic;
using System.Text;

namespace ProtocolSharp.Entities
{
	public class EntityMetadata<T>
	{
		public int Index { get; set; }

		public virtual T DefaultValue { get; set; }

		private T _value;
		public virtual T Value
		{
			get => _value == null ? DefaultValue : _value;
			set => _value = value == null ? DefaultValue : value;
		}

		public EntityMetadata()
		{
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
	}

	public class EntityMetaShort : EntityMetadata<short>
	{
		public override short DefaultValue { get; set; }

		public override short Value { get; set; }
	}

	public class EntityMetaFloat : EntityMetadata<float>
	{
		public override float DefaultValue { get; set; }

		public override float Value { get; set; }
	}

	public class EntityMetaLong : EntityMetadata<long>
	{
		public override long DefaultValue { get; set; }

		public override long Value { get; set; }
	}

	public class EntityMetaBool : EntityMetadata<bool>
	{
		public override bool DefaultValue { get; set; }

		public override bool Value { get; set; }
	}

	public class EntityMetaByte : EntityMetadata<byte>
	{
		public override byte DefaultValue { get; set; }

		public override byte Value { get; set; }
	}

	public class EntityMetaPose : EntityMetadata<EntityPose>
	{
		public override EntityPose DefaultValue { get; set; }

		public override EntityPose Value { get; set; }
	}
}


