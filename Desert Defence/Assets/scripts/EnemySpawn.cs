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

		public GameObject directionalLight;
		public Texture2D gameMenu;
		public Texture2D resume;
		public Texture2D help;
		public Texture2D menu;
		public Texture2D options;
		private bool pauseMode = false;

	
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
			if (GUI.Button (new Rect (300, 0, 200, 101), "Pause") && pauseMode == false) 
			{
				GUI.DrawTexture (new Rect (Screen.width / 3.5f, Screen.height / 10f, 356,512), gameMenu);
				GUI.DrawTexture (new Rect (Screen.width / 2.5f, Screen.height / 4f, 156, 64), resume);
				GUI.DrawTexture (new Rect (Screen.width / 2.45f, Screen.height / 2.6f, 156, 64), help);
				GUI.DrawTexture (new Rect (Screen.width / 2.5f, Screen.height / 1.8f, 156, 64), options);
				GUI.DrawTexture (new Rect (Screen.width / 2.5f, Screen.height / 1.4f, 156, 64), menu);
				pauseMode = true;
				//Time.timeScale = 0f;
			}
			if (wave > 16 && Application.loadedLevelName ==("Tutorial"))
			{
				Time.timeScale = 0f;
				if (GUI.Button (new Rect (300, 400, 200, 101), "Yes!"))
				{
					gameMgr.health += 5;
					gameMgr.gears += 30;
					Application.LoadLevel("LevelOne");
				}
			}
		}
	
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
				if(wave > 10 && Application.loadedLevelName ==("Tutorial"))
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

				}
		
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
