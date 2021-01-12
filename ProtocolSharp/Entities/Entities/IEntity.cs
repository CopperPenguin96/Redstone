using System;
using System.Collections.Generic;
using System.Text;
using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public interface IEntity
	{
		EntityType Type { get; }

		float BoundingBoxX { get; }

		float BoundingBoxY { get; }

		Identifier ID { get; }

		bool UseWithSpawnObject { get; }

		void RegisterMetadata();
	}
}
