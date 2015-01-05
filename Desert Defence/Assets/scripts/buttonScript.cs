using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class buttonScript : MonoBehaviour
{
		public GameObject[] buttonList;
		public GameObject buttonGRP;
		public CanvasGroup closer;
		public CanvasGroup openMenu;
		public GameManager_1 gameMgr;
		public Tower tower;
		public int nextLv = 0;
		public GameObject[] mortarPrefabs;
		public GameObject[] slowPrefabs;
		public GameObject[] normalPrefabs;
		public GameObject[] firePrefabs;


		// Use this for initialization
		void Start ()
		{
				buttonList = null;
		}
	
		//-------------------------------------------//
		public void UpgradeTower (Tower currentTower)
		{
				Debug.Log ("Type: " + currentTower.type + " level: " + currentTower.level);
				if (currentTower.upgradeCost <= gameMgr.gears) {
						nextLv = currentTower.level + 1;
						gameMgr.gears -= currentTower.upgradeCost;
				} else {
						nextLv = currentTower.level;		
				}
				//Debug.Log ("upgradetower adding variable. om towerlevel = högsta &/ gold != enough -> deactivate buton och kolla varje frame antar jag?");
				switch (currentTower.type) {
				case TowerType.Mortar:
						GameObject goM = Instantiate (mortarPrefabs [nextLv], currentTower.transform.position, Quaternion.identity) as GameObject;
						goM.GetComponentInChildren<Tower> ().setMGR (currentTower.gameMgr);
						goM.GetComponentInChildren<Tower> ().gameMgr = currentTower.gameMgr;
						goM.GetComponentInChildren<Tower> ().towerSpawner = currentTower.towerSpawner;
						goM.GetComponentInChildren<buttonScript> ().gameMgr = currentTower.gameMgr;
						Destroy (currentTower.transform.root.gameObject);
						break;

				case TowerType.Slow:
						GameObject goS = Instantiate (slowPrefabs [nextLv], currentTower.transform.position, Quaternion.identity) as GameObject;
						goS.GetComponentInChildren<Tower> ().setMGR (currentTower.gameMgr);
						goS.GetComponentInChildren<Tower> ().gameMgr = currentTower.gameMgr;
						goS.GetComponentInChildren<Tower> ().towerSpawner = currentTower.towerSpawner;
						goS.GetComponentInChildren<buttonScript> ().gameMgr = currentTower.gameMgr;
						Destroy (currentTower.transform.root.gameObject);
						break;

				case TowerType.Normal:
						GameObject goN = Instantiate (normalPrefabs [nextLv], currentTower.transform.position, Quaternion.identity) as GameObject;
						goN.GetComponentInChildren<Tower> ().setMGR (currentTower.gameMgr);
						goN.GetComponentInChildren<Tower> ().gameMgr = currentTower.gameMgr;
						goN.GetComponentInChildren<Tower> ().towerSpawner = currentTower.towerSpawner;
						goN.GetComponentInChildren<buttonScript> ().gameMgr = currentTower.gameMgr;
						Destroy (currentTower.transform.root.gameObject);
						break;

				case TowerType.Fire:
						GameObject goF = Instantiate (firePrefabs [nextLv], currentTower.transform.position, Quaternion.identity) as GameObject;
						goF.GetComponentInChildren<Tower> ().setMGR (currentTower.gameMgr);
						goF.GetComponentInChildren<Tower> ().gameMgr = currentTower.gameMgr;
						goF.GetComponentInChildren<Tower> ().towerSpawner = currentTower.towerSpawner;
						goF.GetComponentInChildren<buttonScript> ().gameMgr = currentTower.gameMgr;
						Destroy (currentTower.transform.root.gameObject);
						break;
				}
		}


		//-------------------------------------------//
		public void SellTower (GameObject towerPrefab)
		{
				Debug.Log ("selltower givegoldback function med towerlevel (som finns sparad i towerPrefab)");
				gameMgr.gears += towerPrefab.GetComponent <Tower> ().saleValue;
				towerPrefab.GetComponent <Tower> ().towerSpawner.occupied = false;
				Destroy (towerPrefab.transform.root.gameObject);

				//tower.Sell ();

		
		}



		//-------------------------------------------//
		public void CloseMenus ()
		{

				buttonList = GameObject.FindGameObjectsWithTag ("subButtons");
				//GetComponent<CanvasGroup>
				foreach (GameObject buttonGRP in buttonList) {
						closer = buttonGRP.GetComponent<CanvasGroup> ();
						closer.alpha = 0.0f;
						closer.interactable = false;

		
				}



		}

		//-------------------------------------------//
		public void OpenMenus (GameObject thistower)
		{
				openMenu = thistower.GetComponent<CanvasGroup> ();
				openMenu.alpha = 1.0f;
				openMenu.interactable = true;
						
			
		}
		
}
