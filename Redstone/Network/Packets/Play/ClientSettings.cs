using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Redstone.AppSystem;
using Redstone.Players;
using Redstone.Players.Chat;
using Redstone.Utils;

namespace Redstone.Network.Packets.Play
{
	public class ClientSettings : IPacket
	{
		public Packet ID => Packet.ClientSettings;
		public string Name => "Client Settings";

		public void Send(ref Player player, GameStream stream)
		{
			throw new NotImplementedException();
		}

		public void Receive(ref Player player, GameStream stream)
		{
			string locale = stream.ReadString();
			byte viewDistance = stream.ReadByte();
			ChatMode chatMode = (ChatMode) (int) stream.ReadVarInt();
			bool chatColors = stream.ReadBoolean();
			byte displayedParts = stream.ReadByte();
			VarInt mainHand = stream.ReadVarInt();

			player.Locale = locale;
			player.ViewDistance = viewDistance;
			player.ChatMode = chatMode;
			player.ColorsInChat = chatColors;
			player.DisplayedParts = GetParts(displayedParts);
			player.MainHand = (MainHand) (int) mainHand;
			player.Slot = 0; // Set to 0 to fire the event that sparks the next packet
			new DeclareRecipes().Send(ref player, stream); // Declare recipes
		}

		private List<SkinPart> GetParts(byte parts)
		{
			SkinPart theParts = (SkinPart) parts;

			SkinPart[] skinParts = {
				SkinPart.Cape, SkinPart.Jacket, SkinPart.LeftSleeve,
				SkinPart.RightSleeve, SkinPart.LeftPants, SkinPart.RightPants,
				SkinPart.Hat
			};

			return skinParts.Where(p 
				=> FlagsHelper.IsSet(theParts, p)).ToList();
		}
	}
}
