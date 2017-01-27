using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SimpleNetworkHandler : NetworkBehaviour {

	private NakNetworkManager manager;
	// Use this for initialization
	void Awake(){
		manager = gameObject.GetComponent<NakNetworkManager>();
		#if SERVER
		StartServer();
		#endif

		#if CLIENT
		manager.autoCreatePlayer = true;
		Debug.Log("Connection to server...");
		StartClient();
		#endif
	}
	
	// Update is called once per frame
	void Update () {

	}

	void StartServer(){
		manager.StartHost();
	}

	void StartClient(){
		//manager.networkAddress = "localhost";  
		manager.StartClient();
	}
}
