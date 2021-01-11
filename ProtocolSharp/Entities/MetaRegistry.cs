using System;
using System.Collections.Generic;
using System.Text;

namespace ProtocolSharp.Entities
{
	public class MetaRegistry : List<EntityMetadata<object>>
	{
		public void Add<T>(EntityMetadata<T> item)
		{
			EntityMetadata<object> newItem = new EntityMetadata<object>
			{
				Index = item.Index,
				DefaultValue = item.DefaultValue,
				Value = item.Value
			};

			base.Add(newItem);
		}

		public void Add(EntityMetaInt i)
		{
			EntityMetadata<object> newItem = new EntityMetadata<object>()
			{
				Index = i.Index,
				DefaultValue = i.DefaultValue,
				Value = i.Value
			};

			base.Add(newItem);
		}

		public void Add(EntityMetaShort i)
		{
			EntityMetadata<object> newItem = new EntityMetadata<object>()
			{
				Index = i.Index,
				DefaultValue = i.DefaultValue,
				Value = i.Value
			};

			base.Add(newItem);
		}

		public void Add(EntityMetaFloat i)
		{
			EntityMetadata<object> newItem = new EntityMetadata<object>()
			{
				Index = i.Index,
				DefaultValue = i.DefaultValue,
				Value = i.Value
			};

			base.Add(newItem);
		}

		public void Add(EntityMetaLong i)
		{
			EntityMetadata<object> newItem = new EntityMetadata<object>()
			{
				Index = i.Index,
				DefaultValue = i.DefaultValue,
				Value = i.Value
			};

			base.Add(newItem);
		}

		public void Add(EntityMetaBool i)
		{
			EntityMetadata<object> newItem = new EntityMetadata<object>()
			{
				Index = i.Index,
				DefaultValue = i.DefaultValue,
				Value = i.Value
			};

			base.Add(newItem);
		}

		public void Add(EntityMetaByte i)
		{
			EntityMetadata<object> newItem = new EntityMetadata<object>()
			{
				Index = i.Index,
				DefaultValue = i.DefaultValue,
				Value = i.Value
			};

			base.Add(newItem);
		}

		public void Add(EntityMetaPose i)
		{
			EntityMetadata<object> newItem = new EntityMetadata<object>()
			{
				Index = i.Index,
				DefaultValue = i.DefaultValue,
				Value = i.Value
			};

			base.Add(newItem);
		}
	}
}