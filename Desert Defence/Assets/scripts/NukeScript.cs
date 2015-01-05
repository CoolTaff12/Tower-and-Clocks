using UnityEngine;
using System.Collections;

public class NukeScript : MonoBehaviour {
	
	public GameObject theNukeButtonObject;
	
	private void OnMouseDown()
	{
		
		if (gameObject.tag == "Target") 
		{
			Destroy (gameObject);
		}
		
	}
	
}
