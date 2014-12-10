using UnityEngine;
using System.Collections;

public class GamOverScreen : MonoBehaviour {

	// Use this for initialization
	void OnGUI () {
		GUI.Box (new Rect (Screen.width / 3, Screen.height / 3, Screen.width / 3, Screen.height / 3), "Game Over fgt");
		Debug.Log("GUI");

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
