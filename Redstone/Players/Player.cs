using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redstone.Players
{
    public class Player
    {
        public string Username { get; set; }

        public string? DisplayName { get; set; }

        public string UniqueId { get; set; }

        /// <summary>
        /// Should only be used during the login start packet.
        /// </summary>
        /// <param name="username"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public Player(string username)
        {
            Username = username ?? throw new ArgumentNullException(nameof(username));
        }
    }
}
