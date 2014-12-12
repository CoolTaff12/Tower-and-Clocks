﻿using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{
	public Camera miniCamera1;
	public Camera miniCamera2;
	public Camera miniCamera3;
	public int located = 0;
	//------------------------------
	public float speed;	
	public Vector3 speedV;
	
		// Use this for initialization
		void Start ()
		{
		
		}
	
		// Update is called once per frame
		void Update ()
		{
		
		
				float mousePosX = Input.mousePosition.x; 
				float mousePosY = Input.mousePosition.y; 
				int scrollDistance = 2; 
				float scrollSpeed = 3f * Camera.main.orthographicSize + 2;
				Vector3 aPosition = new Vector3 (0, 0, 0);
				float ScrollAmount = scrollSpeed * Time.deltaTime;
				const float orthographicSizeMin = 5f;
				const float orthographicSizeMax = 25f;
		
		
				//mouse left
				if ((mousePosX < scrollDistance) && (transform.position.x < -25)) { 
						transform.Translate (ScrollAmount, 0, 0, Space.World); 
				} 
				//mouse right
				if ((mousePosX >= Screen.width - scrollDistance) && (transform.position.x > -56)) { 
						transform.Translate (-ScrollAmount, 0, 0, Space.World);  
				}
				//mouse down
				if ((mousePosY < scrollDistance) && (transform.position.z < 48)) { 
						transform.Translate (0, 0, ScrollAmount, Space.World); 
				} 
				//mouse up
				if ((mousePosY >= Screen.height - scrollDistance) && (transform.position.z > 10)) { 
						transform.Translate (0, 0, -ScrollAmount, Space.World);
						; 
				}
		
				//Scrolling Zoom
				if (Input.GetAxis ("Mouse ScrollWheel") < -0) { // forward
						Camera.main.orthographicSize *= 1.1f;
				}
				if (Input.GetAxis ("Mouse ScrollWheel") > -0) { // back
						Camera.main.orthographicSize *= 0.9f;
				}

				//Change the main cameras angle.
				if (Input.GetKey(KeyCode.DownArrow) && transform.rotation.x < 52.21781)
				{
					Vector3 rotation = -speedV;
					rotation = rotation * Time.deltaTime * speed;			
					transform.Rotate(rotation);
				}
				
				if (Input.GetKey(KeyCode.UpArrow))
		    	{
					Vector3 rotation = speedV;
					rotation = rotation * Time.deltaTime * speed;			
					transform.Rotate(rotation);
				}

				Camera.main.orthographicSize = Mathf.Clamp (Camera.main.orthographicSize, orthographicSizeMin, orthographicSizeMax);
		//Switching Minicameras
		if (Input.GetKeyDown(KeyCode.C))
		{
			located++;
		}
		if (located == 3)							
		{
			located = 0;	
		}
		
		if (located == 0)
		{
			miniCamera1.camera.active = false;	
			miniCamera2.camera.active = true;	
			miniCamera3.camera.active = false;	
			Debug.Log("Tara 1");
		}
		if (located == 1)
		{
			miniCamera1.camera.active = false;
			miniCamera2.camera.active = false;	
			miniCamera3.camera.active = true;
			Debug.Log("Tara 2");
		}
		if (located == 2)
		{
			miniCamera1.camera.active = true;
			miniCamera2.camera.active = false;	
			miniCamera3.camera.active = false;	
			Debug.Log("Tara 3");
		}
	}
}