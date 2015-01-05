using UnityEngine;
using System.Collections;

public class Path2 : MonoBehaviour 
{
	public Transform[] moveToWP2;
	// Use this for initialization
	void Awake ()
	{
		int mtWP2 = 0;
		foreach (Transform t in transform) 
		{
			moveToWP2[mtWP2] = t;
			mtWP2++;
		}
	}
}
