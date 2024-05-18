package com.CopperPenguin96.Redstone.Network.Packets.Status;

import java.io.IOException;
import java.security.NoSuchAlgorithmException;

import javax.crypto.NoSuchPaddingException;

import com.CopperPenguin96.Redstone.Network.GameInputStream;
import com.CopperPenguin96.Redstone.Network.Packets.IPacket;
import com.CopperPenguin96.Redstone.Network.Packets.PacketWriter;
import com.CopperPenguin96.Redstone.Players.Player;

public class PingResponseStatus implements IPacket {

	@Override
	public String getName() {
		return "Ping Response (Status)";
	}

	@Override
	public int getPacketID() {
		return 0x01;
	}

	@Override
	public void send(Player player) throws IOException {
		try {
			PacketWriter.writePacket(player.getOutputStream(), getPacketID(), _payload);
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}

	@Override
	public void receive(Player player, GameInputStream stream) throws IOException {
		// TODO Auto-generated method stub
		
	}
	
	private long _payload;
	public PingResponseStatus(long payload) {
		_payload = payload;
	}

}
