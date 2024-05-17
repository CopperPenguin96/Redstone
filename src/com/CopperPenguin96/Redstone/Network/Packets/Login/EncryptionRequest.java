package com.CopperPenguin96.Redstone.Network.Packets.Login;

import java.io.IOException;
import java.security.InvalidAlgorithmParameterException;
import java.security.InvalidKeyException;
import java.security.KeyPair;
import java.security.KeyPairGenerator;
import java.security.NoSuchAlgorithmException;
import java.security.NoSuchProviderException;
import java.util.Random;

import javax.crypto.BadPaddingException;
import javax.crypto.Cipher;
import javax.crypto.IllegalBlockSizeException;
import javax.crypto.NoSuchPaddingException;

import org.bouncycastle.asn1.ASN1Encoding;
import org.bouncycastle.crypto.AsymmetricBlockCipher;
import org.bouncycastle.crypto.MultiBlockCipher;
import org.bouncycastle.jcajce.provider.asymmetric.util.KeyUtil;
import org.bouncycastle.pqc.crypto.util.SubjectPublicKeyInfoFactory;

import com.CopperPenguin96.Redstone.Server;
import com.CopperPenguin96.Redstone.Network.GameInputStream;
import com.CopperPenguin96.Redstone.Network.Protocol;
import com.CopperPenguin96.Redstone.Network.Packets.IPacket;
import com.CopperPenguin96.Redstone.Network.Packets.PacketWriter;
import com.CopperPenguin96.Redstone.Players.Player;
import javax.crypto.spec.IvParameterSpec;
import com.CopperPenguin96.Redstone.System.Types.VarInt;

public class EncryptionRequest implements IPacket {

	@Override
	public String getName() {
		return "Encryption Request";
	}

	@Override
	public int getPacketID() {
		return 0x01;
	}

	@Override
	public void send(Player player) throws IOException {
		String sid = "";
		byte[] pubKey = null;
		byte[] vToken;
		try {
			pubKey = Server.KeyPair.getPublic().getEncoded();
			vToken = new byte[4];
			new Random().nextBytes(vToken);
			player.VToken = vToken;
			
			PacketWriter.writePacket(player.getOutputStream(), getPacketID(),
					sid,
					new VarInt(pubKey.length), pubKey,
					new VarInt(vToken.length), vToken);
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
			player.disconnect("Failure to authenticate.");
			return;
		}
	}

	@Override
	public void receive(Player player, GameInputStream stream) throws IOException {
		// TODO Auto-generated method stub
		
	}

}
