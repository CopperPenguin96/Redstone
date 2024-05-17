package com.CopperPenguin96.Redstone.Network.Packets.Handshaking;

import java.io.IOException;

import com.CopperPenguin96.Redstone.Network.*;
import com.CopperPenguin96.Redstone.Network.Packets.*;
import com.CopperPenguin96.Redstone.Players.Player;

public class LegacyPing implements IPacket {

	@Override
	public String getName() {
		return "Legeacy Server List Ping";
	}

	@Override
	public int getPacketID() {
		return 0xFE;
	}

	@Override
	public void send(Player player) throws IOException {
		
	}

	@Override
	public void receive(Player player, GameInputStream stream) throws IOException {
		// todo?
	}

}
