package com.CopperPenguin96.Redstone.Configuration;

public class ConfigKey<T> {
	protected T Value;
	
	protected long Low;
	protected long Max;
	protected boolean _minLowNotSet = false;
	
	public T getValue() {
		return Value;
	}
	
	public void setValue(T val) {
		Value = val;
	}
	
	public ConfigKey() {
		_minLowNotSet = true;
	}
	
	public ConfigKey(T val) {
		Value = val;
	}
	
	public ConfigKey(long max) {
		Max = max;
	}
	
	public ConfigKey(long low, long max) {
		Low = low;
		Max = max;
	}
	
	public String getAsString() {
		return Value.toString();
	}
	
	public short getAsShort() {
		return (short) Value;
	}
	
	public int getAsInt() {
		return (int) Value;
	}
	
	public long getAsLong() {
		return (long) Value;
	}
	
	public boolean getAsBool() {
		return (boolean) Value;
	}
}
