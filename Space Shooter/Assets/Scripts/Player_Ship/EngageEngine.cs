using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngageEngine : MonoBehaviour {

	// Declaring movement variables
	// ----------------------------
	private float maxDistance; // the max distance the flame can move
	public float timeDelay; // how long it takes to move the flame

	// Declaring Vectors
	// -----------------
	Vector3 firePosition;

	// Use this for initialization
	void Start () {

		// Initializing movement variables
		// -------------------------------
		maxDistance = 0.3f;
		timeDelay = 2; // 2 seconds

		// Initializing vectors
		// --------------------
		firePosition = new Vector3 (0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey ("w")) {

			if (firePosition.y > -maxDistance) {
				firePosition.y = (maxDistance * Time.deltaTime) * -timeDelay;
				transform.Translate (firePosition);
			}
			Debug.Log (firePosition.y);
		}
	}
}
