package com.CopperPenguin96.Redstone.System.Types;

public enum Difficulty {
	Peaceful(0),
	Easy(1),
	Normal(2),
	Hard(3);
	
	public int _val;
	private Difficulty(int val) {
		_val = val;
	}
}
