using UnityEngine;
using System.Collections;

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
		public Texture2D resume;
		public Texture2D help;
		public Texture2D menu;
		public Texture2D options;
		public Texture2D pause;

		//-----------------------------------------------
		private enum MenuStates { Runs, PausedMenu, Help1, Help2, Help3, Help4, Tutorial1, Tutorial2};
		private MenuStates currState;
		public GUISkin trueMenu;
		public Texture2D HTP1;
		public Texture2D HTP2;
		public Texture2D HTP3;
		public Texture2D HTP4;
		public Texture2D Next;
		public Texture2D Back;

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
			}
			if (wave > 16 && Application.loadedLevelName ==("Tutorial"))
			{
				Time.timeScale = 0f;
				if (GUI.Button (new Rect (300, 400, 200, 101), "Yes!"))
				{
					gameMgr.health += 5;
					gameMgr.gears += 30;
					Application.LoadLevel(Application.loadedLevel + 1);
				}
			}
			if (wave > 26 && Application.loadedLevelName ==("LevelSix"))
			{
				Time.timeScale = 0f;
				if (GUI.Button (new Rect (300, 400, 200, 101), "Yes!"))
				{
					gameMgr.health += 5;
					gameMgr.gears += 30;
					Application.LoadLevel(Application.loadedLevel + 1);
				}
		}
		}

	//----------------------------------------------------------------------------
		private void DrawRuns()
		{
			Time.timeScale = 1f;
			if (Application.loadedLevelName == ("LevelSix")) 
			{
			Time.timeScale = 1.5f;
			Debug.Log("Wow, it goes " + Time.timeScale + " as fast!");
			}
			if (GUI.Button (new Rect (300, 0, 200, 80), "")) 
			{
				currState = MenuStates.PausedMenu;
			}
			GUI.DrawTexture (new Rect (300, 0, 200, 80), pause);
		}
		private void DrawPausedMenu()
		{
			GUI.DrawTexture (new Rect (Screen.width / 3.5f, Screen.height / 10f, 356,512), gameMenu);
			if (GUI.Button (new Rect (Screen.width / 2.5f, Screen.height / 4f, 156, 64),"")) 
			{
				currState = MenuStates.Runs;
			}
			GUI.DrawTexture (new Rect (Screen.width / 2.5f, Screen.height / 4f, 156, 64), resume);
			if (GUI.Button (new Rect (Screen.width / 2.45f, Screen.height / 2.6f, 156, 64),"")) 
			{
				currState = MenuStates.Help1;
			}
			GUI.DrawTexture (new Rect (Screen.width / 2.45f, Screen.height / 2.6f, 156, 64), help);
			GUI.DrawTexture (new Rect (Screen.width / 2.5f, Screen.height / 1.8f, 156, 64), options);
			if (GUI.Button (new Rect (Screen.width / 2.5f, Screen.height / 1.4f, 156, 64),"")) 
			{
				gameMgr.health = 10;
				gameMgr.gears = 45;
				Application.LoadLevel("NewMainMenu");
			}
			GUI.DrawTexture (new Rect (Screen.width / 2.5f, Screen.height / 1.4f, 156, 64), menu);
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
	//----------------------------------------------------------------------------
	
		// Update is called once per frame
		void Update ()
		{
				spawnTimer -= Time.deltaTime;
				//Debug.Log ("Wave Number: " + wave);
				if (Input.GetKeyDown (KeyCode.Space) || spawnTimer <= 0) {
						SpawnAll ();
				}
				if (targetCountNormal >= maxNormals) {
						CancelInvoke ("SpawnNormal");
						wave++;
						wavePoints++;
						maxNormals += NormalsPerWave;
						targetCountNormal = 0;
				}
				if (targetCountSpeedy >= maxSpeedies) {
						CancelInvoke ("SpawnSpeedy");
						wave++;
						wavePoints++;
						maxSpeedies += SpeediesPerWave;
						targetCountSpeedy = 0;
				}
				if (targetCountTank >= maxTanks) {
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
