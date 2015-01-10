using UnityEngine;
using System.Collections;

public class Explosion_Removal : MonoBehaviour 
{
	public float gone;
	public GameObject Explotion;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		gone += Time.deltaTime;
		if(gone > 3f)
		{
			Destroy(Explotion);
		}

	}
}
