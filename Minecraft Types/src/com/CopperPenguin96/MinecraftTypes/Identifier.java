package com.CopperPenguin96.MinecraftTypes;

public class Identifier {
	public String Namespace = "minecraft";
	public String Name;
	
	@Override
	public String toString() {
		if (Namespace.isEmpty()) {
			Namespace = "minecraft";
		}
		
		return Namespace + ":" + Name;
	}
	
	public Identifier(String namespace, String name) {
		Namespace = namespace;
		Name = name;
	}
	
	public Identifier(String name) {
		this("minecraft", name);
	}
}
