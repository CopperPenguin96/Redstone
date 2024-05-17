package com.CopperPenguin96.Redstone.Configuration;

public class ConfigString extends ConfigKey<String> {
	
	@Override
	public String getValue() {
		return super.Value;
	}
	
	@Override
	public void setValue(String val) {
		if ((val.length() < super.Low || val.length() > super.Max) && !_minLowNotSet)
			throw new StringIndexOutOfBoundsException();
		
		super.setValue(val);
	}
	
	public ConfigString(String val) {
		super();
		this.setValue(val);
	}
}
