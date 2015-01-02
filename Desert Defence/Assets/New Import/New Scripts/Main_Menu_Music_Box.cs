using UnityEngine;
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
		if (level == 8 || level == 9 || level == 10)		// CPU Mode with Mouse
		{
			Destroy (gameObject);												// Destroys the object when the specific level is loaded
		}
		else
			DontDestroyOnLoad (transform.gameObject);	
	}
}
