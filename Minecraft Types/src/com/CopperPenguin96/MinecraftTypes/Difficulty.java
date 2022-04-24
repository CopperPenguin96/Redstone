package com.CopperPenguin96.MinecraftTypes;

/***
 * 
 * @author CopperPenguin96
 *
 */
public enum Difficulty {
	
	Peaceful(0),
	Easy(1),
	Normal(2),
	Hard(3);

	private int _difficulty = 2;
	
	public int getValue() {
		return _difficulty;
	}
	
	public void setValue(int i) {
		if (i > 3) {
			throw new IndexOutOfBoundsException();
		}
		
		_difficulty = i;
	}
	
	Difficulty(int i) {
		setValue(i);
	}
	
}