using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIText : MonoBehaviour
{
		GameManager gameMgr;
		Text text;

		// Use this for initialization
		void Awake ()
		{
				gameMgr = GameObject.Find ("GameManager").GetComponent<GameManager> ();
				text = GetComponent <Text> ();
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				text.text = "Health:\n" + gameMgr.health + "\nGears:\n" + gameMgr.gears + "\nScore:\n" + gameMgr.score;
	
		}
}
