package com.CopperPenguin96.Redstone.Utils;

import java.io.*;
import java.net.*;
import java.util.*;

public class NetTools {

	public static String executeUrl(String target) throws IOException {
		URL url = new URL(target);
		URLConnection connection = url.openConnection();
		BufferedReader in = new BufferedReader(new InputStreamReader(connection.getInputStream()));
		String inputLine;
		ArrayList<String> lines = new ArrayList<>();
		while ((inputLine = in.readLine()) != null) {
			lines.add(inputLine);
		}
		in.close();
		
		String allLines = "";
		for (String s : lines) {
			allLines += s + "\n";
		}
		
		return allLines;
	}
}
