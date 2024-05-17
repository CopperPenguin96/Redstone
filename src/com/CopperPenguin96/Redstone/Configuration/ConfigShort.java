package com.CopperPenguin96.Redstone.Configuration;

public class ConfigShort extends ConfigKey<Short> {

	@Override
	public Short getValue() {
		return super.Value;
	}
	
	@Override
	public void setValue(Short val) {
		if ((val < super.Low || val > super.Max) && !_minLowNotSet)
			throw new IndexOutOfBoundsException();
		
		super.setValue(val);
	}
	
	public ConfigShort(Short val) {
		super();
		this.setValue(val);
	}
}
