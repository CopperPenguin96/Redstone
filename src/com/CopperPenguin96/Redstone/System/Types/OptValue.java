package com.CopperPenguin96.Redstone.System.Types;

public class OptValue<T> {

	private boolean _enabled;
	public boolean isEnabled() {
		return _enabled;
	}
	
	public void setEnabled(boolean enabled) {
		_enabled = enabled;
	}
	
	public void setEnabled() {
		_enabled = true;
	}
	
	private T _value;
	
	public void setValue(T val) {
		_value = val;
	}
	
	public T getValue() {
		return _value;
	}
	
	/**
	 * Assumes nothing
	 * @param enabled
	 * @param value
	 */
	public OptValue(boolean enabled, T value) {
		setEnabled(enabled);
		setValue(value);
	}
	
	/**
	 * Assumes value is preset.
	 * @param value
	 */
	public OptValue(T value) {
		setEnabled();
		setValue(value);
	}
	
	/**
	 * Assumes value is not present.
	 */
	public OptValue() {
		setEnabled(false);
	}
}
