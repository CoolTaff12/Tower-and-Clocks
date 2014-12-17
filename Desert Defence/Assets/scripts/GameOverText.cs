using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverText : MonoBehaviour
{
		GameManager gameMgr;
		Text text;
		public float highscore = 1f;
	
		// Use this for initialization
		void Awake ()
		{
				gameMgr = GameObject.Find ("GameManager").GetComponent<GameManager> ();
				text = GetComponent <Text> ();
		
		}
	
		// Update is called once per frame
		void Update ()
		{
		highscore += Time.deltaTime;
		if(highscore > 7.5f)
		{
			text.text = "Y o u r  ";
		}
		if(highscore > 7.8f)
		{
			text.text = "Y o u r  f i n a l  ";
		}
		if(highscore > 8.3f)
		{
			text.text = "Y o u r  f i n a l  s c o r e : ";
		}
		if(highscore > 9f)
			{
			text.text = "Y o u r  f i n a l  s c o r e : " + "\t" + gameMgr.score;
			highscore = 0;
			}
		
		}
}