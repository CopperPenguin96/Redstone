using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class LlamaSpit : Entity // wtf?
	{
		public override EntityType Type => EntityType.LlamaSpit;

		public override float BoundingBoxX => 0.25f;

		public override float BoundingBoxY => 0.25f;

		public override Identifier ID => new Identifier("llama_spit");

		public override bool UseWithSpawnObject => true;

		public override int Data => 0;
	}
}