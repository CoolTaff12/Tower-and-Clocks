using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Upgrade_On_Off : MonoBehaviour 
{
	public Tower towers;
	[SerializeField]
	private Button Evolve;
	public GameManager gameMgr;

	// Use this for initialization
	void Start ()
	{	
		//int UpTowers = towers.upgradeCost;
		Evolve = GetComponent<Button> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (towers.upgradeCost <= gameMgr.gears)
		{
			Debug.Log("It's On!");
			Evolve.enabled = Evolve.enabled;
		/*	noUpgrade = GameObject.FindGameObjectsWithTag("Upgrades");
			for(int i = 0; i < noUpgrade.Length; i ++)
			{
				noUpgrade[i].GetComponent<Button>().interactable = true;
			}*/
		}
		else
		{
			Evolve.enabled = !Evolve.enabled;
			Debug.Log("It's Off!");
			/*noUpgrade = GameObject.FindGameObjectsWithTag("Upgrades");
			for(int i = 0; i < noUpgrade.Length; i ++)
			{
				noUpgrade[i].GetComponent<Button>().interactable = false;
			}*/
		}

	}
}
