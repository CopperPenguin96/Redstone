package com.CopperPenguin96.Redstone.Configuration;

public class ConfigInt extends ConfigKey<Integer> {

	@Override
	public Integer getValue() {
		return super.Value;
	}
	
	@Override
	public void setValue(Integer val) {
		if ((val < super.Low || val > super.Max) && !_minLowNotSet)
			throw new IndexOutOfBoundsException();
		
		super.setValue(val);
	}
	
	public ConfigInt(Integer val) {
		super();
		this.setValue(val);
	}
}
