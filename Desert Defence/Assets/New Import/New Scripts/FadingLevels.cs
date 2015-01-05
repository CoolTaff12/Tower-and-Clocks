using UnityEngine;
using System.Collections;

public class FadingLevels : MonoBehaviour 
{
	public Texture2D fadeoutTexture; // Texture that will overlay the screen, can be anything really
	public float fadeSpeed = 0.8f;	//The Fades Speed.

	private int drawDepth = -1000;
	private float alpha = 1.0f;		// The texture alpha value
	private int fadeDirect = -1;		//The Direction of Fade

	void OnGui()
	{
	//The fadeout/in the alpha value using the direction of fade, the speed of fade with Time.deltatime
		alpha += fadeDirect * fadeSpeed * Time.deltaTime;
	//force(clamp) the number between 0 and 1 because GUI.color uses alpha valuse between 0 and 1
		alpha = Mathf.Clamp01 (alpha);
	//set color of our GUI (in this case our texture). All color values remains the same & the Alpha varibles
		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = drawDepth;
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fadeoutTexture);
	}

	// sets fadeDirect to the new in "direction" which parameter makes the scene fade in if -1 and out if 1
	public float BeginFade(int direction)
	{
		fadeDirect = direction;
		return(fadeSpeed); // return the fadeSpeed variable so it's easy to time the Application.loadedLevel();
	}

	//OnLevelWasLoaded is called when a level is loaded. It takes loaded level index (int) as a parameter so you can limit the fade in to certain scenes
	void OnLevelWasLoaded ()
	{
		alpha = 1; // use this if the alpha is not set to 1 by default
		BeginFade (-1); //call in the fade in function
	}

	void Start () 
	{
	
	}


	void Update () 
	{
	
	}
}
