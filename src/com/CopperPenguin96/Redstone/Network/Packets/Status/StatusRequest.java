package com.CopperPenguin96.Redstone.Network.Packets.Status;

import java.io.IOException;

import com.CopperPenguin96.Redstone.Network.GameInputStream;
import com.CopperPenguin96.Redstone.Network.Packets.IPacket;
import com.CopperPenguin96.Redstone.Players.Player;

public class StatusRequest implements IPacket {

	@Override
	public String getName() {
		return "Status Request";
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
		new StatusResponse().send(player); // this one gets no fields, just responds
	}

}
