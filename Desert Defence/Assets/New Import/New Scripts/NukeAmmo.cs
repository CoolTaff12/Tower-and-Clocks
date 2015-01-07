using UnityEngine;
using System.Collections;

public class NukeAmmo : MonoBehaviour 
{
	public GameManager gameMgr;
	public static int Nuke_clear;
	
	void Start () 
	{
		Nuke_clear = 0;
	}


	void Update () 
	{
		CountingNukes ();
		Debug.Log("The amount of Nukes: " + Nuke_clear);
	}

	void CountingNukes ()
	{
		if(gameMgr.score >= 100)
		{
			Nuke_clear ++;
		}
	}
}
