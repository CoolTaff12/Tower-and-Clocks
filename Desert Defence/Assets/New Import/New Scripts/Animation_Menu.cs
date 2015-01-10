using UnityEngine;
using System.Collections;

public class Animation_Menu : MonoBehaviour
{

	public Sprite[] sprites;
	public float framesPerSecond;
	private SpriteRenderer spriteRenderer;

	void Awake ()
	{

	}

	void Start () 
	{
		spriteRenderer = renderer as SpriteRenderer;
	}
	
	// Update is called once per frame
	void Update () 
	{
			int index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
			index = index % sprites.Length;
			spriteRenderer.sprite = sprites[ index ];
	}
}
