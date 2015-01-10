using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class EnemyManager : MonoBehaviour {
	public List<GameObject> enemies;
	public int sizeOfList;
	// Use this for initialization
	void Start () {
		
	}
	
	
	
	// Update is called once per frame
	void Update () {
		sizeOfList = enemies.Count;
	}
}