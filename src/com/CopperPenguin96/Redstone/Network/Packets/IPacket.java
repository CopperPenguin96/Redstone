package com.CopperPenguin96.Redstone.Network.Packets;

import java.io.IOException;
import java.security.NoSuchAlgorithmException;

import javax.crypto.NoSuchPaddingException;

import com.CopperPenguin96.Redstone.Network.*;
import com.CopperPenguin96.Redstone.Players.Player;

public interface IPacket {

	/**
	 * The name of the packet. Has no actual bearing, just helps with exception reporting.
	 * @return
	 */
	String getName();
	
	/**
	 * The numerical id of the packet. What identifies the packet
	 * @return
	 */
	int getPacketID();
	
	/**
	 * Sends the packet to the client.
	 * @param player
	 */
	void send(Player player) throws IOException;
	
	/**
	 * Receives the packet from the client
	 */
	void receive(Player player, GameInputStream stream) throws IOException;
	
	
	public default GameOutputStream getStream(Player player) throws IOException, NoSuchAlgorithmException, NoSuchPaddingException {
		return player.getOutputStream();
	}
}
