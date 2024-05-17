package com.CopperPenguin96.Redstone.Network.Packets.Login;

import java.io.IOException;
import java.lang.reflect.Array;
import java.math.BigInteger;
import java.security.KeyFactory;
import java.security.MessageDigest;
import java.security.PrivateKey;
import java.security.Provider;
import java.util.Arrays;

import javax.crypto.*;
import javax.crypto.SecretKey;
import javax.crypto.spec.*;

import org.bouncycastle.crypto.util.PrivateKeyInfoFactory;
import org.bouncycastle.pqc.crypto.util.SubjectPublicKeyInfoFactory;
import org.json.JSONArray;
import org.json.JSONObject;
import org.json.JSONTokener;

import com.CopperPenguin96.Redstone.Server;
import com.CopperPenguin96.Redstone.Network.GameInputStream;
import com.CopperPenguin96.Redstone.Network.Packets.IPacket;
import com.CopperPenguin96.Redstone.Players.Player;
import com.CopperPenguin96.Redstone.Players.PlayerProperty;
import com.CopperPenguin96.Redstone.System.Types.OptValue;
import com.CopperPenguin96.Redstone.Utils.NetTools;

public class EncryptionResponse implements IPacket {

	@Override
	public String getName() {
		return "Encryption Response";
	}

	@Override
	public int getPacketID() {
		return 0x01;
	}

	@Override
	public void send(Player player) throws IOException {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void receive(Player player, GameInputStream stream) throws IOException {
		// TODO Auto-generated method stub
		int secLength = stream.readVarInt();
		byte[] secret = stream.readByteArray(secLength);
		int tokLength = stream.readVarInt();
		byte[] vToken = stream.readByteArray(tokLength);
		
		try {
			
			PrivateKey privKey = Server.KeyPair.getPrivate();
			Cipher rsaCipher = Cipher.getInstance("RSA");
			rsaCipher.init(Cipher.DECRYPT_MODE, privKey);
			SecretKey sec = new SecretKeySpec(rsaCipher.doFinal(secret), "AES");
			rsaCipher.init(Cipher.DECRYPT_MODE, Server.KeyPair.getPrivate());
			vToken = rsaCipher.doFinal(vToken);
			
			if (Arrays.equals(player.VToken, vToken)) {
				player.Secret = sec;
				continueLogin(player, stream, sec.getEncoded());
			} else {
				player.disconnect("Unable to authenticate: Verify Tokens do not match.");
			}
			
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} 
	}
	
	private static final String SessionChecker = 
			"https://sessionserver.mojang.com/session/minecraft/" +
					"hasJoined?username={0}&serverId={1}";
	// TODO add ip= Field for Prevet-Proxy-Connections 

	private void continueLogin(Player player, GameInputStream stream, byte[] shared) throws IOException {
		String hash;
		try {
			MessageDigest digest = MessageDigest.getInstance("SHA-1");
			digest.update("".getBytes());
			digest.update(shared);
			digest.update(Server.KeyPair.getPublic().getEncoded());
			
			hash = new BigInteger(digest.digest()).toString(16);
		} catch (Exception ex) {
			ex.printStackTrace();
			return;
		}
		
		String url = SessionChecker.replace("{0}", player.Username);
		url = url.replace("{1}", hash);
		System.out.println(url);
		String response = NetTools.executeUrl(url);
		System.out.println(response);
		JSONTokener tokener = new JSONTokener(response);
		JSONObject obj = new JSONObject(tokener);
		
		String uuid = obj.getString("id");
		String username = obj.getString("name");
		
		JSONArray props = obj.getJSONArray("properties"); // ignore, TODO later
		
		for (int i = 0; i < props.length(); i++) {
			JSONObject prop = props.getJSONObject(i);
			
			String name = prop.getString("name");
			String value = prop.getString("value");
			String signature = null;
			if (prop.has("signature")) {
				signature = prop.getString("signature");
			}
			
			OptValue<String> sign = new OptValue<>();
			if (!signature.equals(null)) {
				sign.setEnabled();
				sign.setValue(signature);
			}
			
			PlayerProperty property = new PlayerProperty(name, value, signature);
			player.Properties.add(property);
		}
		
		
		player.setEncrypted();
		
		new LoginSuccess(player.UniqueId.toString()).send(player);
	}
}
