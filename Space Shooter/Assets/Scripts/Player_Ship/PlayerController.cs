using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// forwardAcceleration and backwardsAcceleration variables
	// ----------------------------------------
	private float ShipSpeed; // ships current speed
	public float maxSpeed; // the max speed the ship can move
	public float forwardAcceleration; // the forwardAcceleration speed of the ship
	public float backwardsAcceleration; // the backwardsAcceleration speed of the ship

	// Bullet variables
	// -----------------
	float BulletSpeed;
	string spriteName;
	string bulletName;

	// Declaring rotation variables
	// -----------------
	public float rotationSpeed;

	// Declaring vectors
	// -----------------
	Vector3 shipsPosition;
	Vector3 shipsRotation;

	// Use this for initialization
	void Start () {

		// Initializing forwardAcceleration and backwardsAcceleration variables
		// -----------------------------------------------------
		ShipSpeed = 0f;
		maxSpeed = 10f;
		forwardAcceleration = 2f;
		backwardsAcceleration = 5f;

		// Initializing bullet variables
		// -------------------------------
		BulletSpeed = 15f;
		spriteName = "blue01";
		bulletName = "Player Bullet";

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
		playerMovement ();
		shoot ();
		Bullet.updateBullets ();
	}

	void playerMovement() {

		// Moving the player forwards and backwards
		if (Input.GetKey ("w")) {
			
			// If the ships speed is at its max and moving forward, then don't increase the ships speed by the forwardAcceleration value
			if (ShipSpeed >= maxSpeed) {
				// resetting speed to default max value
				shipsPosition.y = maxSpeed * Time.deltaTime;
				// Ship is already at maxSpeed so no need to calculate its speed
				transform.Translate (shipsPosition);
			} else {
				// Increasing the speed of the ship by the acceration variable
				ShipSpeed += forwardAcceleration * Time.deltaTime;
				// re-calculating the ships position vector
				shipsPosition.y = ShipSpeed * Time.deltaTime;
				// Translate the ship by the newly calculated shipPosition
				transform.Translate (shipsPosition);
			}
		} 
		else if (Input.GetKey ("s")) {

			// If the ship is reversing at its max speed
			if (ShipSpeed <= -maxSpeed) {
				// Reseting speed to default max value
				shipsPosition.y = -maxSpeed * Time.deltaTime;
				// Ship is already at maxSpeed and reversing so no need to calculate its speed
				transform.Translate (shipsPosition);
			} 
			else {
				// Decreasing the speed of the ship by the forwardAcceleration variable
				ShipSpeed -= backwardsAcceleration * Time.deltaTime;
				// Re-calculating the ships position vector
				shipsPosition.y = ShipSpeed * Time.deltaTime;
				// Translate the ship by the newly calculated shipPosition
				transform.Translate (shipsPosition);
			}
		} 
		else {
			// resetting speed
			ShipSpeed = 0;
		}

		// Rotating the player ship
		if (Input.GetKey("a")) {

			shipsRotation.z = rotationSpeed * Time.deltaTime;
			transform.Rotate (shipsRotation);
		}
		else if (Input.GetKey("d")) {

			shipsRotation.z = rotationSpeed * Time.deltaTime;
			transform.Rotate (-shipsRotation);
		}
	}

	void shoot() {
		if (Input.GetMouseButtonDown (0)) {
			Bullet b = new Bullet (BulletSpeed, spriteName, bulletName, transform);
		}
	}
}
