using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds {

	static float ratio = (float) Screen.width / (float) Screen.height;
	static float screenWidth = ratio * Camera.main.orthographicSize;
	static float screenHeight = Camera.main.orthographicSize;

	public static bool inBounds(float x, float y) {

		float left = Camera.main.transform.position.x - (screenWidth );
		float right = Camera.main.transform.position.x + (screenWidth );
		float top = Camera.main.transform.position.y + (screenHeight );
		float bottom = Camera.main.transform.position.y - (screenHeight );

		if (x < right && x > left && y > bottom && y < top) {
			return true;
		}
		else {
			return false;
		}
	}
}
