package com.CopperPenguin96.Redstone.Network.Packets.Config;

import java.io.IOException;

import com.CopperPenguin96.Redstone.Network.GameInputStream;
import com.CopperPenguin96.Redstone.Network.Packets.IPacket;
import com.CopperPenguin96.Redstone.Players.Player;

public class RegistryData implements IPacket {

	@Override
	public String getName() {
		return "Registry Data";
	}

	@Override
	public int getPacketID() {
		return 0x05;
	}

	@Override
	public void send(Player player) throws IOException {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void receive(Player player, GameInputStream stream) throws IOException {
		// TODO Auto-generated method stub
		
	}

}
