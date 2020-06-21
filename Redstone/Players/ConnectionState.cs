using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redstone.Players
{
	public enum ConnectionState
	{
		Handshake,
		Status,
		Login,
		Play
	}
}
