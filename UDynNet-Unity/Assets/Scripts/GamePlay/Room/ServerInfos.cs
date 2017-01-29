using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ServerInfos : NetworkBehaviour {
	
	[SerializeField]
	private int playerCount = 0;
	[SerializeField]
	private List<string> playerList;

	void Awake(){
		playerList = new List<string>();
		Debug.Log("Awake!");
	}

	void Update(){
		//Debug.Log("Hello!" + gameObject);
	}

	public void NewPlayer(string name){
		if(playerList == null){
			playerList = new List<string>();
		}
		playerList.Add(name);
	}

	public string getPlayerList(){
		return playerList.ToString();
	}
}
