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
	
		// Use this for initialization
		void Start ()
		{
				gameMgr = GameObject.Find ("GameManager").GetComponent<GameManager> ();
				wave = 1f;
				spawnTimer = 10;
		
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
