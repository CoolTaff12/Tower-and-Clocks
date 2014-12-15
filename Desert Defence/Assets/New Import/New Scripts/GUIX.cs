using UnityEngine;
using System.Collections;

public class GUIX : MonoBehaviour 
{

	public const float screenWidth = 1280.0f;
	public const float screenHeight = 800.0f;
	
	public static Matrix4x4 GetGUIMatrix() 
	{
		float xScale = Screen.width / screenWidth;
		float yScale = Screen.height / screenHeight;
		return Matrix4x4.TRS(
			Vector3.zero,
			Quaternion.identity,
			new Vector3(xScale, yScale, 1));
	}
}
