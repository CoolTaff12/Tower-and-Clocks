using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TypingTextFade : MonoBehaviour 
{
	public float letterPause;
	public AudioClip sound;
	
	string message;
	
	// Use this for initialization
	void Start () 
	{
		message = guiText.text;
		guiText.text = "";
		StartCoroutine(TypeText ());
	}
	
	IEnumerator TypeText ()
	{
		foreach (char letter in message.ToCharArray()) 
		{
			guiText.text += letter;
			if (sound)
			yield return 0;
			yield return new WaitForSeconds (letterPause);
		}      
	}
}
