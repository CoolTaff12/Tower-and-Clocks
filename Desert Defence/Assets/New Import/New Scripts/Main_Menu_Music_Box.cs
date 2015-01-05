﻿using UnityEngine;
using System.Collections;

public class Main_Menu_Music_Box : MonoBehaviour 
{
	public AudioClip[] audioClip;												// Select which and how many audio clips the gameobject should have. 

	public static int music;

	public GameObject[] AudioSource;

	public void Start()
	{
		AudioSource[0].SetActive(true);
		AudioSource[1].SetActive(false);
		AudioSource[2].SetActive(false);
		AudioSource[3].SetActive(false);
		music = 0;
	//	PlaySound (music);															// Plays the audio
		DontDestroyOnLoad (transform.gameObject);								// When level is loaded, it doesn't destroy the gameobject and it's options (which is music in this case)
	}
	/*void PlaySound(int clip)													// This makes sure the audio plays and defines the audio clip array with clip 
	{
		audio.clip = audioClip [clip];
		audio.Play ();
	}*/

	void Update()
	{
		if(music == 1)
		{
			AudioSource[0].SetActive(true);
			AudioSource[1].SetActive(false);
			AudioSource[2].SetActive(false);
			AudioSource[3].SetActive(false);

		}
		if(music == 2)
		{
			AudioSource[0].SetActive(false);
			AudioSource[1].SetActive(true);
			AudioSource[2].SetActive(false);
			AudioSource[3].SetActive(false);
					
		}
		if(music == 3)
		{
			AudioSource[0].SetActive(false);
			AudioSource[1].SetActive(false);
			AudioSource[2].SetActive(true);
			AudioSource[3].SetActive(false);	
		}
		if(music == 4)
		{
			AudioSource[0].SetActive(false);
			AudioSource[1].SetActive(false);
			AudioSource[2].SetActive(false);
			AudioSource[3].SetActive(true);		
		}
		Debug.Log("Luck Number "+ music);
	}
	
	void OnLevelWasLoaded(int level)
	{	
		GameObject M1 = GameObject.Find ("Music Box");
		GameObject M2 = GameObject.Find ("Music Box 2");
		GameObject M3 = GameObject.Find ("Music Box 3");
		GameObject M4 = GameObject.Find ("Music Box 4");
		GameObject M5 = GameObject.Find ("Music Box 5");

		if(M1)
		{
			if (level == 10 || level == 11 || level == 12 || level == 3)									// CPU Mode with Mouse
			{
				Destroy (gameObject);												// Destroys the object when the specific level is loaded
			}
			else
				DontDestroyOnLoad (transform.gameObject);	
		}
		if(M2)
		{
			if (level == 10 || level == 11 || level == 12 || level == 3)									// CPU Mode with Mouse
			{
				Destroy (gameObject);												// Destroys the object when the specific level is loaded
			}
			else
				DontDestroyOnLoad (transform.gameObject);	
		}
		if(M3)
		{
			if (level == 11 || level == 12 || level == 3)									// CPU Mode with Mouse
			{
				Destroy (gameObject);												// Destroys the object when the specific level is loaded
			}
			else
				DontDestroyOnLoad (transform.gameObject);	
		}
		if(M4)
		{
			if (level == 12 || level == 3)									// CPU Mode with Mouse
			{
				Destroy (gameObject);												// Destroys the object when the specific level is loaded
			}
			else
				DontDestroyOnLoad (transform.gameObject);	
		}
		if(M4)
		{
			if (level == 3)									// CPU Mode with Mouse
			{
				Destroy (gameObject);												// Destroys the object when the specific level is loaded
			}
			else
				DontDestroyOnLoad (transform.gameObject);	
		}
	}
}