package com.CopperPenguin96.Redstone.Players;

import java.io.IOException;
import java.net.*;
import java.security.InvalidKeyException;
import java.security.Key;
import java.security.NoSuchAlgorithmException;
import java.security.NoSuchProviderException;
import java.security.PrivateKey;
import java.security.Provider;
import java.security.PublicKey;
import java.util.*;

import javax.crypto.Cipher;
import javax.crypto.CipherOutputStream;
import javax.crypto.NoSuchPaddingException;
import javax.crypto.SecretKey;

import com.CopperPenguin96.Redstone.Server;
import com.CopperPenguin96.Redstone.Network.*;
import com.CopperPenguin96.Redstone.Network.Packets.Login.LoginDisconnect;

public class Player {

	public Socket Socket;
	public ClientState State = ClientState.Handshake;
	public InetAddress ConnectedAddress;
	public String Username;
	public UUID UniqueId;
	public byte[] VToken;
	public ArrayList<PlayerProperty> Properties = new ArrayList<>();
	private boolean _encrypto = false;
	public SecretKey Secret;
	
	public Player() {
	}
	
	public GameOutputStream getOutputStream() throws IOException {
		if (_encrypto) {
			try {
				Cipher c = Cipher.getInstance("AES/CFB8/NoPadding", "BC");
				c.init(Cipher.ENCRYPT_MODE, Secret);
				CipherOutputStream cs = new CipherOutputStream(this.Socket.getOutputStream(), c);
				return new GameOutputStream(cs);
			} catch (Exception e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
				return null;
			}
			
			
		} else {
			return new GameOutputStream(this.Socket.getOutputStream());
		}
	}
	
	public void setEncrypted() {
		_encrypto = true;
	}
	
	public GameInputStream getInputStream() throws IOException {
		return new GameInputStream(this.Socket.getInputStream());
	}
	
	public void disconnect(String reason) {
		String fullMessage = "You have been disconnected. (" + reason + ")";
		try {
			switch (State) {
				case Login:
					new LoginDisconnect(fullMessage).send(this);
					break;
				case Play:
					break;
				case Config:
					break;
				default:
					break;
			}
		} catch (Exception ex) {
			ex.printStackTrace();
		}
	}
	
	public void disconnect() {
		this.disconnect("disconnected");
	}
	
	private String _displayName;
	
	public String getDisplayName() {
		if (_displayName == null) return Username;
		
		return _displayName;
	}
	
	public void setDisplayName(String dname) {
		_displayName = dname;
	}
	
	public void resetDisplayName() {
		this.setDisplayName(null);
	}
	
	private int _kicks;
	
	public int getKicks() {
		return _kicks;
	}
	
	public void setKicks(int kicks) {
		_kicks = kicks;
	}
	
	public void incrementKicks() {
		this.setKicks(_kicks + 1);
	}
	
	private int _bans;
	
	public int getBans() {
		return _kicks;
	}
	
	public void setBans(int bans) {
		_kicks = bans;
	}
	
	public void incrementBans() {
		this.setBans(_bans + 1);
	}
	
	private int _money;
	
	public int getMoney() {
		return _money;
	}
	
	public void setMoney(int mon) {
		_money = mon;
	}
}
