package com.CopperPenguin96.Redstone.Network.Packets.Login;

import java.io.IOException;

import com.CopperPenguin96.Redstone.Network.GameInputStream;
import com.CopperPenguin96.Redstone.Network.Packets.IPacket;
import com.CopperPenguin96.Redstone.Players.Player;

public class LoginAcknowledged implements IPacket {

	@Override
	public String getName() {
		return "Login Acknowledged";
	}

	@Override
	public int getPacketID() {
		return 0x03;
	}

	@Override
	public void send(Player player) throws IOException {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void receive(Player player, GameInputStream stream) throws IOException {
		System.out.println("LOGIN COMPLETE BITCH!");
	}

}
