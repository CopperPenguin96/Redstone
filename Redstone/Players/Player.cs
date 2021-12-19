using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redstone.Types;
using Redstone.Utils;
using Redstone.Worlds;
using Redstone.Worlds.Dimensions;
using Slot = Redstone.Types.Slot;

namespace Redstone.Players
{
    public partial class Player
    {
        public string Username { get; set; }

        public string? DisplayName { get; set; }

        public bool OnGround { get; set; }

        public bool IsSleeping { get; set; }

        public short Air { get; set; }

        public short AttackTime { get; set; }

        public short DeathTime { get; set; }

        /// <summary>
        /// Ticks until the player is no longer on fire, or zero.
        /// </summary>
        public short Fire { get; set; }

        public short Health { get; set; }

        public short HurtTime { get; set; }

        public short SleepTimer { get; set; }

        public IDimension Dimension { get; set; }

        public int FoodLevel { get; set; }

        public int FoodTickTimer { get; set; }

        public GameMode GameMode { get; set; }

        public int ExperienceLevel { get; set; }

        public int ExperienceTotal { get; set; }

        public float XpP { get; set; }

        public List<Slot> Inventory { get; set; }

        public Position Motion { get; set; }

        public Position Rotation { get; set; }

        public World World { get; set; }

        /// <summary>
        /// Should only be used during the login start packet.
        /// </summary>
        /// <param name="username"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public Player(string username)
        {
            Username = username ?? throw new ArgumentNullException(nameof(username));
        }

        /// <summary>
        /// Finds a specific player by UUID.
        /// </summary>
        /// <param name="uniqueId">The Unique ID of the player.</param>
        /// <returns>Returns the player object, or null if they don't exist.</returns>
        /// <exception cref="ArgumentNullException">Thrown if uniqueId is null</exception>
        public static Player? FindById(string uniqueId)
        {
            if (uniqueId == null) throw new ArgumentNullException(nameof(uniqueId));

            return PlayerDatabase.Players.FirstOrDefault(p => p.UniqueId.ToString() == uniqueId);
        }
    }
}
