package com.CopperPenguin96.Redstone.Network.Packets;

import java.io.IOException;
import java.security.KeyPair;
import java.security.KeyPairGenerator;
import java.security.NoSuchAlgorithmException;
import java.util.ArrayList;
import java.util.List;
import java.util.Random;
import java.util.UUID;

import javax.crypto.KeyGenerator;

import org.json.JSONObject;

import com.CopperPenguin96.Redstone.Server;
import com.CopperPenguin96.Redstone.Configuration.Config;
import com.CopperPenguin96.Redstone.Network.*;
import com.CopperPenguin96.Redstone.Players.*;
import com.CopperPenguin96.Redstone.System.Types.*;
import com.CopperPenguin96.Redstone.Utils.*;

public class PacketWriter {

	public static int determineSize(ArrayList<Object> objects) {
		int currentSize = 0;
		for (Object o : objects) {
			if (o.getClass().equals(Boolean.class))
				currentSize += DataTypeLength.Boolean;
			if (o.getClass().equals(Byte.class))
				currentSize += DataTypeLength.Byte;
			if (o.getClass().equals(Short.class))
				currentSize += DataTypeLength.Short;
			if (o.getClass().equals(Integer.class)) 
				currentSize += DataTypeLength.Int;
			if (o.getClass().equals(Long.class))
				currentSize += DataTypeLength.Long;
			if (o.getClass().equals(Float.class))
				currentSize += DataTypeLength.Float;
			if (o.getClass().equals(Double.class))
				currentSize += DataTypeLength.Double;
			if (o.getClass().equals(VarInt.class))
				currentSize += ((VarInt) o).length();
			// todo implm VarLong when it becomes nec
			if (o.getClass().equals(Position.class))
				currentSize += DataTypeLength.Pos;
			if (o.getClass().equals(UUID.class))
				currentSize += DataTypeLength.UUID;
			if (o.getClass().equals(String.class)) {
				String str = (String) o;
				currentSize += str.length() + DataTypeLength.getVarIntLength(str.length());
			}
			if (o.getClass().equals(byte[].class)) {
				byte[] bs = (byte[]) o;
				currentSize += bs.length;
			}
		}
		return currentSize;
	}
	
	public static void writePacket(GameOutputStream stream, int id, ArrayList<Object> objs) throws IOException {
		int totalSize = VarInt.getLength(id) + determineSize(objs);
		
		stream.writeVarInt(totalSize);
		stream.writeVarInt(id);
	
		for (Object o : objs) {
			if (o.getClass().equals(Boolean.class))
				stream.writeBoolean((boolean)o);
			if (o.getClass().equals(Byte.class))
				stream.writeByte((byte) o);
			if (o.getClass().equals(Short.class))
				stream.writeShort((short)o);
			if (o.getClass().equals(Integer.class)) 
				stream.writeInt((int)o);
			if (o.getClass().equals(Long.class)) {
				stream.writeLong((long)o);
			}
			if (o.getClass().equals(Float.class))
				stream.writeFloat((float)o);
			if (o.getClass().equals(Double.class))
				stream.writeDouble((double)o);
			if (o.getClass().equals(VarInt.class))
				stream.writeVarInt(((VarInt)o).getValue());
			// todo implm VarLong when it becomes nec
			if (o.getClass().equals(Position.class)) {}// todo
				
			if (o.getClass().equals(UUID.class)) {
				stream.writeLong(((UUID)o).getMostSignificantBits());
				stream.writeLong(((UUID)o).getLeastSignificantBits());
			}
			
			if (o.getClass().equals(String.class)) {
				String str = (String) o;
				stream.writeString(str);
			}
			if (o.getClass().equals(byte[].class)) {
				byte[] bts = (byte[])o;
				for (byte b : bts) {
					stream.writeByte(b);
				}
			}
		}
	}
	
	public static void writePacket(GameOutputStream stream, int id, Object...objs) throws IOException {
		ArrayList<Object> os = new ArrayList<>();
		for (Object o : objs) {
			os.add(o);
		}
		
		writePacket(stream, id, os);
	}
	
}
