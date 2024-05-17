package com.CopperPenguin96.Redstone.Players;

import com.CopperPenguin96.Redstone.System.Types.OptValue;

public class PlayerProperty {

	public String Name;
	public String Value;
	
	public OptValue<String> Signature;
	
	public PlayerProperty(String name, String value, String signature) {
		Name = name;
		Value = value;
		
		Signature = new OptValue<String>();
		if (signature != null) {
			Signature.setEnabled();
			Signature.setValue(signature);
		}
	}
}
