package com.CopperPenguin96.MinecraftTypes;

public enum GameMode {

	Survival(0),
	Creative(1),
	Adventure(2),
	Spectator(3);
	
	private int _mode = 0;
	
	public int getValue() {
		return _mode;
	}
	
	private void setValue(int i ) {
		_mode = i;
	}
	
	private GameMode(int i) {
		setValue(i);
	}
}