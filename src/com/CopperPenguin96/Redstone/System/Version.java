package com.CopperPenguin96.Redstone.System;


public class Version {

	private int _major = 1;
	private int _minor = 0;
	private int _build = -1;
	private int _rev = -1;
	
	public void setMajor(int major) {
		if (major < 1) throw new IndexOutOfBoundsException("major");
		
		_major = major;
	}
	
	public int getMajor() {
		return _major;
	}
	
	public void setMinor(int minor) {
		if (minor < 0) throw new IndexOutOfBoundsException("minor");
		
		_minor = minor;
	}
	
	public int getMinor() {
		return _minor;
	}
	
	public void setBuild(int build) {
		if (build < 0) _build = -1;
		else _build = build;
	}
	
	public int getBuild() {
		return _build;
	}
	
	public void setRevision(int rev) {
		if (rev < 0) _rev = -1;
		else _rev = rev;
	}
	
	public int getRevision() {
		return _rev;
	}
	
	@Override
	public String toString() {
		if (_build > -1 && _rev > -1) {
			return _major + "." + _minor + "." + _build + "." + _rev;
		} else if (_build > -1 & _rev == -1) {
			return _major + "." + _minor + "." + _build;
		} else {
			return _major + "." + _minor;
		}
	}
	
	public Version(int major, int minor, int build, int rev) {
		setMajor(major);
		setMinor(minor);
		setBuild(build);
		setRevision(rev);
	}
	
	public Version(int major, int minor, int build) {
		this(major, minor, build, -1);
	}
	
	public Version(int major, int minor) {
		this(major, minor, -1, -1);
	}
	
	public Version() {
		this(1, 0, -1, -1);
	}
}

