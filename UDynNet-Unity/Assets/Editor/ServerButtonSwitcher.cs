using UnityEngine;
using System.Collections;
using UnityEditor;

public class ServerButtonSwitcher : MonoBehaviour {

	[MenuItem("Networking Mod/Server",false,1)]
	private static void setServerOn(){
		string newDefine = "SERVER";
		string[] definesTab = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone).Split(';');
		PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone,getOldDefines(definesTab, newDefine));
	}

	[MenuItem("Networking Mod/Client",false,2)]
	private static void setClientOn(){
		string newDefine = "CLIENT";
		string[] definesTab = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone).Split(';');
		PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone,getOldDefines(definesTab, newDefine));
	}

	[MenuItem("Networking Mod/Client+Server",false,51)]
	private static void setClientServerOn(){
		string newDefine = "CLIENT;SERVER";
		string[] definesTab = PlayerSettings.GetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone).Split(';');
		PlayerSettings.SetScriptingDefineSymbolsForGroup(BuildTargetGroup.Standalone,getOldDefines(definesTab, newDefine));
	}

	private static string getOldDefines(string[] defines, string newDefine){
		string finalList = "";
		for(int i = 0; i < defines.Length; i++){
			if(!(defines[i].Equals("SERVER") || defines[i].Equals("CLIENT"))){
				if(!finalList.Equals(""))
					finalList += ";";
				finalList += defines[i];
			}
		}
		if(!finalList.Equals(""))
			finalList += ";";
		finalList += newDefine;
		return finalList;
	}

}
