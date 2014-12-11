﻿using UnityEngine;
using System.Collections;

public class Start_Menu_Beyond : MonoBehaviour 
{
	public Texture2D backgroundForMenu;
	public Texture2D HowToPlay;
	public Texture2D Credit;
	public Texture2D Options;
	public Texture2D startGame;
	public Texture2D Play;
	public Texture2D Tutorial;
	public Texture2D lvl1;
	public Texture2D lvl2;

	//---------------------------------------
	public Texture2D quit;
	public Texture2D MainMenu;
	public Texture2D Next;
	public Texture2D Back;
	public Texture2D Yes;
	public Texture2D No;

	//--------------------------------------

	public GUISkin trueMenu;
	public AudioClip[] audioClip;
//	private bool musicselect = true;
	public Texture2D m1;
	public Texture2D m2;
	
	//--------------------------------------

	public Texture2D HTP1;
	public Texture2D HTP2;
	public Texture2D HTP3;
	public Texture2D HTP4;
	
	//--------------------------------------

	private enum MenuStates { Main, How_To_Play, How_To_Play2, How_To_Play3, How_To_Play4, Lvl, Options, Confirm_Quit};
	private MenuStates currState;	// The currect state which will allow us to switch GUI between parts.

	//--------------------------------------

	void PlaySound(int clip)	// This makes sure the audio plays and defines the audio clip array with clip 
	{
		audio.clip = audioClip [clip];
		audio.Play ();
	}


	void Awake () 
	{
		currState = MenuStates.Main;
	}

	void Start () 
	{
		PlaySound(0);
	}

	void OnGUI() 
	{
		GUI.matrix = GUIX.GetGUIMatrix ();
		if(GUI.skin != trueMenu) 
		{
			GUI.skin = trueMenu;	
		}
		if(backgroundForMenu) 
		{
			GUI.DrawTexture(new Rect(0,0,GUIX.screenWidth, GUIX.screenHeight), backgroundForMenu);	
		}
		GUI.color = new Color32 (255, 255, 255, 200);
		switch(currState) 
		{
		case MenuStates.Main:
			DrawMainScreen();
			break;
		case MenuStates.How_To_Play:
			DrawHow_To_Play();
			break;
		case MenuStates.How_To_Play2:
			DrawHow_To_Play2();
			break;
		case MenuStates.How_To_Play3:
			DrawHow_To_Play3();
			break;
		case MenuStates.How_To_Play4:
			DrawHow_To_Play4();
			break;
		case  MenuStates.Lvl:
			DrawConfirmLvl();
			break;
		case  MenuStates.Options:
			DrawOptions();
			break;
		case  MenuStates.Confirm_Quit:
			DrawConfirmQuit();
			break;
		}
	}
	private void DrawMainScreen() 
	{
		if (GUI.Button (new Rect (Screen.width - 300, Screen.height - 400, 412, 101), ""))
		{
			currState = MenuStates.Lvl;
		}
		GUI.DrawTexture(new Rect(Screen.width - 300, Screen.height - 400, 412, 101), startGame);
		// Option Button
		if (GUI.Button (new Rect (Screen.width - 300, Screen.height - 280, 412, 101), ""))
		{
			currState = MenuStates.How_To_Play;
		}
		GUI.DrawTexture(new Rect(Screen.width - 300, Screen.height - 280, 412, 101), HowToPlay);
		// How to Play Button
		if (GUI.Button (new Rect (Screen.width - 300, Screen.height - 160, 412, 101), ""))
		{
			currState = MenuStates.Options;
		}
		GUI.DrawTexture(new Rect(Screen.width - 300, Screen.height - 160, 412, 101), Options);
		if (GUI.Button (new Rect (Screen.width - 300, Screen.height - 40, 412, 101), ""))
		{
			currState = MenuStates.Confirm_Quit;
		}
		GUI.DrawTexture(new Rect(Screen.width - 300, Screen.height - 40, 412, 101), quit);
	}

	//---------------------------------------------------------------

	private void DrawConfirmLvl()
	{
		if (GUI.Button (new Rect (Screen.width - 300, Screen.height - 300, 412, 101), ""))
		{
			Application.LoadLevel("LevelOne");
		}
		GUI.DrawTexture(new Rect(Screen.width - 300, Screen.height - 300, 412, 101), Play);
		if (GUI.Button (new Rect (Screen.width - 300, Screen.height - 180, 412, 101), ""))
		{
			Application.LoadLevel("Tutorial");
		}
		GUI.DrawTexture(new Rect(Screen.width - 300, Screen.height - 180, 412, 101), Tutorial);
		if (GUI.Button (new Rect(Screen.width - 300, Screen.height, 412, 101), ""))
		{
			currState = MenuStates.Main;
		}
		GUI.DrawTexture(new Rect(Screen.width - 300, Screen.height, 412, 101), MainMenu);
	}


	//---------------------------------------------------------------

	private void DrawHow_To_Play()
	{
		GUI.Box (new Rect (140, 20, 1000, 110),"");
		GUI.Label(new Rect(140, 20, 1000, 110),"\tBasic Rules"); 
		GUI.DrawTexture (new Rect (Screen.width - 750, 130, 1200, 560),HTP1);
	//	GUI.DrawTexture(new Rect(Screen.width + 200, Screen.height - 450, 222, 170), HTP1);
		if (GUI.Button (new Rect(Screen.width - 360, Screen.height + 100, 412, 101), ""))
		{
			currState = MenuStates.Main;
		}
		GUI.DrawTexture(new Rect(Screen.width - 360, Screen.height + 100, 412, 101), MainMenu);
		if (GUI.Button (new Rect(Screen.width + 220, Screen.height + 110, 200, 67), ""))
		{
			currState = MenuStates.How_To_Play2;
		}
		GUI.DrawTexture(new Rect(Screen.width + 220, Screen.height + 110, 200, 67), Next);
	}

	private void DrawHow_To_Play2()
	{
		GUI.Box (new Rect (140, 20, 1000, 110),"");
		GUI.Label(new Rect(140, 20, 1000, 110),"\tTowers"); 
		GUI.DrawTexture(new Rect (Screen.width - 750, 130, 1200, 560),HTP2);


		if (GUI.Button (new Rect(Screen.width - 360, Screen.height + 100, 412, 101), ""))
		{
			currState = MenuStates.Main;
		}
		GUI.DrawTexture(new Rect(Screen.width - 360, Screen.height + 100, 412, 101), MainMenu);
		if (GUI.Button (new Rect(Screen.width + 220, Screen.height + 110, 200, 67), ""))
		{
			currState = MenuStates.How_To_Play3;
		}
		GUI.DrawTexture(new Rect(Screen.width + 220, Screen.height + 110, 200, 67), Next);
		if (GUI.Button (new Rect(Screen.width - 740, Screen.height + 110, 200, 67), ""))
		{
			currState = MenuStates.How_To_Play;
		}
		GUI.DrawTexture(new Rect(Screen.width - 740, Screen.height + 110, 200, 67), Back);
	}

	private void DrawHow_To_Play3()
	{
		GUI.Box (new Rect (140, 20, 1000, 110),"");
		GUI.Label(new Rect(140, 20, 1000, 110),"\tEnemies");
		GUI.DrawTexture(new Rect (Screen.width - 750, 130, 1200, 560),HTP3);
		
		
		if (GUI.Button (new Rect(Screen.width - 360, Screen.height + 100, 412, 101), ""))
		{
			currState = MenuStates.Main;
		}
		GUI.DrawTexture(new Rect(Screen.width - 360, Screen.height + 100, 412, 101), MainMenu);
		if (GUI.Button (new Rect(Screen.width + 220, Screen.height + 110, 200, 67), ""))
		{
			currState = MenuStates.How_To_Play4;
		}
		GUI.DrawTexture(new Rect(Screen.width + 220, Screen.height + 110, 200, 67), Next);
		if (GUI.Button (new Rect(Screen.width - 740, Screen.height + 110, 200, 67), ""))
		{
			currState = MenuStates.How_To_Play2;
		}
		GUI.DrawTexture(new Rect(Screen.width - 740, Screen.height + 110, 200, 67), Back);
	}

	private void DrawHow_To_Play4()
	{
		GUI.Box (new Rect (140, 20, 1000, 110),"");
		GUI.Label(new Rect(140, 20, 1000, 110),"\tInterface");
		GUI.DrawTexture(new Rect (Screen.width - 750, 130, 1200, 560),HTP4);
		
		
		if (GUI.Button (new Rect(Screen.width - 360, Screen.height + 100, 412, 101), ""))
		{
			currState = MenuStates.Main;
		}
		GUI.DrawTexture(new Rect(Screen.width - 360, Screen.height + 100, 412, 101), MainMenu);
		if (GUI.Button (new Rect(Screen.width - 740, Screen.height + 110, 200, 67), ""))
		{
			currState = MenuStates.How_To_Play2;
		}
		GUI.DrawTexture(new Rect(Screen.width - 740, Screen.height + 110, 200, 67), Back);
	}

	//---------------------------------------------------------------

	private void DrawOptions()
	{	
		GUILayout.BeginArea(new Rect(0, 120, 1280, 800));
		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		GUILayout.Label("Select Music");
		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();
		GUILayout.EndArea();

		if (GUI.Button (new Rect (Screen.width - 660, Screen.height - 320, 412, 101), ""))
		{
			PlaySound(0);
		}
		GUI.DrawTexture(new Rect(Screen.width - 660, Screen.height - 320, 412, 101), m1);
		if (GUI.Button (new Rect (Screen.width - 100, Screen.height - 320, 412, 101), ""))
		{
			PlaySound(1);
		}
		GUI.DrawTexture(new Rect(Screen.width - 100, Screen.height - 320, 412, 101), m2);

		GUILayout.BeginArea(new Rect(0, 500, 1280, 800));
		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		GUILayout.Label("Difficulty");
		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();
		GUILayout.EndArea();

		if (GUI.Button (new Rect(Screen.width - 760, Screen.height + 100, 412, 101), ""))
		{
			currState = MenuStates.Main;
		}
		GUI.DrawTexture(new Rect(Screen.width - 760, Screen.height + 100, 412, 101), MainMenu);
		
	}

	//------------------------------------------------------------
	private void DrawConfirmQuit()
	{
		GUILayout.BeginArea(new Rect(0, 140, 1280, 800));
		GUILayout.BeginHorizontal();
		GUILayout.FlexibleSpace();
		GUILayout.Label("Do you want to leave us\nand let us bite the dust??");
		GUILayout.FlexibleSpace();
		GUILayout.EndHorizontal();
		GUILayout.EndArea();


		if (GUI.Button (new Rect(Screen.width - 460, Screen.height, 300, 114), ""))
		{
			Application.Quit();
		}
		GUI.DrawTexture(new Rect(Screen.width - 460, Screen.height, 300, 114), Yes);

		if (GUI.Button (new Rect(Screen.width - 120, Screen.height, 300, 114), ""))
		{
			currState = MenuStates.Main;
		}
		GUI.DrawTexture(new Rect(Screen.width - 120, Screen.height, 300, 114), No);
	}



	// Update is called once per frame
	void Update () 
	{
	
	}
}
