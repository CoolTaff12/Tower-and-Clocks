using UnityEngine;
using System.Collections;

public class button : MonoBehaviour
{

		private Color startcolor;
		public float duration = 1.0F;
		public Material material1;
		public Material material2;


		// Use this for initialization
		void Start ()
		{
				renderer.material = material1;
		}
	
		// Update is called once per frame
		void Update ()
		{

		}

		void OnMouseEnter ()
		{
	

				//startcolor = renderer.material.color;
				//renderer.material.color = Color.yellow;
		}

		void OnMouseExit ()
		{
				//renderer.material.Lerp(material2, material1, 2.0f);

		}

}
