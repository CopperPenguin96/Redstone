using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class Mooshroom : Cow
	{
		public override EntityType Type => EntityType.Mushroom;

		public override float BoundingBoxX => 0.9f;

		public override float BoundingBoxY => 1.4f;

		public override Identifier ID => new Identifier("mooshroom");

		public override bool UseWithSpawnObject => false;

		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(Variant);
		}

		/// <summary>
		/// Either red or brown
		/// </summary>
		public EntityMetadata<string> Variant =
			new EntityMetadata<string>
			{
				Index = 16,
				DefaultValue = "red"
			};

		public void SetRed()
		{
			Variant.Value = "red";
		}

		public void SetBrown()
		{
			Variant.Value = "brown";
		}

	}
}