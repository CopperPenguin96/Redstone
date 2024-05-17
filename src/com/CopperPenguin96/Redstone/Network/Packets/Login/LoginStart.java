package com.CopperPenguin96.Redstone.Network.Packets.Login;

import java.io.IOException;
import java.nio.ByteBuffer;
import java.util.UUID;

import com.CopperPenguin96.Redstone.Network.GameInputStream;
import com.CopperPenguin96.Redstone.Network.Packets.IPacket;
import com.CopperPenguin96.Redstone.Players.Player;

public class LoginStart implements IPacket {

	@Override
	public String getName() {
		return "Login Start";
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
		// TODO Auto-generated method stub
		String username = stream.readString();
		byte[] uuid = stream.readByteArray(16);
		ByteBuffer byteBuffer = ByteBuffer.wrap(uuid);
	    long high = byteBuffer.getLong();
	    long low = byteBuffer.getLong();
	    UUID id = new UUID(high, low);
		
		player.Username = username;
		player.UniqueId = id;
		System.out.println(username + " is logging in. (" + id.toString() + ")");
		new EncryptionRequest().send(player);
	}

}
