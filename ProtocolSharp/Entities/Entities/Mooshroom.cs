namespace ProtocolSharp.Entities.Entities
{
	public class Mooshroom : Cow
	{
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