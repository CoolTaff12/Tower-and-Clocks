using UnityEngine;
using System.Collections;

public class TowerManager : MonoBehaviour {

[SerializeField]
	private Tower[] towers;

	public void FireAll(){
		foreach (Tower t in towers) {
			if (t != null){
				t.Fire();
			}
		}
	}
}
