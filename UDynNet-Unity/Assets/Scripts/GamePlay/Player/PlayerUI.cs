using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {

	[SerializeField]
	private Text nameUI;
	[SerializeField]
	private Text healthUI;
	[SerializeField]
	private Text playerListUI;
	[SerializeField]
	private Text chatBoxUI;

	void Awake(){
		Canvas canvas = transform.GetComponentInChildren<Canvas>();
		NameUI = canvas.transform.FindChild("Name").GetComponent<Text>();
		HealthUI = canvas.transform.FindChild("Health").GetComponent<Text>();
		PlayerListUI = canvas.transform.FindChild("PlayerList").GetComponent<Text>();
		ChatBoxUI = canvas.transform.FindChild("ChatBox").GetComponent<Text>();
	}

	public Text NameUI {get{return nameUI;} set{nameUI = value;}}
	public Text HealthUI {get{return healthUI;} set{healthUI = value;}}
	public Text PlayerListUI {get{return playerListUI;} set{playerListUI = value;}}
	public Text ChatBoxUI {get{return chatBoxUI;} set{chatBoxUI = value;}}

	public void fillPlayers(List<string> players){
		playerListUI.text = "";
		foreach(string player in players){
			playerListUI.text += player + "\n";	
		}
	}
}
