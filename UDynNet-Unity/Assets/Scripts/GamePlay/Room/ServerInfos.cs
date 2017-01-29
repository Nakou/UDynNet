using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ServerInfos : NetworkBehaviour {
	
	[SerializeField]
	[SyncVar]
	private int playerCount = 0;

	[SerializeField]
	[SyncVar]
	private SyncListString playerList;

	void Awake(){
		playerList = new SyncListString();
		Debug.Log("Awake!");
		name = "ServerInfos";
	}

	void Update(){
		//Debug.Log("Hello!" + gameObject);
	}

	public void NewPlayer(string name){
		if(playerList == null){
			playerList = new SyncListString();
		}
		playerList.Add(name);
		playerCount = playerList.Count;
	}

	public string getPlayerList(){
		return playerList.ToString();
	}
}
