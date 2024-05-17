package com.CopperPenguin96.Redstone.Utils;

import com.CopperPenguin96.Redstone.System.Types.VarInt;

public class DataTypeLength {

	public static final byte Boolean = 1;
	public static final byte Byte = 1;
	public static final byte Short = 2;
	public static final byte Int = 4;
	public static final byte Long = 8;
	public static final byte Float = 4;
	public static final byte Double = 8;
	public static final byte Pos = 8;
	public static final byte Angle = 1;
	public static final byte UUID = 16;
	
	public static int getVarIntLength(int i) {
		return new VarInt(i).length();
	}
}
