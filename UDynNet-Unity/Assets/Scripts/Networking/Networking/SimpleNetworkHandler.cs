using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SimpleNetworkHandler : MonoBehaviour {

	private NakNetworkManager manager;

	[SerializeField]
	GameObject serverPrefab;

	List<NetworkClient> playerlist;

	bool initServerObject = false;

	// Use this for initialization
	void Awake(){
		manager = gameObject.GetComponent<NakNetworkManager>();
		#if SERVER && !CLIENT
		StartServer();
		#endif

		#if CLIENT && !SERVER
		Debug.Log("Connection to server...");
		StartClient();
		#endif

		#if CLIENT && SERVER
		Debug.Log("Connection to server...");
		StartLocalClient();
		#endif
		GameObject gObj = Instantiate(serverPrefab);
		gObj.name = serverPrefab.name;
		NetworkServer.Spawn(gObj);
		Debug.Break();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void StartServer(){
		manager.StartServer();
	}

	void StartClient(){
		manager.StartClient();
	}

	void StartLocalClient(){
		manager.StartHost();
	}
}
