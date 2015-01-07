using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverText : MonoBehaviour
{
		GameManager gameMgr;
		public GameObject Button1;
		public GameObject Button2;
		Text text;
		public float highscore = 1f;
		public AudioClip[] audioClip;


		void PlaySound(int clip)													// This makes sure the audio plays and defines the audio clip array with clip 
		{
			audio.clip = audioClip [clip];
			audio.Play ();
		}
	

		void Awake ()
		{
				Time.timeScale = 1f;
				gameMgr = GameObject.Find ("GameManager").GetComponent<GameManager> ();
				text = GetComponent <Text> ();
		
		}
	
		// Update is called once per frame
		void Update ()
		{

		highscore += Time.deltaTime;
		if(highscore > 7.7f)
		{
			text.text = "Y o u r  ";
		//	PlaySound (0);	
		}
		if(highscore > 8f)
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
			Button1.SetActive(true);
			Button2.SetActive(true);
		}
		else
		{
			Button1.SetActive(false);
			Button2.SetActive(false);
		}
		
		}
}