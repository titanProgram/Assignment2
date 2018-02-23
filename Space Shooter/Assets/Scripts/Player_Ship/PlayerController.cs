using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// Acceleration and deceleration variables
	// ----------------------------------------
	private float speed; // ship current speed
	public float maxSpeed; // the max speed the ship can move
	public float acceleration; // the acceleration speed of the ship
	public float deceleration; // the decceleration speed of the ship

	// Rotation variables
	// -----------------
	public float rotationSpeed;

	// Declaring vectors
	// -----------------
	Vector3 shipsPosition;
	Vector3 shipsRotation;

	// Use this for initialization
	void Start () {

		// Initializing acceleration and deceleration variables
		// -----------------------------------------------------
		speed = 0f;
		maxSpeed = 10f;
		acceleration = 2f;
		deceleration = 5f;

		// Initializing Rotation variables
		// -------------------------------
		rotationSpeed = 180f;

		// Initializing vectors
		// --------------------
		shipsPosition = new Vector3(0, 0, 0);
		shipsRotation = new Vector3(0, 0, 0);
		
	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetKey ("w")) {

			// If the ships speed is at its max and moving forward, then don't increase the ships speed by the acceleration value
			if (speed >= maxSpeed) {
				// resetting speed to default max value
				shipsPosition.y = 10f * Time.deltaTime;
				// Ship is already at maxSpeed so no need to calculate its speed
				transform.Translate (shipsPosition);
			} else {
				// Increasing the speed of the ship by the acceration variable
				speed += acceleration * Time.deltaTime;
				// re-calculating the ships position vector
				shipsPosition.y = speed * Time.deltaTime;
				// Translate the ship by the newly calculated shipPosition
				transform.Translate (shipsPosition);
			}
		} else if (Input.GetKey ("s")) {

			// If the ship is reversing at its max speed
			if (speed <= -maxSpeed) {
				// Reseting speed to default max value
				shipsPosition.y = -10f * Time.deltaTime;
				// Ship is already at maxSpeed and reversing so no need to calculate its speed
				transform.Translate (shipsPosition);
			} else {
				// Decreasing the speed of the ship by the acceleration variable
				speed -= deceleration * Time.deltaTime;
				// Re-calculating the ships position vector
				shipsPosition.y = speed * Time.deltaTime;
				// Translate the ship by the newly calculated shipPosition
				transform.Translate (shipsPosition);
			}
		} else {
			speed = 0;
		}

		if (Input.GetKey("a")) {
			
			shipsRotation.z = rotationSpeed * Time.deltaTime;
			transform.Rotate (shipsRotation);
		}
		else if (Input.GetKey("d")) {

			shipsRotation.z = rotationSpeed * Time.deltaTime;
			transform.Rotate (-shipsRotation);
		}
			

		Debug.Log (speed);
	}
}
