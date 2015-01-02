using UnityEngine;
using System.Collections;

public class BlinkingText : MonoBehaviour 
{
	public float Timming;
	public Sprite[] sprites;
	public float framesPerSecond;
	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () 
	{
		spriteRenderer = renderer as SpriteRenderer;

	}
	
	// Update is called once per frame
	void Update () 
	{
		Timming += Time.deltaTime;
		if(Timming > 0f)
		{
			framesPerSecond = 0.2f;
			int index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
			index = index % sprites.Length;
			spriteRenderer.sprite = sprites[ index ];
		}
		if(Timming > 5f)
		{
			framesPerSecond = 1;
			int index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
			index = index % sprites.Length;
			spriteRenderer.sprite = sprites[ index ];
			if(Input.anyKey)
			{
				Application.LoadLevel("NewMainMenu");// ChangeLevel();
			}
		}
	}

/*	IEnumerator ChangeLevel()
	{
		Debug.Log ("Flash!");
		float fadeTime = GameObject.Find ("GameManager").GetComponent<FadingLevels> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		Application.LoadLevel("NewMainMenu");
	}*/
}
