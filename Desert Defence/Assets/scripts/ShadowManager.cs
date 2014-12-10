using UnityEngine;
using System.Collections;

public class ShadowManager : MonoBehaviour
{
		public float speed = 3.0f;
		private Vector3 targetPos;


		// Use this for initialization
		void Start ()
		{
				targetPos = transform.position;

		}
	
		// Update is called once per frame
		void Update ()
		{
				float distance = transform.position.z - Camera.main.transform.position.z + 15;
				targetPos = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, distance);
				targetPos = Camera.main.ScreenToWorldPoint (targetPos);
				transform.position = Vector3.MoveTowards (transform.position, targetPos, speed * Time.deltaTime);
				if (Input.GetMouseButtonDown (0) || Input.GetKeyDown (KeyCode.Alpha1) || Input.GetKeyDown (KeyCode.Alpha2) || Input.GetKeyDown (KeyCode.Alpha3) || Input.GetKeyDown (KeyCode.Alpha4)) {
						Destroy (gameObject);
				}
		}
}
