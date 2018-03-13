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
	Vector3 bulletOffset;

	// Declaring bullet variables
	// --------------------------
	float bulletSpeed;
	string bulletName;
	GameObject bulletSpawnPoint; // will be used to calculate the position and rotation of the bullets
	float z;
	float timeDelay;

	// Use this for initialization
	void Start () {

		// Initializing Rotation variables
		// -------------------------------
		rotationSpeed = 180f;

		// Initializing vectors
		// --------------------
		shipsRotation = new Vector3(0, 0, 0);
		bulletOffset = new Vector3(0, 2f, 0);

		bulletSpeed = 5f;
		bulletName = "Red02";
		bulletSpawnPoint = new GameObject ();
	}

	// Update is called once per frame
	void Update () {



		movement ();

		if (timeDelay >= 1) {
			shoot ();
			timeDelay = 0;
		}

		timeDelay += Time.deltaTime;
	}

	public void movement() {

		// Calculating rotation value
		shipsRotation.z = rotationSpeed * Time.deltaTime;
		// Rotating ship
		transform.Rotate (shipsRotation);
	}

	public void shoot() {

		bulletSpawnPoint.transform.position = transform.position;
		bulletSpawnPoint.transform.rotation = transform.rotation;

		// assigning the ships current z rotation to the variable "z"
		z = bulletSpawnPoint.transform.rotation.eulerAngles.z;

		// created 12 bullets and shooting them at 30 degree increments around the ship
		for (int i = 0; i < 12; i++) {

			bulletSpawnPoint.transform.rotation = Quaternion.Euler (0, 0, z);
			bulletSpawnPoint.transform.position = transform.position + (bulletSpawnPoint.transform.rotation * bulletOffset);

			Bullet b = new Bullet (bulletSpeed, bulletName, bulletName, bulletSpawnPoint.transform);



			z += 30f;
		}
	}
}
