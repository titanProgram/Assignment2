using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds {

	// calculating ratio of the screen
	static float ratio = (float) Screen.width / (float) Screen.height;

	// calculating width and height of screen
	public static float screenWidth = ratio * Camera.main.orthographicSize;
	public static float screenHeight = Camera.main.orthographicSize;

	public static bool inBounds(float x, float y) {

		// calculating boundries of the screen
		float left = Camera.main.transform.position.x - (screenWidth );
		float right = Camera.main.transform.position.x + (screenWidth );
		float top = Camera.main.transform.position.y + (screenHeight );
		float bottom = Camera.main.transform.position.y - (screenHeight );

		if (x < right * 2 && x > left  * 2 && y > bottom  * 2 && y < top * 2) {
			return true;
		}
		else {
			return false;
		}
	}
}
