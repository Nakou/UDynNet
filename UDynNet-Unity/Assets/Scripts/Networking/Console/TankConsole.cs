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

	string strInput;

	//
	// Create console window, register callbacks
	//
	void Awake() 
	{
		DontDestroyOnLoad( gameObject );

		console.Initialize();
		console.SetTitle( "TankU Server" );

		input.OnInputText += OnInputText;

		Application.logMessageReceived += HandleLog;

		Debug.Log( "Console Started" );
	}

	//
	// Text has been entered into the console
	// Run it as a console command
	//
	void OnInputText( string obj )
	{
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
				message = "[INFO] " + message;
				System.Console.ForegroundColor = ConsoleColor.White;
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
		if("exit".Equals(command)){
			Debug.Log("Closing server...");
			Application.Quit();
			return;
		}
		Debug.Log("Command unknown...");
	}

	#endif
}