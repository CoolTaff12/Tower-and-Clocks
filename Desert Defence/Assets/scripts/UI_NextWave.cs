using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_NextWave : MonoBehaviour {
	EnemySpawn spawnMgr;
	Text text;
	public int timeLeft;

	// Use this for initialization
	void Awake () {
		spawnMgr = GameObject.Find ("Spawner").GetComponent<EnemySpawn> ();
		text = GetComponent <Text> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft = (int)Mathf.RoundToInt (spawnMgr.spawnTimer);
		text.text = "Next Wave:\n" + timeLeft;
	}
}
