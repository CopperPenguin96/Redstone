package com.CopperPenguin96.Redstone.System.Types;

import com.CopperPenguin96.Redstone.Utils.DataTypeLength;

public class Position {

	public static final int Length = DataTypeLength.Pos;
	
	private int[] _points = new int[3];
	
	public int getX() {
		return _points[0];
	}
	
	public void setX(int x) {
		_points[0] = x;
	}
	
	public int getY() {
		return _points[1];
	}
	
	public void setY(int y) {
		_points[1] = y;
	}
	
	public int getZ() {
		return _points[2];
	}
	
	public void setZ(int z) {
		_points[2] = z;
	}
	
	public Position(int x, int y) {
		setX(x);
		setY(y);
	}
	
	public Position(int x, int y, int z) {
		setX(x);
		setY(y);
		setZ(z);
	}
}
