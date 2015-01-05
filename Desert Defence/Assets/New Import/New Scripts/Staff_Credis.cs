using UnityEngine;
using System.Collections;

public class Staff_Credis : MonoBehaviour 
{
	public float durations;
	public GameObject[] Names;

	void Start () 
	{
	
	}

	void Update () 
	{
		durations += Time.deltaTime;
		if(durations > 0f)
		{
			Names[0].SetActive(true);
			Names[1].SetActive(false);
			Names[2].SetActive(false);
			Names[3].SetActive(false);
			Names[4].SetActive(false);
			Names[5].SetActive(false);
			Names[6].SetActive(false);
		}
		if(durations > 4f)
		{
			Names[0].SetActive(false);
			Names[1].SetActive(true);
			Names[2].SetActive(false);
			Names[3].SetActive(false);
			Names[4].SetActive(false);
			Names[5].SetActive(false);
			Names[6].SetActive(false);
		}
		if(durations > 8f)
		{
			Names[0].SetActive(false);
			Names[1].SetActive(false);
			Names[2].SetActive(true);
			Names[3].SetActive(false);
			Names[4].SetActive(false);
			Names[5].SetActive(false);
			Names[6].SetActive(false);
		}
		if(durations > 12f)
		{
			Names[0].SetActive(false);
			Names[1].SetActive(false);
			Names[2].SetActive(false);
			Names[3].SetActive(true);
			Names[4].SetActive(false);
			Names[5].SetActive(false);
			Names[6].SetActive(false);
		}
		if(durations > 16f)
		{
			Names[0].SetActive(false);
			Names[1].SetActive(false);
			Names[2].SetActive(false);
			Names[3].SetActive(false);
			Names[4].SetActive(true);
			Names[5].SetActive(false);
			Names[6].SetActive(false);
		}
		if(durations > 22f)
		{
			Names[0].SetActive(false);
			Names[1].SetActive(false);
			Names[2].SetActive(false);
			Names[3].SetActive(false);
			Names[4].SetActive(false);
			Names[5].SetActive(true);
			Names[6].SetActive(false);
		}
		if(durations > 28f)
		{
			Names[0].SetActive(false);
			Names[1].SetActive(false);
			Names[2].SetActive(false);
			Names[3].SetActive(false);
			Names[4].SetActive(false);
			Names[5].SetActive(false);
			Names[6].SetActive(true);
		}
		if(durations > 36f)
		{
			durations = 0f;
		}
	}
}
