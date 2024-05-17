package com.CopperPenguin96.Redstone.Network;

import java.io.*;

import javax.crypto.CipherOutputStream;

import com.CopperPenguin96.Redstone.System.Types.VarInt;


public class GameOutputStream extends DataOutputStream{

	public GameOutputStream(OutputStream out) {
		super(out);
		// TODO Auto-generated constructor stub
	}

	public GameOutputStream(CipherOutputStream os) {
		super(os);
	}

	private static final int SEGMENT_BITS = 0x7F;
	private static final int CONTINUE_BIT = 0x80;
	
	public void writeVarInt(int value) throws IOException {
		while (true) {
			if ((value & ~SEGMENT_BITS) == 0) {
				this.writeByte(value);
				return;
			}
			
			this.writeByte((value & SEGMENT_BITS) | CONTINUE_BIT);
			value >>>= 7;
		}
	}
	
	public void writeVarInt(VarInt value) throws IOException {
		this.writeVarInt(value.getValue());
	}
	
	public void writeVarLong(long value) throws IOException {
		while (true) {
			if ((value & ~((long) SEGMENT_BITS)) == 0) {
				this.writeByte((int) value);
			}
			
			this.writeByte(((int) value & SEGMENT_BITS) | CONTINUE_BIT);
			value >>>= 7;
			
		}
	}
	
	public void writeString(String string) throws IOException {
		this.writeVarInt(string.length());
		this.writeBytes(string);
	}
	
}
