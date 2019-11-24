using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour
{
	private void Awake()
	{
		SizeToScreen();
	}

	private void SizeToScreen()
	{
		Camera mainCamera;
		Vector3 bottomLeft;
		Vector3 topRight;
		mainCamera = Camera.main;
		bottomLeft = mainCamera.ScreenToWorldPoint(Vector2.zero);
		topRight = mainCamera.ScreenToWorldPoint(new Vector2 (Screen.width, Screen.height));
		var height = topRight.y - bottomLeft.y;
		var width = topRight.x - bottomLeft.x;

		transform.localScale = new Vector3(width , height , 1f);		
	}
}
