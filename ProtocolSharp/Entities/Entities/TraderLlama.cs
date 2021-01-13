using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class TraderLlama : Llama
	{
		public override EntityType Type => EntityType.TraderLlama;

		public override float BoundingBoxX => 0.9f;

		public override float BoundingBoxY => 1.87f;

		public override Identifier ID => new Identifier("trader_llama");

		public override bool UseWithSpawnObject => false;
	}
}