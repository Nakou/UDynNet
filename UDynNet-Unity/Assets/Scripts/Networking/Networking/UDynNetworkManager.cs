using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class UDynNetworkManager : MonoBehaviour {

	bool isAtStartup = true;

	[SerializeField]
	private int port = 7777;

	[SerializeField]
	private string address = "localhost";

	NetworkClient myClient;

	List<NetworkClient> playerlist;

	public static UDynNetworkManager singleton;
	[SerializeField] bool m_DontDestroyOnLoad = true;

	bool initServerObject = false;

	// Use this for initialization
	/*void Awake() {
		InitializeSingleton();
	}

	void InitializeSingleton() {
		if (singleton != null && singleton == this)	{
			return;
		}
		if (m_DontDestroyOnLoad) {
			if (singleton != null) {
				Destroy(gameObject);
				return;
			}
			singleton = this;
			DontDestroyOnLoad(gameObject);
		} else {
			singleton = this;
		}
	}*/

	void Update() {
		if (isAtStartup)
		{
			#if SERVER
			StartServer();
			#endif

			#if !SERVER && CLIENT
			StartClient();
			#endif

			#if SERVER && CLIENT
			StartLocalClient();
			#endif
		}
	}

	void StartServer() {
		NetworkServer.Listen(port);
		isAtStartup = false;
	}

	void StartClient() {
		myClient = new NetworkClient();
		myClient.RegisterHandler(MsgType.Connect, OnConnected);
		myClient.Connect(address, port);
		isAtStartup = false;
	}

	void StartLocalClient() {
		myClient = ClientScene.ConnectLocalServer();
		myClient.RegisterHandler(MsgType.Connect, OnConnected);     
		isAtStartup = false;
	}


	// client function
	public void OnConnected(NetworkMessage netMsg) {
		Debug.Log("Connected to server");
	}


}
