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
		float left = Camera.main.transform.position.x - (screenWidth  * 2 );
		float right = Camera.main.transform.position.x + (screenWidth  * 2);
		float top = Camera.main.transform.position.y + (screenHeight  * 2);
		float bottom = Camera.main.transform.position.y - (screenHeight  * 2);

		if (x < right && x > left && y > bottom && y < top) {
			return true;
		}
		else {
			return false;
		}
	}
}
