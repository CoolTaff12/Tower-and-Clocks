using UnityEngine;
using System.Collections;

public class ButtonSavior : MonoBehaviour
{
		public GameManager gameMgr;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				gameMgr = GameObject.Find ("GameManager").GetComponent<GameManager> ();
				if (gameMgr.health <= 0) {
						gameMgr.health = gameMgr.startHealth;
						EndGame ();
	
				}
		}

		public virtual void EndGame ()
		{
				Application.LoadLevel ("GameOverScreen");
		}

		public virtual void MainMenu ()
		{
				Application.LoadLevel ("MainMenu");
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
