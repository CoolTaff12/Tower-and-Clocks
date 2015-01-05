using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverText : MonoBehaviour
{
		GameManager_1 gameMgr;
		Text text;
	
		// Use this for initialization
		void Awake ()
		{
				gameMgr = GameObject.Find ("GameManager_1").GetComponent<GameManager_1> ();
				text = GetComponent <Text> ();
		
		}
	
		// Update is called once per frame
		void Update ()
		{
				text.text = "Score: " + gameMgr.score;
		
		}
}