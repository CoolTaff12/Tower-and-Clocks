﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{

		[HideInInspector]
		public int
				health;
		public int startHealth;
		[HideInInspector]
		public int
				gears;
		public int startGears = 45;
		[HideInInspector]
		public int
				score;
		public int startScore = 0;
		public int lastLevel = 0;
		public bool firstScene = true;

	static int enemiesInScene = 0;

		// Use this for initialization
		void Awake ()
		{
				gears = startGears;
				health = startHealth;
				score = startScore;


		}
	
		// Update is called once per frame
		void Update ()
		{
				//Debug.Log ("Gears: " + gears);
				//Debug.Log ("Health: " + health);

		}

}
