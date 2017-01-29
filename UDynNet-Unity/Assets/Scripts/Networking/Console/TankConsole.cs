using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Security;
using Windows;

#pragma warning disable CS0618 // disable
#pragma warning disable CS0618 // disable

public class TankConsole : MonoBehaviour
{
	#if (UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN) && SERVER && !CLIENT

	Windows.ConsoleWindow console = new Windows.ConsoleWindow();
	Windows.ConsoleInput input = new Windows.ConsoleInput();
	NakNetworkManager networkManager;
	string strInput;

	//
	// Create console window, register callbacks
	//
	void Awake() 
	{
		DontDestroyOnLoad( gameObject );

		console.Initialize();
		console.SetTitle( "UDynNet POC Server" );

		input.OnInputText += OnInputText;
		networkManager = gameObject.GetComponent<NakNetworkManager>();
		Application.logMessageReceived += HandleLog;

		Debug.Log( "Console Started" );
	}

	//
	// Text has been entered into the console
	// Run it as a console command
	//
	void OnInputText( string obj )
	{
		if(obj == null)
			obj = "";
		Debug.Log("Server using command : " + obj);
		Execute(obj);
	}

	//
	// Debug.Log* callback
	//
	void HandleLog( string message, string stackTrace, LogType type )
	{
		if(!message.Contains("[NoConsole]")){
			if ( type == LogType.Warning ) {
				message = "[WARN] " + message;
				System.Console.ForegroundColor = ConsoleColor.Yellow;
			} else if ( type == LogType.Error )	{
				message = "[ERROR] " + message;
				System.Console.ForegroundColor = ConsoleColor.Red;
			} else	{
				if( message.Contains("[RTLines]")){
					string[] mess = message.Split("]".ToCharArray(),2);
					message = mess[1];
					System.Console.ForegroundColor = ConsoleColor.DarkCyan;
				} else {
					message = "[INFO] " + message;
					System.Console.ForegroundColor = ConsoleColor.White;
				}
			}

			// We're half way through typing something, so clear this line ..
			if ( Console.CursorLeft != 0 )
				input.ClearLine();

			System.Console.WriteLine( message );

			// If we were typing something re-add it.
			input.RedrawInputLine();
		}
	}

	//
	// Update the input every frame
	// This gets new key input and calls the OnInputText callback
	//
	void Update()
	{
		input.Update();
	}

	//
	// It's important to call console.ShutDown in OnDestroy
	// because compiling will error out in the editor if you don't
	// because we redirected output. This sets it back to normal.
	//
	void OnDestroy()
	{
		console.Shutdown();
	}

	void Execute(String command){
		if(command.Contains("close")){
			ConsoleReturnLines("Closing server...");
			Application.Quit();
			return;
		}

		if(command.Contains("help")){
			ConsoleReturnLines("close :");
			ConsoleReturnLines("Close the server.");
			ConsoleReturnLines("help :");
			ConsoleReturnLines("Show this screen.");
			ConsoleReturnLines("spawn [prefabName] [x,y,z]");
			ConsoleReturnLines("Spawn the gameobject on the coord.");
			return;
		}

		if(command.Contains("spawn")){
			ConsoleReturnLines("Not implemented yet (: ...");
			return;
		}


		ConsoleReturnLines("Command unknown. Type \"help\" to get the list of commands");
	}

	void ConsoleReturnLines(string line){
		Debug.Log("[RTLines]" + line);
	}

	#endif
}