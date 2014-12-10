using UnityEngine;
using System.Collections;

public class TowerSpawner : MonoBehaviour
{

		[SerializeField]
		protected GameObject
				normalPrf = null;
		[SerializeField]
		protected GameObject
				mortarPrf = null;
		[SerializeField]
		protected GameObject
				slowPrf = null;
		[SerializeField]
		protected GameObject
				firePrf = null;
		public bool occupied = false;
		[SerializeField]
		private SpawnManager
				spawnMgr;
		public GameManager gameMgr;
		[SerializeField]
		private int
				towerCostNormal = 0;
		[SerializeField]
		private int
				towerCostSlow = 0;
		[SerializeField]
		private int
				towerCostFire = 0;
		[SerializeField]
		private int
				towerCostMortar = 0;

		// Use this for initialization
		void Start ()
		{
				gameMgr = GameObject.Find ("GameManager").GetComponent<GameManager> ();
				transform.renderer.material.color = new Color (0.2F, 0.3F, 0.4F, 0F);
		}
	
		// Update is called once per frame
		void Update ()
		{

				
		}

		void OnMouseDown ()
		{ 


				if (spawnMgr.getTowerType () != TowerType.None) {
				
						if (spawnMgr.getTowerType () == TowerType.Normal && occupied == false && gameMgr.gears >= towerCostNormal) {
								GameObject go = Instantiate (normalPrf, transform.position, Quaternion.identity) as GameObject;
								go.GetComponentInChildren<Tower> ().setMGR (gameMgr);
								go.GetComponentInChildren<Tower> ().gameMgr = gameMgr;
								go.GetComponentInChildren<buttonScript> ().gameMgr = gameMgr;
								occupied = true;
								gameMgr.gears -= towerCostNormal;
								go.GetComponentInChildren<Tower> ().setTowerSpawn (this);



						}
						if (spawnMgr.getTowerType () == TowerType.Slow && occupied == false && gameMgr.gears >= towerCostSlow) {
								GameObject go = Instantiate (slowPrf, transform.position, Quaternion.identity) as GameObject;
								go.GetComponentInChildren<Tower> ().setMGR (gameMgr);
								go.GetComponentInChildren<Tower> ().gameMgr = gameMgr;
								go.GetComponentInChildren<buttonScript> ().gameMgr = gameMgr;
								occupied = true;
								gameMgr.gears -= towerCostSlow;
								go.GetComponentInChildren<Tower> ().setTowerSpawn (this);
				
						}
						if (spawnMgr.getTowerType () == TowerType.Fire && occupied == false && gameMgr.gears >= towerCostFire) {
								GameObject go = Instantiate (firePrf, transform.position, Quaternion.identity) as GameObject;
								go.GetComponentInChildren<Tower> ().setMGR (gameMgr);
								go.GetComponentInChildren<Tower> ().gameMgr = gameMgr;
								go.GetComponentInChildren<buttonScript> ().gameMgr = gameMgr;
								occupied = true;
								gameMgr.gears -= towerCostFire;
								go.GetComponentInChildren<Tower> ().setTowerSpawn (this);
				
						}
						if (spawnMgr.getTowerType () == TowerType.Mortar && occupied == false && gameMgr.gears >= towerCostMortar) {
								GameObject go = Instantiate (mortarPrf, transform.position, Quaternion.identity) as GameObject;
								go.GetComponentInChildren<Tower> ().setMGR (gameMgr);
								go.GetComponentInChildren<Tower> ().gameMgr = gameMgr;
								go.GetComponentInChildren<buttonScript> ().gameMgr = gameMgr;
								occupied = true;
								gameMgr.gears -= towerCostMortar;
								go.GetComponentInChildren<Tower> ().setTowerSpawn (this);
				
						}

				}
		}

		void OnMouseEnter ()
		{
				if (!occupied) {
						transform.renderer.material.color = new Color (255F, 255F, 255F, 0.3F);
				}
				if (occupied == true) {
						transform.renderer.material.color = new Color (255F, 0F, 0F, 0.3F);
				}

		}

		void OnMouseExit ()
		{
				transform.renderer.material.color = new Color (0.2F, 0.3F, 0.4F, 0F);


		}

}
