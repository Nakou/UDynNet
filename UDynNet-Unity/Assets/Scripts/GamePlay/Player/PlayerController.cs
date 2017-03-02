using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class PlayerController : NetworkBehaviour {

	[SerializeField] private float moveSpeed;
	[SerializeField] private PlayerUI ui;
	[SerializeField] private GameObject serverInfos;
	[SerializeField] Camera cam;

	private bool isConnected = false;

	void Awake(){
		name = ""+Random.Range(1,1000000);
		ui = gameObject.GetComponent<PlayerUI>();
		serverInfos = GameObject.Find("ServerInfos");
	}

	// Update is called once per frame
	void Update () {
		if(!isLocalPlayer){
			cam.enabled = false;
			return;
		}
		if(!isConnected){
			isConnected = true;
			CmdTellNewConnection(name);
			ui.NameUI.text = "Name : " + name;
			ui.HealthUI.text = "Health : 10HP";
		}
		Moves();
		if(Input.GetKeyDown(KeyCode.Tab)){
			ShowPlayerList();
		}
	}

	void FixedUpdate(){
		
	}

	void Moves(){
		float v = Input.GetAxis("Vertical");
		//gameObject.transform.position += Vector3.forward * (v * Time.deltaTime * moveSpeed);
		gameObject.GetComponent<Rigidbody>().AddForce( cam.transform.forward * v * moveSpeed);

		float rotation = Input.GetAxis("Horizontal") * moveSpeed;
		rotation *= Time.deltaTime;
		gameObject.transform.Rotate(0, rotation, 0);

		if(Input.GetButtonDown("Jump")){
			gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0,moveSpeed,0));
		}
	}

	public override void OnStartLocalPlayer() {
		GetComponent<MeshRenderer>().material.color = Color.blue;
	}

	[Command]
	void CmdTellNewConnection(string name){
		Debug.Log("New Player connection : [" + name + "]");
		serverInfos.GetComponent<ServerInfos>().NewPlayer(name);
	}

	//[Command]
	void ShowPlayerList(){
		List<string> players = new List<string>();
		foreach(string player in serverInfos.GetComponent<ServerInfos>().getPlayerList()){
			players.Add(player);
		}
		ui.fillPlayers(players);
	}
}
