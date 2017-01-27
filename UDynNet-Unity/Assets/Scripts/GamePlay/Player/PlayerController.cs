using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;

public class PlayerController : NetworkBehaviour {

	[SerializeField]
	private float moveSpeed;

	private bool isConnected = false;

	// Use this for initialization
	void Start () {
	}

	void Awake(){
		name = ""+Random.Range(1,1000000);
	}

	[Command]
	void CmdTellNewConnection(string name){
		Debug.Log("New Player connection : [" + name + "]");
	}
	
	// Update is called once per frame
	void Update () {
		if(!isLocalPlayer)
			return;
		if(!isConnected){
			isConnected = true;
			CmdTellNewConnection(name);
		}
		Moves();
	}

	void FixedUpdate(){
		
	}
		
	void Moves(){
		if(isServer){
			Debug.Log("[NoConsole]"+name);
		}

		float v = Input.GetAxis("Vertical");
		gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0,0, v * moveSpeed));

		float rotation = Input.GetAxis("Horizontal") * moveSpeed;
		rotation *= Time.deltaTime;
		gameObject.transform.Rotate(0, rotation, 0);

		if(Input.GetButtonDown("Jump")){
			gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0,moveSpeed,0));
		}
	}

	public override void OnStartLocalPlayer()
	{
		GetComponent<MeshRenderer>().material.color = Color.blue;
	}
}
