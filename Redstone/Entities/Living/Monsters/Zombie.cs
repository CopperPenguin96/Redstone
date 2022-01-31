﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinecraftTypes;
using Redstone.Types;

namespace Redstone.Entities.Living.Monsters
{
    public class Zombie : Monster
    {
        public override string Name => "Zombie";

        public override VarInt Type => 107;

        internal override bool UseSpawnEntityOnly => false;

        internal override bool UseSpawnPaintingOnly => false;

        internal override bool UseSpawnXpOnly => false;

        internal override bool AllowedSpawn => true;

        public override BoundingBox BoundingBox => new(0.6, 1.95, 0.6);

        public override Identifier Identifier => new("zombie");

        public bool IsBaby { get; set; } = false;

        public VarInt Unused { get; set; } = 0; // Previously type

        public bool IsBecomingDrowned { get; set; } = false;
    }
}
