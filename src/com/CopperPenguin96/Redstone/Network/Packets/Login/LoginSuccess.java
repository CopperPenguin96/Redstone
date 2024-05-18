package com.CopperPenguin96.Redstone.Network.Packets.Login;

import java.io.IOException;
import java.security.NoSuchAlgorithmException;
import java.util.ArrayList;
import java.util.UUID;

import javax.crypto.NoSuchPaddingException;

import com.CopperPenguin96.Redstone.Network.GameInputStream;
import com.CopperPenguin96.Redstone.Network.Protocol;
import com.CopperPenguin96.Redstone.Network.Packets.IPacket;
import com.CopperPenguin96.Redstone.Network.Packets.PacketWriter;
import com.CopperPenguin96.Redstone.Players.ClientState;
import com.CopperPenguin96.Redstone.Players.Player;
import com.CopperPenguin96.Redstone.Players.PlayerProperty;
import com.CopperPenguin96.Redstone.System.Types.VarInt;

public class LoginSuccess implements IPacket {

	@Override
	public String getName() {
		return "Login Success";
	}

	@Override
	public int getPacketID() {
		return 0x02;
	}

	@Override
	public void send(Player player) throws IOException {
		ArrayList<Object> items = new ArrayList<>();
		UUID uid = UUID.fromString(uuid);
		items.add(uid);
		items.add(player.Username);
		VarInt vI = new VarInt(0);
		items.add(vI);
		
		/*for (PlayerProperty prop : player.Properties) {
			items.add(prop.Name);
			System.out.println(prop.Name.length());
			items.add(prop.Value);
			System.out.println(prop.Value.length());
			items.add(prop.Signature.isEnabled());
			
			if (prop.Signature.isEnabled()) {
				items.add(prop.Signature.getValue());
			}
		}*/
		
		try {
			System.out.println("Testing encryption");
			PacketWriter.writePacket(player.getOutputStream(), getPacketID(), player.UniqueId, player.Username, new VarInt(0));
			player.State = ClientState.Config;
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}

	@Override
	public void receive(Player player, GameInputStream stream) throws IOException {
		// TODO Auto-generated method stub
		
	}
	
	private String uuid;
	public LoginSuccess(String id) {
		uuid = id;
	}

}
