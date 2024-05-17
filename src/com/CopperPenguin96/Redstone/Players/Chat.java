package com.CopperPenguin96.Redstone.Players;

import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.*;
import java.util.HashMap;

import com.CopperPenguin96.Redstone.Server;
import com.CopperPenguin96.Redstone.Configuration.Config;
import com.CopperPenguin96.Redstone.Utils.MinecraftFormatting;

public final class Chat {
	
	public static String format(String rawMessage, Player player) throws Exception {
		String raw = "&r"+ rawMessage; // ensures all parts get added to the json builder
		if (player != null) {
			raw = replace(raw, "$name", player.getDisplayName());
			raw = replace(raw, "$kicks", player.getKicks());
			raw = replace(raw, "$money", player.getMoney());	
			raw = replace(raw, "$bans", player.getBans());
		}
		
		for (String key : defs().keySet()) {
			raw = replace(raw, key, defs().get(key));
		}
		
		List<String> colors = List.of(new String[]{"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f"});	
		List<String> formats = List.of(new String[] {"k", "l", "m", "n", "o", "r"});
		// if there are no formatting codes, just send the message
		if (!raw.contains("&")) return "{\"text:\"" + raw + "\"}";
		
		// Split the message up by the formatting code
		String[] splits = raw.split("&");
		
		// Array to store the index(es) of the character codes
		ArrayList<Integer> includeInNext = new ArrayList<>();
		
		// Begin building the json string
		String json = "{ ";
		
		// The building blocks of the json
		ArrayList<String> jsonParts = new ArrayList<String>();
		
		// Goes over each split
		for (int x = 0; x < splits.length; x++) {
			String currentSplit = splits[x];
			
			// If the current split is worthless, skip over it
			if (currentSplit.length() == 0) continue;
			
			// If the current split is just a code (meaning more follow after
			// Then record that it still needs to be used, continue to next
			if (currentSplit.length() == 1) {
				includeInNext.add(x);
				continue;
			} else { 
				// Verify that the code is appropiate				
				for (String col : colors) {
					if (col.equals(currentSplit.charAt(0) + "")) {
						includeInNext.add(x);
						currentSplit = currentSplit.substring(1);
					}
				}
				
				for (String form : formats) {
					if (form.equals(currentSplit.charAt(0) + "")) {
						includeInNext.add(x);
						currentSplit = currentSplit.substring(1);
					}
				}
			}
			
			boolean alreadyColor = false;
			String codeJson = "\"text\": \"" + currentSplit + "\""; // ensure string open and close stays out here or else will double/triple text
			String codeJDef = "\"text\": \"" + currentSplit + "\""; // used for resetting
			for (int i = 0; i < includeInNext.size(); i++) { // go over each code, apply as needed
				// If most recent code is to reset, do that first. Skip rest
				if (splits[includeInNext.get(i)].toLowerCase().equals("r")) {
					codeJson = codeJDef; // resets
					
					continue; // skip rest
				} else {
					
					String code = splits[includeInNext.get(i)].charAt(0) + "";
					String name = MinecraftFormatting.codeToId(code);
					
					if (colors.contains(code)) {
						// If coloring already applied to this patch of string, skip coloring
						if (!alreadyColor) {
							codeJson += ", \"color\": \"" + name + "\"";
							alreadyColor = true;
						}
					}
					
					// Apply formatting
					if (code.equals("l")) {
						codeJson += ", \"bold\": true";
					}
					
					if (code.equals("o")) {
						codeJson += ", \"italic\": true";
					}
					
					if (code.equals("n")) {
						codeJson += ", \"underlined\": true";
					}
					
					if (code.equals("m")) {
						codeJson += ", \"strikethrough\": true";
					}
					
					if (code.equals("k")) {
						codeJson += ", \"obfuscated\": true";
					}
					
					
				}
				
			}
			jsonParts.add(codeJson);
			includeInNext.clear();
		}
		
		// Loop through each json part we just hardcoded
		for (int z = 0; z < jsonParts.size(); z++) {
			if (z == 0) {  // get the first
				json += jsonParts.get(z);
			} else if (jsonParts.size() > 1) { // if there are more
				
				if (z == 1) { // add the extra tag, then proceed to add those under extra
					json += ", \"extra\": [{" +
                            jsonParts.get(z) + "}";
				} else {
					
					json += ",{" + jsonParts.get(z) + "}";
				}
				
				if (z == jsonParts.size() - 1) {
					json += "]"; // finish the extra tag
				}
			}
		}
		
		json += "}"; // close the json build
		return json; // BAM 
	}
	
	private static HashMap<String, String> defs() throws Exception {
		
		DateFormat dateFormat = new SimpleDateFormat("dd/MM/yyyy");
		
		HashMap<String, String> map = new HashMap<>();
		map.put("$awesome", "It is my professional opinion that " +
				Config.getServerName() + " is the best server on Minecraft!");
		map.put("$server", Config.getServerName());
		map.put("$motd", Config.getMotd());
		map.put("$date", dateFormat.format(new Date(System.currentTimeMillis())));
		
		Calendar c = Calendar.getInstance();
		String time = "";
		if (Config.is12HourFormat()) {
			
			time += c.get(Calendar.HOUR);
			time += ":";
			time += c.get(Calendar.MINUTE) + " ";
			
			if (c.get(Calendar.AM_PM) == 0) time += "AM";
			else time += "PM";
		} else if (Config.is24HourFormat()) {
			time += c.get(Calendar.HOUR_OF_DAY);
			time += ":";
			time += c.get(Calendar.MINUTE);
		}
		
		map.put("$time", time);
		map.put("$mad", "You &cmad&r, bro?");
		map.put("$welcome", "Welcome to " + Config.getServerName());
		map.put("$clap", "A round of applause might be appropiate. *claps*");
		map.put("$redstone", "Running Redstone v" + Server.SoftwareVersion.toString());
		
		String pl;
		switch (Server.OnlinePlayers.size()) {
			case 0:
				pl = "There is currently no one online.";
				break;
			case 1:
				pl = "There is currently 1 player online.";
				break;
			default:
				pl = "There are currently " + Server.OnlinePlayers.size() + " players online right now.";
				break;
		}
		
		map.put("$players", pl);
		map.put("$website", Config.getWebsite());
		// todo moron randomizer (complete and total moron)
		// todo discord
		// todo colors
		return map;
	}
	
	private static String replace(String raw, String phrase, int val) {
		return raw.replace(phrase, "" + val);
	}
	
	private static String replace(String raw, String phrase, String val) {
		return raw.replace(phrase, val);
	}
}
