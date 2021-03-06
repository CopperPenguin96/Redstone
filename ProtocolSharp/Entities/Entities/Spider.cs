﻿using ProtocolSharp.Types;
using ProtocolSharp.Utils;

namespace ProtocolSharp.Entities.Entities
{
	public class Spider : Monster
	{
		public override EntityType Type => EntityType.Spider;

		public override float BoundingBoxX => 1.4f;

		public override float BoundingBoxY => 0.9f;

		public override Identifier ID => new Identifier("spider");

		public override bool UseWithSpawnObject => false;

		public override void RegisterMetadata()
		{
			base.RegisterMetadata();
			MetaRegistry.Add(SpiderAction);
		}

		private byte _spiderAction = 0;
		private const byte _isClimbing = 0x01;

		public EntityMetaByte SpiderAction =>
			new EntityMetaByte
			{
				Index = 15,
				DefaultValue = 0,
				Value = _spiderAction
			};

		public bool IsClimbing
		{
			get => FlagsHelper.IsSet(_spiderAction, _isClimbing);
			set
			{
				if (value) FlagsHelper.Set(ref _spiderAction, _isClimbing);
				else FlagsHelper.Unset(ref _spiderAction, _isClimbing);
			}
		}
	}
}