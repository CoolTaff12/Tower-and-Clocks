using UnityEngine;
using System.Collections;

public class ButtonSavior : MonoBehaviour
{
	public GameManager gameMgr;
	public GameObject[] gameObjects;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				gameMgr = GameObject.Find ("GameManager").GetComponent<GameManager> ();
			if (gameMgr.health <= 0)
			{
				Time.timeScale = 1f;
				gameMgr.health = gameMgr.startHealth;
				ChangeLevel();
				EndGame();
			}
		}

		IEnumerator ChangeLevel()
		{
			Debug.Log ("Flash!");
			float fadeTime = GameObject.Find ("GameManager").GetComponent<FadingLevels> ().BeginFade (1);
			yield return new WaitForSeconds (fadeTime);
		}

		public virtual void EndGame ()
		{
				ChangeLevel();
				GameObject CrashMusic = GameObject.FindGameObjectWithTag("Music");
				GameObject DestroyParty = GameObject.Find("Music Box 2");
				Destroy(CrashMusic);
				Destroy(DestroyParty);
				Application.LoadLevel ("GameOverScreen");
		}

		public virtual void NewMainMenu ()
		{
			Application.LoadLevel ("NewMainMenu");
		}

		public virtual void LevelChoice ()
		{
				Application.LoadLevel ("LevelChoice");
		}

		public virtual void Instructions ()
		{
				Application.LoadLevel ("HowTo");
		}

		public virtual void Instructions2 ()
		{
				Application.LoadLevel ("HowTo2");
		}

		public virtual void Instructions3 ()
		{
				Application.LoadLevel ("HowTo3");
		}

		public virtual void Instructions4 ()
		{
				Application.LoadLevel ("HowTo4");
		}

		public virtual void Credits ()
		{
				Application.LoadLevel ("Credits");
		}

		public virtual void Nuke()
		{
			Debug.Log("It's Show Time");
			gameObjects = GameObject.FindGameObjectsWithTag ("Target");
			for(int i = 0 ; i < gameObjects.Length ; i ++)
			{
				Destroy(gameObjects[i]);
			}
			/*if (gameObject.tag == "Target") 
			{
				Debug.Log("Boom");
				Destroy (gameObject);
			}*/
		}

		public virtual void LevelOne ()
		{
				gameMgr.gears = gameMgr.startGears;
				gameMgr.health = gameMgr.startHealth;
				gameMgr.score = gameMgr.startScore;
				gameMgr.lastLevel = 3;
				Application.LoadLevel ("LevelOne");
		}

		public virtual void LevelTwo ()
		{
				gameMgr.gears = gameMgr.startGears;
				gameMgr.health = gameMgr.startHealth;
				gameMgr.score = gameMgr.startScore;
				gameMgr.lastLevel = 4;
				Application.LoadLevel ("LevelTwo");
		}

		public virtual void Retry ()
		{
				gameMgr.gears = gameMgr.startGears;
				gameMgr.health = gameMgr.startHealth;
				gameMgr.score = gameMgr.startScore;
				Application.LoadLevel (gameMgr.lastLevel);
		}
}
