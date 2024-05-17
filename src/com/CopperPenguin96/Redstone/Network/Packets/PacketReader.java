package com.CopperPenguin96.Redstone.Network.Packets;

import java.io.*;
import java.math.BigInteger;
import java.security.*;
import java.util.*;

import javax.crypto.*;
import javax.crypto.spec.SecretKeySpec;

import org.json.*;

import com.CopperPenguin96.Redstone.Network.*;
import com.CopperPenguin96.Redstone.Network.Packets.Handshaking.HandshakePacket;
import com.CopperPenguin96.Redstone.Network.Packets.Login.*;
import com.CopperPenguin96.Redstone.Network.Packets.Status.*;
import com.CopperPenguin96.Redstone.Players.*;
import com.CopperPenguin96.Redstone.System.Types.OptValue;
import com.CopperPenguin96.Redstone.Utils.*;
public class PacketReader {

	public static void read(Player player, byte[] content) throws IOException {
		switch (player.State) {
			case Handshake:
				readHandshake(player, content);
				break;
			case Status:
				readStatus(player, content);
				break;
			case Login:
				readLogin(player, content);
				break;
			case Config:
				readConfig(player, content);
				break;
			case Play:
				readPlay(player, content);
				break;
		}
	}
	
	private static void readHandshake(Player player, byte[] content) throws IOException {
		GameInputStream stream = new GameInputStream(new ByteArrayInputStream(content));
		int id = stream.readVarInt();
		switch (id) {
			case 0x00:
				new HandshakePacket().receive(player, stream);
				break;
				
		}
	}
	
	private static void readStatus(Player player, byte[] content) throws IOException {
		GameInputStream stream = new GameInputStream(new ByteArrayInputStream(content));
		int id = stream.readVarInt();
		
		switch (id) {
			case 0x00:
				new StatusRequest().receive(player, stream);
				break;
			case 0x01:
				new PingRequestStatus().receive(player, stream);
				break;
		}
	}
	
	private static void readLogin(Player player, byte[] content) throws IOException {
		GameInputStream stream = new GameInputStream(new ByteArrayInputStream(content));
		int id = stream.readVarInt();
		switch (id) {
			case 0x00:
				new LoginStart().receive(player, stream);
				break;
			case 0x01:
				new EncryptionResponse().receive(player, stream);
				break;
			case 0x03:
				new LoginAcknowledged().receive(player, stream);
				break;
		}
	}
	
	private static void readConfig(Player player, byte[] content) throws IOException {
		
	}
	
	private static void readPlay(Player player, byte[] content) throws IOException {
		
	}
}
