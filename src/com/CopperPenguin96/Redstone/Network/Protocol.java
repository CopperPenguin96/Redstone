package com.CopperPenguin96.Redstone.Network;

import java.io.*;
import java.net.*;

import com.CopperPenguin96.Redstone.Network.Packets.PacketReader;
import com.CopperPenguin96.Redstone.Players.Player;
import com.CopperPenguin96.Redstone.System.Types.VarInt;
import com.CopperPenguin96.Redstone.Utils.DataTypeLength;

public class Protocol {

	public static final int Version = 765; // 1.20.4
	
	public static void listen(Player player, InputStream in) throws IOException {
		GameInputStream s = new GameInputStream(in);
		int length = s.readVarInt();
		byte[] contts = s.readByteArray(length);
		GameInputStream content = new GameInputStream(new ByteArrayInputStream(contts));
		PacketReader.read(player, content.readAllBytes());
		
	}
	
	public static int getVarIntLength(int v) {
		return new VarInt(v).length();
	}
}
