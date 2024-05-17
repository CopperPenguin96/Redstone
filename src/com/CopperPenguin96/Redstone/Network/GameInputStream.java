package com.CopperPenguin96.Redstone.Network;

import java.io.*;

import com.CopperPenguin96.Redstone.Server;
import com.CopperPenguin96.Redstone.System.Types.VarInt;

public class GameInputStream extends DataInputStream {

	
	public GameInputStream(InputStream in) {
		super(in);
		// TODO Auto-generated constructor stub
	}

	@Override
	public int read() throws IOException {
		// TODO Auto-generated method stub
		return 0;
	}

	private static final int SEGMENT_BITS = 0x7F;
	private static final int CONTINUE_BIT = 0x80;
	
	public int readVarInt() throws IOException {
		int value = 0;
		int pos = 0;
		byte currentByte;
		
		while (true) {
			currentByte = this.readByte();
			value |= (currentByte & SEGMENT_BITS) << pos;
			
			if ((currentByte & CONTINUE_BIT) == 0) break;
			pos += 7;
			
			if (pos >= 32) throw new RuntimeException("VarInt is too big");
		}
		
		return value;
	}
	
	public long readVarLong() throws IOException {
		long value = 0;
		int pos = 0;
		byte currentByte;
		
		while (true) {
			currentByte = this.readByte();
			value |= (long) (currentByte & SEGMENT_BITS) << pos;
			
			if ((currentByte & CONTINUE_BIT) == 0) break;
			pos += 7;
			
			if (pos >= 64) throw new RuntimeException("VarLong is too big");
		}
		
		return value;
	}
	
	public byte[] readByteArray(int length) throws IOException {
		var result = new byte[length];
		if (length == 0) return result;
		int n = length;
		
		while (true) {
			n -= this.read(result, length - n, n);
			if (n == 0) break;
		}
		return result;
	}
	
	public short[] readShortArray(int length) throws IOException {
		var result = new short[length];
		if (length == 0) return result;
		
		for (int i = 0; i < length; i++) {
			result[i] = this.readShort();
		}
		
		return result;
	}
	
	public int[] readIntArray(int length) throws IOException {
		var result = new int[length];
		if (length == 0) return result;
		
		for (int i = 0; i < length; i++) {
			result[i] = this.readInt();
		}
		
		return result;
	}
	
	public long[] readLongArray(int length) throws IOException {
		var result = new long[length];
		if (length == 0) return result;
		
		for (int i = 0; i < length; i++) {
			result[i] = this.readLong();
		}
		
		return result;
	}
	
	public String readString() throws IOException {
		int length = this.readVarInt();
		if (length == 0) return "";
		byte[] data = this.readByteArray(length);
		return new String(data, Server.CHARSET);
	}
}
