using ProtocolSharp.Utils;

namespace ProtocolSharp.Entities.Entities
{
	public class Vex : Monster
	{
		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(VexAction);
		}

		private byte _vexAction = 0;
		private const byte _isAttacking = 0x01;

		public EntityMetaByte VexAction =>
			new EntityMetaByte
			{
				Index = 15,
				DefaultValue = 0,
				Value = _vexAction
			};

		public bool IsAttacking
		{
			get => FlagsHelper.IsSet(_vexAction, _isAttacking);
			set
			{
				if (value) FlagsHelper.Set(ref _vexAction, _isAttacking);
				else FlagsHelper.Unset(ref _vexAction, _isAttacking);
			}
		}
	}
}