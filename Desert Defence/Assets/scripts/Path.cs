using UnityEngine;
using System.Collections;

public class Path : MonoBehaviour {
	public Transform[] moveToWP;
	
	// Use this for initialization
	void Awake () {
		
		int mtWP = 0;
		foreach (Transform t in transform) { //Puts all children of this object into the list of waypoints.
			//Debug.Log(mtWP);
			
			moveToWP[mtWP] = t;
			mtWP++;
		}
		
	}
	
}
