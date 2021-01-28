using System;
using System.Collections.Generic;
using System.Text;
using ProtocolSharp.Network;

namespace ProtocolSharp.Packets.Play.Client
{
	/// <summary>
	/// Sends the Block Break Animation packet to the client
	/// 0-9 are the displayable destroy stages and each other n umber means that there
	/// is no animation on this coordinate.
	/// Block break animations can still be applied on air; the animation will remain
	/// visible although there is no block being broken. However, if this is applied to
	/// a transparent block, odd graphical effects may happen, including water losing
	/// transparency.
	/// </summary>
	public class BlockBreakAnimation : ISendingPacket
	{
		public Packet Packet => Packet.BlockBreakAnimation;

		public string Name => "Block Break Animation";

		public void Send(ref MinecraftClient client, GameStream stream)
		{
			Protocol.Send(ref client, stream, Packet,
				client.Entity.EID, client.Entity.Position.GetStreamData(),
				client.BlockLookingAt.DestroyStage);
		}
	}
}
