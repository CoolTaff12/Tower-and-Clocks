using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class buttontest : MonoBehaviour
{
		public Slider Slider;
		/*
	public void DoSomething()
	{
		Debug.Log (Slider.value.ToString ());
	}
	//Inte lika fancy då man inte kan dra in slidern själv
	*/
		public void DoSomethingWithASlider (Slider slider)
		{
				Debug.Log (slider.value.ToString ());
		}
}
