package com.CopperPenguin96.MinecraftTypes;

public class VarInt {

	public final long MAX_VALUE = 2147483647;
	public final long MIN_VALUE = -2147483648;
	
	private long _value;
	
	public long getValue() {
		return _value;
	}
	
	public void setValue(long value) {
		if (value < MIN_VALUE) throw new IndexOutOfBoundsException();
		if (value > MAX_VALUE) throw new IndexOutOfBoundsException();
		_value = value;
	}
	
	public VarInt(long value) {
		setValue(value);
	}
	
	public int getLength() {
		int length = 0;
		while (true) {
			length++;
			if ((_value & 0xFFFFFF80) == 0) {
				break;
			}
			_value >>>= 7;
		}
		
		return length;
	}
}
