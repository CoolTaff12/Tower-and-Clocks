using UnityEngine;
using System.Collections;

public class FadeAway : MonoBehaviour
{
		GameManager_1 gameMgr;
		public float fadeSpeed = 1.5f;          // Speed that the screen fades to and from black.
	
	
		private bool sceneStarting = true;      // Whether or not the scene is still fading in.
	
	
		void Awake ()
		{

				gameMgr = GameObject.Find ("GameManager_1").GetComponent<GameManager_1> ();
				guiTexture.pixelInset = new Rect (0f, 0f, Screen.width, Screen.height);
				sceneStarting = gameMgr.firstScene;
		}
	
		void Update ()
		{

				if (sceneStarting)

						StartScene ();
				else {
						RemoveScene ();
				}
		}
	
		void FadeToClear ()
		{

				guiTexture.color = Color.Lerp (guiTexture.color, Color.clear, fadeSpeed * Time.deltaTime);
				gameMgr.firstScene = false;
		}

	
		void StartScene ()
		{

				FadeToClear ();

				if (guiTexture.color.a <= 0.05f) {

						guiTexture.color = Color.clear;
						guiTexture.enabled = false;
			

				}
		}

		void RemoveScene ()
		{
				guiTexture.color = Color.Lerp (guiTexture.color, Color.clear, 10000000 * Time.deltaTime);
		

		}

}