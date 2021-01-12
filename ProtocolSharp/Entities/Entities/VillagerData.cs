using ProtocolSharp.Types;

namespace ProtocolSharp.Entities.Entities
{
	public class VillagerData
	{
		public VillagerType Type { get; set; }
		public VillagerJob Job { get; set; }
		public VarInt Level { get; set; }

		public VillagerData(VillagerType type, VillagerJob job, VarInt level)
		{
			Type = type;
			Job = job;
			Level = level;
		}
	}
}