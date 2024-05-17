package com.CopperPenguin96.Redstone.Network.Packets.Handshaking;

import java.io.IOException;
import java.net.Inet4Address;

import com.CopperPenguin96.Redstone.Network.*;
import com.CopperPenguin96.Redstone.Network.Packets.*;
import com.CopperPenguin96.Redstone.Players.ClientState;
import com.CopperPenguin96.Redstone.Players.Player;

public class HandshakePacket implements IPacket {

	@Override
	public String getName() {
		return "Handshake";
	}

	@Override
	public int getPacketID() {
		return 0x00;
	}

	@Override
	public void send(Player player) throws IOException {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void receive(Player player, GameInputStream stream) throws IOException {
		int proVersion = stream.readVarInt();
		String ip = stream.readString();
		short port = stream.readShort();
		int nextStatus = stream.readVarInt();
		if (proVersion != Protocol.Version) {
			stream.close();
			return; // Kill it.
		}
		
		player.ConnectedAddress = Inet4Address.getByName(ip);
		switch (nextStatus) {
			case 1: // Status
				player.State = ClientState.Status;
				break;
			case 2: // Login
				player.State = ClientState.Login;
				break;
		}
	}

}
