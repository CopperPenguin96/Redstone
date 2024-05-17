package com.CopperPenguin96.Redstone.System.Types;

public class VarInt {
	
	public static final int MAX_VALUE = 2147483647;
	public static final int MIN_VALUE = -2147483648;
	
	private int _value;
	
	public VarInt(int value) {
		setValue(value);
	}
	
	public int getValue() {
		return _value;
	}
	
	public void setValue(int value) {
		if (value < MIN_VALUE) throw new IndexOutOfBoundsException("value");
		if (value > MAX_VALUE) throw new IndexOutOfBoundsException("value");
		_value = value;
	}
	
	@Override
	public boolean equals(Object other) {
		if (other.getClass().equals(int.class)) {
			return (new VarInt((int)other)._value == this._value);
		} else if (other.getClass().equals(VarInt.class)) {
			return ((VarInt)other).getValue() == this.getValue();
		}
		
		return false;
	}
	
	@Override
	public String toString() {
		return "" + _value;
	}
	
	public int length() {
		return getLength(this);
	}
	
	public static int getLength(VarInt v) {
		long _value = v._value;
	    int value = (int)(_value & 0xFFFFFFFFL);
	    int length = 0;
	    while (true) {
	        length++;
	        if ((value & 0xFFFFFF80) == 0)
	            break;
	        value >>>= 7;
	    }
	    return length;
	}
	
	public static int getLength(int i) {
		return getLength(new VarInt(i));
	}
}
