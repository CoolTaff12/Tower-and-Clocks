using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawn : MonoBehaviour
{
		[SerializeField]
		protected GameObject
				normalPrf;
		[SerializeField]
		protected GameObject
				speedyPrf;
		[SerializeField]
		protected GameObject
				tankyPrf;
		[SerializeField]
		private float
				spawnRateNormal = 0.5f;
		[SerializeField]
		private float
				spawnRateSpeedy = 1f;
		[SerializeField]
		private float
				spawnRateTank = 1.5f;
		[SerializeField]
		private float
				spawnDelay;
		public float wave;
		public int wavePoints = 1;
		public float spawnTimer;
		public float baseSpawnTimer = 20;
		private int targetCountNormal;
		private int targetCountSpeedy;
		private int targetCountTank;
		public int maxNormals = 5;
		public int maxSpeedies = 5;
		public int maxTanks = 2;
		public int NormalsPerWave = 0;
		public int SpeediesPerWave = 0;
		public int TanksPerWave = 0;
		public GameManager gameMgr;

		//------------------------------------
	
		public Texture2D gameMenu;
		public Texture2D pause;

		//-----------------------------------------------
		private enum MenuStates { Runs, PausedMenu, Help1, Help2, Help3, Help4, Options, Tutorial1, Tutorial2, Victory};
		private MenuStates currState;
		public GUISkin trueMenu;
		public Texture2D HTP1;
		public Texture2D HTP2;
		public Texture2D HTP3;
		public Texture2D HTP4;
		public Texture2D Next;
		public Texture2D Back;
		public Texture2D m1;
		public Texture2D m2;
		public Texture2D m3;
		public Texture2D m4;

		//----------------------------------------------
		
		public Texture2D Win;

		//----------------------------------------------

		public GameObject[] noEdit;

		//------------------------------------------------
		void Awake () 
		{
			currState = MenuStates.Runs;
			if(Application.loadedLevelName ==("Tutorial"))
			{
				currState = MenuStates.PausedMenu;
			}
		}
	
		// Use this for initialization
		void Start ()
		{
			noEdit[0].SetActive(true);
			noEdit[1].SetActive(true);
			Time.timeScale = 1f;
			gameMgr = GameObject.Find ("GameManager").GetComponent<GameManager> ();
			wave = 1f;
			spawnTimer = 10;
		}

		void OnGUI()
		{
			if(GUI.skin != trueMenu) 
			{
				GUI.skin = trueMenu;	
			}
			GUI.color = new Color32 (255, 255, 255, 200);
			switch(currState) 
			{
				//For Tutorial Level Only--------------------
				

				//-------------------------------------------
				case MenuStates.Runs:
					DrawRuns();
					break;
				case MenuStates.PausedMenu:
					DrawPausedMenu();
					break;
				case MenuStates.Help1:
					DrawHelp1();
					break;
				case MenuStates.Help2:
					DrawHelp2();
					break;
				case MenuStates.Help3:
					DrawHelp3();
					break;
				case MenuStates.Help4:
					DrawHelp4();
					break; 
				case MenuStates.Options:
					DrawOptions();
					break;
			case MenuStates.Victory:
					DrawVictory();
					break;
			}
		if (wave > 14 
		   	//&& EnemyTarget.Length == 0
		   	&& Application.loadedLevelName ==("Tutorial"))
		{
			currState = MenuStates.Victory;
		}
		if (wave > 16 
		    //&& EnemyTarget.Length == 0
		    && Application.loadedLevelName ==("LevelOne"))
		{
			currState = MenuStates.Victory;
		}

		if (wave > 18 
		 //   && EnemyTarget.Length == 0
		    && Application.loadedLevelName ==("LevelTwo"))
		{
			currState = MenuStates.Victory;
		}

		if (wave > 22 
		   // && EnemyTarget.Length == 0
		    && Application.loadedLevelName ==("LevelFour"))
		{
			currState = MenuStates.Victory;
		}

		if (wave > 24 
		  //  && EnemyTarget.Length == 0
		    && Application.loadedLevelName ==("Herman_27"))
		{
			Time.timeScale = 0f;
			if (GUI.Button (new Rect (300, 400, 200, 101), "Yes!"))
			{
				gameMgr.health += 5;
				gameMgr.gears += 30;
				Application.LoadLevel(Application.loadedLevel + 1);
			}
		}

		if (wave > 28 
	   		//&& EnemyTarget.Length == 0
		    && Application.loadedLevelName ==("LevelSeven"))
		{
			Time.timeScale = 0f;
			if (GUI.Button (new Rect (300, 400, 200, 101), "Yes!"))
			{
				gameMgr.health += 5;
				gameMgr.gears += 30;
				Application.LoadLevel(Application.loadedLevel + 1);
			}
		}

		if (wave > 32 
		 //   && EnemyTarget.Length == 0
		    && Application.loadedLevelName ==("LevelEight"))
		{
			Time.timeScale = 0f;
			if (GUI.Button (new Rect (300, 400, 200, 101), "Yes!"))
			{
				gameMgr.health += 5;
				gameMgr.gears += 30;
				Application.LoadLevel(Application.loadedLevel + 1);
			}
		}

		if (wave > 34 
		   // && EnemyTarget.Length == 0
		    && Application.loadedLevelName ==("Herman_20"))
		{
			Time.timeScale = 0f;
			if (GUI.Button (new Rect (300, 400, 200, 101), "Yes!"))
			{
				gameMgr.health += 5;
				gameMgr.gears += 30;
				Application.LoadLevel(Application.loadedLevel + 1);
			}
		}

		if (wave > 36 
		   // && EnemyTarget.Length == 0
		    && Application.loadedLevelName ==("LevelCave"))
		{
			Time.timeScale = 0f;
			if (GUI.Button (new Rect (300, 400, 200, 101), "Yes!"))
			{
				gameMgr.health += 5;
				gameMgr.gears += 30;
				Application.LoadLevel(Application.loadedLevel + 1);
			}
		}
		if (wave > 40 
		   // && EnemyTarget.Length == 0
		    && Application.loadedLevelName ==("LevelJungle"))
		{
			Time.timeScale = 0f;
			if (GUI.Button (new Rect (300, 400, 200, 101), "Yes!"))
			{
				gameMgr.health += 5;
				gameMgr.gears += 30;
				Application.LoadLevel("Credits");
			}
		}
	}

	//----------------------------------------------------------------------------
		private void DrawRuns()
		{
			Time.timeScale = 1f;
			if (Application.loadedLevelName == ("LevelSeven")) 
			{
				Time.timeScale = 1.5f;
				Debug.Log("Wow, it goes " + Time.timeScale + " as fast!");
			}
			if (GUI.Button (new Rect (Screen.width / 2.4f, 0, Screen.width / 6f, Screen.height / 12f), "")) 
			{
				noEdit[0].SetActive(false);
				noEdit[1].SetActive(false);
				currState = MenuStates.PausedMenu;
			}
			GUI.DrawTexture (new Rect (Screen.width / 2.4f, 0, Screen.width / 6f, Screen.height / 12f), pause);
		}
		private void DrawPausedMenu()
		{
			GUI.DrawTexture (new Rect (Screen.width / 3.5f, Screen.height / 10f, 356,512), gameMenu);
			if (GUI.Button (new Rect (Screen.width / 2.5f, Screen.height / 4f, 156, 64),"resume")) 
			{
				noEdit[0].SetActive(true);
				noEdit[1].SetActive(true);
				currState = MenuStates.Runs;
			}
			if (GUI.Button (new Rect (Screen.width / 2.5f, Screen.height / 1.8f, 156, 64),"help")) 
			{
				currState = MenuStates.Help1;
			}
		if (GUI.Button (new Rect ( Screen.width / 2.5f, Screen.height / 2.6f, 156, 64),"option")) 
		{
			currState = MenuStates.Options;
		}
			if (GUI.Button (new Rect (Screen.width / 2.5f, Screen.height / 1.3f, 156, 64),"")) 
			{
				gameMgr.health = 10;
				gameMgr.gears = 45;
				GameObject CrashMusic = GameObject.FindGameObjectWithTag("Music");
				GameObject DestroyParty = GameObject.Find("Music Box 2");
				GameObject ObliterateFun = GameObject.Find("Music Box 3");
				GameObject TerimatetheJoy = GameObject.Find("Music Box 4");
				GameObject SteamRollHappines = GameObject.Find("Music Box 5");
				Destroy(CrashMusic);
				Destroy(DestroyParty);
				Destroy(ObliterateFun);
				Destroy(TerimatetheJoy);
				Destroy(SteamRollHappines);
				Application.LoadLevel("NewMainMenu");
			}
			Time.timeScale = 0.001f;
		}	

		private void DrawHelp1()
		{
			GUI.DrawTexture (new Rect (Screen.width / 5f, Screen.height / 8f, 600, 280),HTP1);
			if (GUI.Button (new Rect(Screen.width / 2.3f, Screen.height / 1.4f, 200, 80), ""))
			{
				currState = MenuStates.PausedMenu;
			}
			GUI.DrawTexture(new Rect(Screen.width / 2.3f, Screen.height / 1.4f, 200, 80), pause);
		if (GUI.Button (new Rect(Screen.width / 1.4f, Screen.height / 1.6f, 200, 67), ""))
			{
				currState = MenuStates.Help2;
			}
			GUI.DrawTexture(new Rect(Screen.width / 1.4f, Screen.height / 1.6f, 200, 67), Next);
		}
		private void DrawHelp2()
		{
			GUI.DrawTexture (new Rect (Screen.width / 5f, Screen.height / 8f, 600, 280),HTP2);
			if (GUI.Button (new Rect(Screen.width / 2.3f, Screen.height / 1.4f, 200, 80), ""))
			{
				currState = MenuStates.PausedMenu;
			}
			GUI.DrawTexture(new Rect(Screen.width / 2.3f, Screen.height / 1.4f, 200, 80), pause);
			if (GUI.Button (new Rect(Screen.width / 1.4f, Screen.height / 1.6f, 200, 67), ""))
			{
				currState = MenuStates.Help3;
			}
			GUI.DrawTexture(new Rect(Screen.width / 1.4f, Screen.height / 1.6f, 200, 67), Next);
			if (GUI.Button (new Rect(Screen.width / 7f, Screen.height / 1.6f, 200, 67), ""))
			{
				currState = MenuStates.Help1;
			}
			GUI.DrawTexture(new Rect(Screen.width / 7f, Screen.height / 1.6f, 200, 67), Back);
		}
		private void DrawHelp3()
		{
			GUI.DrawTexture (new Rect (Screen.width / 5f, Screen.height / 8f, 600, 280),HTP3);
			if (GUI.Button (new Rect(Screen.width / 2.3f, Screen.height / 1.4f, 200, 80), ""))
			{
				currState = MenuStates.PausedMenu;
			}
			GUI.DrawTexture(new Rect(Screen.width / 2.3f, Screen.height / 1.4f, 200, 80), pause);
			if (GUI.Button (new Rect(Screen.width / 1.4f, Screen.height / 1.6f, 200, 67), ""))
			{
				currState = MenuStates.Help4;
			}
			GUI.DrawTexture(new Rect(Screen.width / 1.4f, Screen.height / 1.6f, 200, 67), Next);
			if (GUI.Button (new Rect(Screen.width / 7f, Screen.height / 1.6f, 200, 67), ""))
			{
				currState = MenuStates.Help2;
			}
			GUI.DrawTexture(new Rect(Screen.width / 7f, Screen.height / 1.6f, 200, 67), Back);
		}
		private void DrawHelp4()
		{
		GUI.DrawTexture (new Rect (Screen.width / 5f, Screen.height / 9.6f, 600, 308),HTP4);
		if (GUI.Button (new Rect(Screen.width / 2.3f, Screen.height / 1.4f, 200, 80), ""))
		{
			currState = MenuStates.PausedMenu;
		}
		GUI.DrawTexture(new Rect(Screen.width / 2.3f, Screen.height / 1.4f, 200, 80), pause);
		if (GUI.Button (new Rect(Screen.width / 7f, Screen.height / 1.6f, 200, 67), ""))
		{
			currState = MenuStates.Help3;
		}
		GUI.DrawTexture(new Rect(Screen.width / 7f, Screen.height / 1.6f, 200, 67), Back);
		
		}


	//---------------------------------------------------------------
	
	private void DrawOptions()
	{	
		GUILayout.BeginArea(new Rect(-250, 100, 1280, 800));
		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		GUILayout.Label("Select Music");
		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
		int changeSong = Main_Menu_Music_Box.music;
		
		if (GUI.Button (new Rect (Screen.width - 660, Screen.height - 320, Screen.width/3, Screen.height/9), ""))
		{
			changeSong = 1;
			Main_Menu_Music_Box.music = changeSong;
		}
		GUI.DrawTexture(new Rect(Screen.width - 660, Screen.height - 320, Screen.width/3, Screen.height/9), m1);
		if (GUI.Button (new Rect (Screen.width - 330, Screen.height - 320, Screen.width/3, Screen.height/9), ""))
		{
			changeSong = 2;
			Main_Menu_Music_Box.music = changeSong;
		}
		GUI.DrawTexture(new Rect(Screen.width - 330, Screen.height - 320, Screen.width/3, Screen.height/9), m2);
		if (GUI.Button (new Rect (Screen.width - 660, Screen.height - 210, Screen.width/3, Screen.height/9), ""))
		{
			changeSong = 3;
			Main_Menu_Music_Box.music = changeSong;
		}
		GUI.DrawTexture(new Rect(Screen.width - 660, Screen.height - 210, Screen.width/3, Screen.height/9), m3);
		if (GUI.Button (new Rect (Screen.width - 330, Screen.height - 210, Screen.width/3, Screen.height/9), ""))
		{
			changeSong = 4;
			Main_Menu_Music_Box.music = changeSong;
		}
		GUI.DrawTexture(new Rect(Screen.width - 330, Screen.height - 210, Screen.width/3, Screen.height/9), m4);
		if (GUI.Button (new Rect(Screen.width / 2.6f, Screen.height / 1.2f, 200, 80), ""))
		{
			currState = MenuStates.PausedMenu;
		}
		GUI.DrawTexture(new Rect(Screen.width / 2.6f, Screen.height / 1.2f, 200, 80), pause);

	}

	//----------------------------------------------------------------------------

	private void DrawVictory()
	{
		noEdit[0].SetActive(false);
		noEdit[1].SetActive(false);
		Time.timeScale = 0f;
		GUI.DrawTexture (new Rect (Screen.width / 6f, Screen.height / 10f, Screen.width / 1.6f, Screen.height / 1.25f), Win);
		if (GUI.Button (new Rect (Screen.width / 4.4f, Screen.height / 1.32f, Screen.width / 6.4f, Screen.height / 9f), ""))
		{
			gameMgr.health += 5;
			gameMgr.gears += 30;
			Application.LoadLevel(Application.loadedLevel + 1);
		}

	}

	//----------------------------------------------------------------------------
	
		// Update is called once per frame
		void Update ()
		{
			spawnTimer -= Time.deltaTime;
			//Debug.Log ("Wave Number: " + wave);
			if (Input.GetKeyDown (KeyCode.Space) || spawnTimer <= 0) 
			{
				SpawnAll ();
			}
			if (targetCountNormal >= maxNormals) 
			{
				CancelInvoke ("SpawnNormal");
				wave++;
				wavePoints++;
				maxNormals += NormalsPerWave;
					targetCountNormal = 0;
			}
			if (targetCountSpeedy >= maxSpeedies) 
			{
				CancelInvoke ("SpawnSpeedy");
				wave++;
				wavePoints++;
				maxSpeedies += SpeediesPerWave;
				targetCountSpeedy = 0;
			}
			if (targetCountTank >= maxTanks) 
			{
				CancelInvoke ("SpawnTank");
				wave++;
				wavePoints++;
				maxTanks += TanksPerWave;
				targetCountTank = 0;
			}
			/*	if(wave > 10 && Application.loadedLevelName ==("Tutorial"))
				{
					Quaternion rot = directionalLight.transform.rotation;
					//rot.y =45.196753f;
					rot.y = 124.39f;
				//	Quaternion tot = 45.19673f);
				//	transform.rotation = Quaternion.Lerp(rot.rotation,

			//Y = 45.19673f
			//Lerp
			//Quaternion.lerp
			//NUvarande

				//directionalLight = GameObject.Find ("Directional light").GetComponent<Light>();

				}*/
		
		}

		public virtual void SpawnNormal ()
		{
				GameObject go = Instantiate (normalPrf, transform.position, Quaternion.identity) as GameObject;
				go.GetComponent<Enemy> ().setSpawner (this);
				go.GetComponent<Enemy> ().gameMgr = gameMgr;
				targetCountNormal++;
				
		}

		public virtual void SpawnSpeedy ()
		{
				GameObject go = Instantiate (speedyPrf, transform.position, Quaternion.identity) as GameObject;
				go.GetComponent<Enemy> ().setSpawner (this);
				go.GetComponent<Enemy> ().gameMgr = gameMgr;
				targetCountSpeedy++;
				//Enemu.count.add (go GameObject)
		}

		public virtual void SpawnTank ()
		{
				GameObject go = Instantiate (tankyPrf, transform.position, Quaternion.identity) as GameObject;
				go.GetComponent<Enemy> ().setSpawner (this);
				go.GetComponent<Enemy> ().gameMgr = gameMgr;
				targetCountTank++;
		}

		public virtual void SpawnAll ()
		{
				InvokeRepeating ("SpawnNormal", 1, spawnRateNormal);
				InvokeRepeating ("SpawnSpeedy", 1, spawnRateSpeedy);
				InvokeRepeating ("SpawnTank", 1, spawnRateTank);
				spawnTimer = baseSpawnTimer;
		}
}
