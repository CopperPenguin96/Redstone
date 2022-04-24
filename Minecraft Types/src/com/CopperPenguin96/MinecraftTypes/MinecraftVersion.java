package com.CopperPenguin96.MinecraftTypes;

public class MinecraftVersion {

	public final static MinecraftVersion Current = 
			new MinecraftVersion(756, 1, 17, 1);
	
	public int Protocol;
	
	public MinecraftVersion(int protocol, int major, int minor, int build, int rev) {
		Major = major;
		Minor = minor;
		Build = build;
		Revision = rev;
		Protocol = protocol;
	}
	
	public MinecraftVersion(int protocol, int major, int minor, int build) {
		this(protocol, major, minor, build, -1);
	}
	
	public MinecraftVersion(int protocol, int major, int minor) {
		this(protocol, major, minor, -1, -1);
	}
	
	public MinecraftVersion(int protocol, int major) {
		this(protocol, major, 0, -1, -1);
	}
	
	public MinecraftVersion(int protocol) {
		this(protocol, 1, 0, -1, -1);
	}
	
	public MinecraftVersion() {
		this(0, 1, 0, -1, -1);
	}
	
	public int Major;
	public int Minor;
	public int Build;
	public int Revision;
	
	@Override
	public String toString() {
		StringBuilder builder = new StringBuilder(Major + "." + Minor);
		if (Build <= -1) return builder.toString();
		builder.append("." + Build);
		if (Revision > -1) builder.append("." + Revision);
		return builder.toString();
	}
}