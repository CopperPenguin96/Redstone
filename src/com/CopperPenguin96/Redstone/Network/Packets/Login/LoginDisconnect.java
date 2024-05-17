package com.CopperPenguin96.Redstone.Network.Packets.Login;

import java.io.IOException;

import com.CopperPenguin96.Redstone.Network.GameInputStream;
import com.CopperPenguin96.Redstone.Network.Packets.IPacket;
import com.CopperPenguin96.Redstone.Network.Packets.PacketWriter;
import com.CopperPenguin96.Redstone.Players.Chat;
import com.CopperPenguin96.Redstone.Players.Player;

public class LoginDisconnect implements IPacket {

	@Override
	public String getName() {
		return "Disconnect (login)";
	}

	@Override
	public int getPacketID() {
		return 0x00;
	}

	@Override
	public void send(Player player) throws IOException {
		try {
			PacketWriter.writePacket(player.getOutputStream(), getPacketID(), Chat.format(_reason, null));
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}

	@Override
	public void receive(Player player, GameInputStream stream) throws IOException {
		// TODO Auto-generated method stub
	}

	private String _reason;
	public LoginDisconnect(String reason) {
		_reason = reason;
	}
}
