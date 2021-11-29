using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Entities.Living.Mobs;
using Redstone.Types;

namespace Redstone.Entities.Living.Monsters
{
    public class EnderDragon : Mob
    {
        public DragonPhase Phase { get; set; } = DragonPhase.HoveringNoAi;
    }

    public enum DragonPhase
    {
        Circling = 0,
        Strafing = 1,
        FlyingToPortalToLand = 2,
        LandingOnPortal = 3,
        TakingOffFromPortal = 4,
        LandedBreathAttack = 5,
        LandedLookingForPlayer = 6,
        LandedRoarBeforeBreathAttack = 7,
        ChargingPlayer = 8,
        FlyingToDie = 9,
        HoveringNoAi = 10
    }
}
