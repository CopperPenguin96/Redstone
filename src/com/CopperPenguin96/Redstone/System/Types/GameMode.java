package com.CopperPenguin96.Redstone.System.Types;

public enum GameMode {
	Survival(0),
	Creative(1),
	Adventure(2),
	Hardcore(3);
	
	public int _val;
	private GameMode(int val) {
		_val = val;
	}
}
