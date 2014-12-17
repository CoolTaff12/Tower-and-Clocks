using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TypingTextFade : MonoBehaviour 
{
	Text text;

	public float highscore = 1f;
	void Awake ()
	{
		text = GetComponent <Text> ();	
	}

	// Update is called once per frame
	void Update () 
	{
		highscore += Time.deltaTime;
		if(highscore > 1.7)
		{
			text.text = "Y ";
		}
		if(highscore > 2f)
		{
			text.text = "Y o ";
		}
		if(highscore > 2.3f)
		{
			text.text = "Y o u ";
		}
		if(highscore > 2.5f)
		{
			text.text = "Y o u  ";
		}
		if(highscore > 2.8f)
		{
			text.text = "Y o u   F ";
		}
		if(highscore > 3.1f)
		{
			text.text = "Y o u   F a ";
		}
		if(highscore > 3.4f)
		{
			text.text = "Y o u   F a i ";
		}		
		if(highscore > 3.7f)
		{
			text.text = "Y o u   F a i l ";
		}
		if(highscore > 3.9f)
		{
			text.text = "Y o u   F a i l e ";
		}
		if(highscore > 4.1f)
		{
			text.text = "Y o u   F a i l e d ";
		}


	}
}
