using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy01 : MonoBehaviour, EnemyBehaviour {

	// Declaring rotation variables
	// ----------------------------
	public float rotationSpeed;

	// Declaring vectors
	// -----------------
	Vector3 shipsRotation;

	// Declaring bullet variables
	// --------------------------
	Quaternion bulletSpawnPoint;
	Transform shipsTransform;
	float z;


	// Use this for initialization
	void Start () {

		// Initializing Rotation variables
		// -------------------------------
		rotationSpeed = 180f;

		// Initializing vectors
		// --------------------
		shipsRotation = new Vector3(0, 0, 0);

	}

	// Update is called once per frame
	void Update () {
		movement ();
	}

	public void movement() {

		shipsRotation.z = rotationSpeed;
		transform.Rotate (shipsRotation);
	}

	public void shoot() {

		shipsTransform.rotation = Quaternion.Euler(0, 0, 30);
		transform.
		for (int i = 0; i < 12; i++) {
			shipsTransform.rotation = bulletSpawnPoint;
			Bullet b = new Bullet (5f, "red01", "Enemy01 Bullet", shipsTransform);

			bulletSpawnPoint.eulerAngles.z += 30f;
		}
	}
}
