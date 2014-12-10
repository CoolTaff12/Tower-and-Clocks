using UnityEngine;
using System.Collections;

public enum TowerType
{
		None,
		Normal,
		Slow,
		Fire,
		Mortar
}

public class SpawnManager : MonoBehaviour
{
		// Use this for initialization
		public int towertype;
		public int towerNumber;
		private TowerType towerType;
		public GameObject normalShadow;
		public GameObject slowShadow;
		public GameObject fireShadow;
		public GameObject mortarShadow;

		void Start ()
		{

				towertype = 5;
				towerNumber = 5;
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (Input.GetMouseButtonDown (1) || Input.GetKeyDown (KeyCode.Escape) || Input.GetMouseButtonDown (0)) {
						towerType = TowerType.None;
				}

				if (Input.GetKeyDown (KeyCode.Alpha1)) {
						towerType = TowerType.Normal;
						Instantiate (normalShadow, Vector3.zero, Quaternion.identity);
				}
				if (Input.GetKeyDown (KeyCode.Alpha2)) {
						towerType = TowerType.Slow;
						Instantiate (slowShadow, Vector3.zero, Quaternion.identity);
				}
				if (Input.GetKeyDown (KeyCode.Alpha3)) {
						towerType = TowerType.Fire;
						Instantiate (fireShadow, Vector3.zero, Quaternion.identity);
				}
				if (Input.GetKeyDown (KeyCode.Alpha4)) {
						towerType = TowerType.Mortar;
						Instantiate (mortarShadow, Vector3.zero, Quaternion.identity);
				}
		}

		public void SelectedTower (int towerNumber)
		{
				if (towerNumber == 1) {
						towerType = TowerType.Normal;
						Instantiate (normalShadow, Vector3.zero, Quaternion.identity);
				}
				if (towerNumber == 2) {
						towerType = TowerType.Slow;
						Instantiate (slowShadow, Vector3.zero, Quaternion.identity);
				}
				if (towerNumber == 3) {
						towerType = TowerType.Fire;
						Instantiate (fireShadow, Vector3.zero, Quaternion.identity);
				}
				if (towerNumber == 4) {
						towerType = TowerType.Mortar;
						Instantiate (mortarShadow, Vector3.zero, Quaternion.identity);
				}
				if (towerNumber == 5) {
						towerType = TowerType.None;
				}
		}

		public TowerType getTowerType ()
		{
				return towerType;
		}
	
}

