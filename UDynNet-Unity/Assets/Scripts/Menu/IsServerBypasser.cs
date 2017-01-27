using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IsServerBypasser : MonoBehaviour {
	#if SERVER && !CLIENT
	// Use this for initialization
	void Start () {
		SceneManager.LoadScene("Prototype");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	#endif
}
