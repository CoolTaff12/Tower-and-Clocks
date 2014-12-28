using UnityEngine;
using System.Collections;

public class SaveManager : MonoBehaviour
{

	private static SaveManager _instance;

	public static SaveManager instance 
	{
		get 
		{
			if (_instance == null) 
			{
				_instance = GameObject.FindObjectOfType<SaveManager> ();
				DontDestroyOnLoad (_instance.gameObject);
			}
			return _instance;
		}
	}

	// Use this for initialization
	void Awake ()
	{
		if (_instance == null) 
		{
			_instance = this;
			DontDestroyOnLoad (this);
		} 
		else 
		{
			if (this != _instance) // || Application.loadedLevelName == ("Tutorial")) 
			{
				Destroy (this.gameObject);
			}
		}
	}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
