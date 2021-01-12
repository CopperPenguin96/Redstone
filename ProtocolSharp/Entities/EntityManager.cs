using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Serialization;
using ProtocolSharp.Entities.Entities;
using ProtocolSharp.Utils;
using Redstone.Reflection;

namespace ProtocolSharp.Entities
{
	/// <summary>
	/// Managing Class for all Entities
	/// </summary>
	public class EntityManager
	{
		public static EntityRegistry Registry = new EntityRegistry();
	}

	public class EntityRegistry : List<Entity>
	{
		/// <summary>
		/// Adds the entity to the registry and gives it its ID.
		/// </summary>
		/// <param name="entity"></param>
		public void Add(ref Entity entity)
		{
			if (entity == null) throw new ArgumentNullException(nameof(entity));

			entity.EID = Count;
			base.Add(entity);
		}

		/// <summary>
		/// Do not use this method. Use method with by ref param
		/// </summary>
		/// <param name="entity"></param>
		public new void Add(Entity entity)
		{
			throw new NotImplementedException("Use ref Entity");
		}
	}
}
