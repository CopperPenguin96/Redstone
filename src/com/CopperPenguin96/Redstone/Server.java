package com.CopperPenguin96.Redstone;

import java.io.*;
import java.net.*;
import java.nio.charset.*;
import java.security.KeyFactory;
import java.security.KeyPair;
import java.security.KeyPairGenerator;
import java.security.PrivateKey;
import java.security.Provider;
import java.security.PublicKey;
import java.security.Security;
import java.security.spec.EncodedKeySpec;
import java.security.spec.X509EncodedKeySpec;
import java.util.ArrayList;
import java.util.UUID;

import org.bouncycastle.jce.provider.BouncyCastleProvider;

import com.CopperPenguin96.Redstone.Configuration.Config;
import com.CopperPenguin96.Redstone.Network.Protocol;
import com.CopperPenguin96.Redstone.Players.*;
import com.CopperPenguin96.Redstone.System.*;


public class Server {
	public static boolean isRunning = false;
	public final static Charset CHARSET = StandardCharsets.UTF_8;
	
	public static final Version SoftwareVersion = new Version();
	public static final Version MinecraftVersion = new Version(1, 20, 4);
	
	public static ArrayList<UUID> OnlinePlayers = new ArrayList<>();
	public static KeyPair KeyPair;
	
	public static void run() throws Exception {
		Security.setProperty("crypto.policy", "unlimited");
		Security.addProvider(new BouncyCastleProvider());
		Security.addProvider(KeyFactory.getInstance("RSA").getProvider());
		
		var gen = KeyPairGenerator.getInstance("RSA");
		gen.initialize(1024);
		KeyPair = gen.genKeyPair();
		
		init();
		isRunning = true;
		try {
			int port = Config.getValue("port").getAsInt();
			ServerSocket serverSocket = new ServerSocket(port);
			System.out.println("Server is running on " + port);
			while (isRunning) {
				Player player = new Player();
				player.Socket = serverSocket.accept();
				
				System.out.println("Client accepted");
				while (player.Socket.isConnected()) {
					try {
						Protocol.listen(player, player.Socket.getInputStream());
						Config.getValue("time-format");
					} catch (EOFException ex) {
						break;
					}
				}
				
				
			}
			
		} catch (IOException e) {
			e.printStackTrace();
			isRunning = false;
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
	
	public static void init() throws Exception {
		File dir = new File("Redstone/");
		if (!dir.exists()) {
			dir.mkdirs();
		}
		
		try {
			Config.init();
		} catch (IOException e) {
			Config.loadDefaults();
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
}
