package com.CopperPenguin96.Redstone.Players;

public enum ClientState {
	Handshake(0),
	Status(1),
	Login(2),
	Config(3),
	Play(4);
	
	private int _state;
	private ClientState(int state) {
		_state = state;
	}
	
	public ClientState get() {
		switch (_state) {
			case 0:
				return ClientState.Handshake;
			case 1:
				return ClientState.Status;
			case 2:
				return ClientState.Login;
			case 3:
				return ClientState.Config;
			case 4:
				return ClientState.Play;
		}
		
		return ClientState.Handshake;
	}
}
