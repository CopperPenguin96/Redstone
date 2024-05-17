package com.CopperPenguin96.Redstone.Network.Packets.Status;

import java.io.IOException;
import java.security.NoSuchAlgorithmException;
import java.util.UUID;

import javax.crypto.NoSuchPaddingException;

import org.json.JSONException;
import org.json.JSONObject;
import org.json.JSONTokener;

import com.CopperPenguin96.Redstone.Server;
import com.CopperPenguin96.Redstone.Configuration.Config;
import com.CopperPenguin96.Redstone.Network.*;
import com.CopperPenguin96.Redstone.Network.Packets.IPacket;
import com.CopperPenguin96.Redstone.Network.Packets.PacketWriter;
import com.CopperPenguin96.Redstone.Players.Chat;
import com.CopperPenguin96.Redstone.Players.Player;

public class StatusResponse implements IPacket {

	@Override
	public String getName() {
		return "Status Response";
	}

	@Override
	public int getPacketID() {
		return 0x00;
	}

	@Override
	public void send(Player player) throws IOException {
		JSONObject jObj = new JSONObject();
		
		JSONObject version = new JSONObject();
		version.put("name", Server.MinecraftVersion.toString());
		version.put("protocol", Protocol.Version);
		jObj.put("version", version);
		
		JSONObject players = new JSONObject();
		try {
			players.put("max", Config.getValue("max-players").getAsInt());
		} catch (JSONException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		players.put("online", Server.OnlinePlayers.size());
		
		JSONObject sample = new JSONObject();
		sample.put("name", "sillyboi123");
		sample.put("id", UUID.randomUUID().toString());
		
		JSONObject[] samples = new JSONObject[] {
				sample
		};
		players.put("sample", samples);
		jObj.put("players", players);
		
		
		JSONTokener tokener = null;
		try {
			tokener = new JSONTokener(Chat.format(Config.getMotd(), null));
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
		JSONObject description = new JSONObject(tokener);
		jObj.put("description", description);
		
		JSONObject favicon = new JSONObject(); // todo
		
		jObj.put("enforcesSecureChat", false);
		jObj.put("previewsChat", false);
		String json = jObj.toString();
		
		try {
			PacketWriter.writePacket(player.getOutputStream(), getPacketID(), json);
		} catch (NoSuchAlgorithmException | NoSuchPaddingException | IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}

	@Override
	public void receive(Player player, GameInputStream stream) throws IOException {
		throw new UnsupportedOperationException();
	}

}
