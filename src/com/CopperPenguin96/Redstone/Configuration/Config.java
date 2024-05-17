package com.CopperPenguin96.Redstone.Configuration;

import java.io.*;
import java.nio.file.Files;
import java.util.*;

import org.json.*;

public class Config {
	public static final int Version = 0;
		
	private static HashMap<String, ConfigKey> _items = new HashMap<>();
	
	public static <T> void setValue(String key, T value) {
		if (_items.containsKey(key)) {
			_items.remove(key);
		}
		
		ConfigKey<T> val = new ConfigKey<T>(value);
		_items.put(key, val);
	}
	
	public static ConfigKey getValue(String key) throws Exception {
		if (!_items.containsKey(key)) {
			System.out.println("Config Key not found for " + key + ". Default will be attemped to load.");
			loadDefaults(key);
		}
		
		return _items.get(key);
	}
	
	public static void init() throws Exception {
		File configFile = new File("Redstone/config.json");
		
		if (!configFile.exists()) {
			loadDefaults();
			save();
			return;
		} else {
			load();
			return;
		}
	}	
	
	public static void loadDefaults(String...keysToSet) throws Exception {
		loadDefaults(true, keysToSet);
	}
	
	public static void loadDefaults(boolean save, String...keysToSet) throws Exception {
		ArrayList<String> ts = new ArrayList<String>();
		
		if (keysToSet != null) {
			for (String s : keysToSet) {
				ts.add(s);
			}
		}
		
		
		if (ts.isEmpty()) { // loading all defaults
			_items.clear();
			for (String key : defValues().keySet()) {
				Config.setValue(key, defValues().get(key).getValue());
			}
		} else { // loading only some defaults
			for (String key : ts) {
				if (!defValues().containsKey(key))
					throw new Exception("Key not found: " + key);
				
				Config.setValue(key, defValues().get(key).getValue());
			}
		}
		
		if (save) {
			Config.save();
		}
	}
	
	private static HashMap<String, ConfigKey> defValues() {
		HashMap<String, ConfigKey> defs = new HashMap<>();
		
		// General
		defs.put("server-name", new ConfigString("[Redstone] Default Server"));
		defs.put("port", new ConfigInt(25565));
		defs.put("max-players", new ConfigInt(20));
		defs.put("motd", new ConfigString("Welcome to the server!"));
		defs.put("time-format", new ConfigInt(0));
		defs.put("website", new ConfigString("https://www.change-me.com"));
		return defs;
	}
	
	public static String getServerName() throws Exception {
		return getValue("server-name").getAsString();
	}
	
	public static int getPort() throws Exception {
		return getValue("port").getAsInt();
	}
	
	public static int getMaxPlayers() throws Exception {
		return getValue("max-players").getAsInt();
	}
	
	public static String getMotd() throws Exception {
		return getValue("motd").getAsString();
	}
	
	public static boolean is24HourFormat() throws Exception {
		return getValue("time-format").getAsInt() == 1;
	}
	
	public static boolean is12HourFormat() throws Exception {
		return getValue("time-format").getAsInt() == 0;
	}
	
	public static String getWebsite() throws Exception {
		return getValue("website").getAsString();
	}
	
	public static void save() throws IOException {
		JSONObject obj = new JSONObject();
		obj.put("version", Version);
		
		for (String key : _items.keySet()) {
			obj.put(key, _items.get(key).getValue());
		}
		
		FileWriter fWriter = new FileWriter("Redstone/config.json");
		fWriter.write(obj.toString(4));
		fWriter.flush();
		fWriter.close();
		
		System.out.println("Config saved");
	}
	
	public static void load() throws IOException {
		String content = Files.readString(new File("Redstone/config.json").toPath());
		_items.clear();
		
		JSONTokener tokener = new JSONTokener(content);
		JSONObject obj = new JSONObject(tokener);
		
		int ver = obj.getInt("version"); // do something with
		
		for (String key : obj.keySet()) {
			if (key.equals("version")) {
				// ignore
			} else {
				Config.setValue(key, obj.get(key));
			}
		}
		
		System.out.println("Config loaded");
	}
}
