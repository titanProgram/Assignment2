using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy02 : MonoBehaviour, EnemyBehaviour{

	// Declaring Ship movement variables
	// ---------------------------------
	private float shipSpeed; 
	private float rotationSpeed;
	private float z;
	private Quaternion desiredRotation;

	// Declaring Bullet variables
	// --------------------------
	private float bulletSpeed;
	private string bulletName;
	private GameObject bulletSpawnPoint;

	// Declaring Player stats
	public Health health;

	// Declaring variables for AI
	// -------------------------
	private RaycastHit2D hit;
	private GameObject playerGO;

	// Declaring vectors
	// -----------------
	private Vector3 shipsPosition;
	private Vector3 shipsRotation;
	private Vector3 direction;
	private Vector3 bulletOffset;
	private Vector2 start; // start of the linecast
	private Vector2 end; // end of the linecast

	bool rotateNow = true;

	// Use this for initialization
	void Start () {
		// Initializing ship movement variables
		// ------------------------------------
		shipSpeed = 2f;
		rotationSpeed = 180f;

		// Initializing bullet variables
		// -------------------------------
		bulletSpeed = 15f;
		bulletName = "Red02";
		bulletSpawnPoint = new GameObject ();

		// Initializing enemy stats variables
		// -----------------------------------
		health = gameObject.AddComponent<Health> ();
		health.setupHealth (100f);

		// Initializing vectors
		// --------------------
		shipsPosition = new Vector3 (0, 0, 0);
		shipsRotation = new Vector3 (0, 0, 0);
		bulletOffset = new Vector3 (0, 0.6f, 0);
		direction = new Vector3 (0, 0, 0);
		start = new Vector3 (0, 0);
		end = new Vector3 (0, 0);

		lookTowards (10);
	}
	
	// Update is called once per frame
	void Update () {
		movement ();
	}

	public void movement () {

		if (rotateNow) {
			lookTowards (rotationSpeed);
		}

		start.x = transform.position.x;
		start.y = transform.position.y;

		end.x = transform.position.x;
		end.y = transform.position.y + 20000;

		end = transform.rotation * end;

		hit = Physics2D.Linecast (start, end);

		Debug.DrawLine (start, end, Color.green);
		//Debug.Log (hit.collider.tag);
		if ( hit.collider.gameObject.tag != null && hit.collider.gameObject.tag == "Player") {
			moveForward (shipSpeed * 1.5f);
			lookTowards (rotationSpeed);
			shoot ();
		} 
		else {
			if (hit.distance > 1) {
				moveForward (shipSpeed);
			} 
			else {
				rotateNow = rotate ();
			}

			// then rotate left until no col or col dist is less than 4
		}
	}

	private bool lookTowards (float speed) {
		// assigning the player ship game object to playerGO
		playerGO = GameObject.FindWithTag ("Player");

		// if the player ship game object is found do this
		if (playerGO != null) {
			// using the normalize values from the two vectors below to calculate 
			// the rotation value to face the player
			direction = playerGO.transform.position - transform.position;
			direction.Normalize ();

			z = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg - 90;
			desiredRotation = Quaternion.Euler (0, 0, z);
			transform.rotation = Quaternion.RotateTowards (transform.rotation, desiredRotation, speed * Time.deltaTime);

			return true;
		} 
		else {
			return false;
		}
	}

	private void moveForward (float speed) {

		shipsPosition.y = speed * Time.deltaTime;
		transform.Translate (shipsPosition);
	}

	private bool rotate () {
		shipsRotation.z = rotationSpeed;
		transform.Rotate (-shipsRotation);

		if (hit.distance > 1) {
			return false;
		} 
		else {
			return true;
		}
	}


	public void shoot () {
		Debug.Log ("pew");
		bulletSpawnPoint.transform.position = (transform.position);
		bulletSpawnPoint.transform.rotation = (transform.rotation);
		bulletSpawnPoint.transform.Translate  (bulletOffset);
		Bullet b = new Bullet (bulletSpeed, bulletName, bulletName, bulletSpawnPoint.transform);
	}
}
