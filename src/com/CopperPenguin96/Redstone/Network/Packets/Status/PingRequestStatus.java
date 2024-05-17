package com.CopperPenguin96.Redstone.Network.Packets.Status;

import java.io.IOException;
import java.security.NoSuchAlgorithmException;

import javax.crypto.NoSuchPaddingException;

import com.CopperPenguin96.Redstone.Network.GameInputStream;
import com.CopperPenguin96.Redstone.Network.Packets.*;
import com.CopperPenguin96.Redstone.Players.Player;

public class PingRequestStatus implements IPacket {

	@Override
	public String getName() {
		return "Ping Request (Status)";
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
		long payload = stream.readLong();
		try {
			new PingResponseStatus(payload).send(player);
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}

}
