package com.CopperPenguin96.Redstone.Configuration;

public class ConfigLong extends ConfigKey<Long> {

	@Override
	public Long getValue() {
		return super.Value;
	}
	
	@Override
	public void setValue(Long val) {
		if ((val < super.Low || val > super.Max) && !_minLowNotSet)
			throw new IndexOutOfBoundsException();
		
		super.setValue(val);
	}
	
	public ConfigLong(Long val) {
		super();
		this.setValue(val);
	}
}
