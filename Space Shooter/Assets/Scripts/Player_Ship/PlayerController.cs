using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// Declaring Ship movement variables
	// ---------------------------------
	private float shipSpeed; // ships current speed
	private float shipSideSpeed; // speed of the ship when moving side to side
	public float maxSpeed; // the max speed the ship can move
	public float forwardAcceleration; // the forwardAcceleration speed of the ship
	public float backwardsAcceleration; // the backwardsAcceleration speed of the ship

	// Declaring Bullet variables
	// --------------------------
	private float bulletSpeed;
	private string bulletName;
	private GameObject bulletSpawnPoint;

	// Declaring Player stats
	public Health health;

	// Declaring rotation variables
	// ----------------------------
	private float rotationSpeed;

	// Declaring vectors
	// -----------------
	private Vector3 shipsPosition;
	private Vector3 shipsRotation;
	private Vector3 bulletOffset;

	private AudioClip clip1;
	private AudioClip clip2;
	private AudioSource source;
	private AudioSource background;
	private bool soundToggle; // used to toggle between two laser sounds

	// Use this for initialization
	void Start () {

		// Initializing ship movement variables
		// ------------------------------------
		shipSpeed = 0f;
		maxSpeed = 8f;

		// set forward and backwards acceleration values higher than the max speed value if you dont want any acceleration
		forwardAcceleration = 115f;
		backwardsAcceleration = 115f;

		// Initializing bullet variables
		// -------------------------------
		bulletSpeed = 35f;
		bulletName = "Blue01";
		bulletSpawnPoint = new GameObject ();

		// Initializing player stats variables
		// -----------------------------------
		health = gameObject.AddComponent<Health> ();
		health.setupHealth (100f);

		// Initializing Rotation variables
		// -------------------------------
		rotationSpeed = 180f;

		// Initializing vectors
		// --------------------
		shipsPosition = new Vector3(0, 0, 0);
		shipsRotation = new Vector3(0, 0, 0);
		bulletOffset = new Vector3 (0, 0.6f, 0);

		// Setting the players default starting location
		transform.position = new Vector3 (500, 500, 0);

		// setting audio variables
		clip1 = Resources.Load<AudioClip> ("Sound/laserfire01");
		clip2 = Resources.Load<AudioClip> ("Sound/laserfire02");
		source = gameObject.AddComponent<AudioSource> ();
		background = gameObject.AddComponent<AudioSource> ();
		background.clip = Resources.Load<AudioClip> ("Sound/cave themeb4");
		background.loop = true;
		background.volume = 2f;
		background.Play ();
		source.clip = clip1;
		soundToggle = false;

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
			if (shipSpeed >= maxSpeed) {
				// resetting speed to default max value
				shipsPosition.y = maxSpeed * Time.deltaTime;
				shipsPosition.x = 0;
				// Ship is already at maxSpeed so no need to calculate its speed
				transform.Translate (shipsPosition);
			} else {
				// Increasing the speed of the ship by the acceration variable
				shipSpeed += forwardAcceleration * Time.deltaTime;
				// re-calculating the ships position vector
				shipsPosition.y = shipSpeed * Time.deltaTime;
				shipsPosition.x = 0;
				// Translate the ship by the newly calculated shipPosition
				transform.Translate (shipsPosition);
			}
		} 
		else if (Input.GetKey ("s")) {

			// If the ship is reversing at its max speed
			if (shipSpeed <= -maxSpeed) {
				// Reseting speed to default max value
				shipsPosition.y = -maxSpeed * Time.deltaTime;
				shipsPosition.x = 0;
				// Ship is already at maxSpeed and reversing so no need to calculate its speed
				transform.Translate (shipsPosition);
			} 
			else {
				// Decreasing the speed of the ship by the backwardsAcceleration variable
				shipSpeed -= backwardsAcceleration * Time.deltaTime;
				// Re-calculating the ships position vector
				shipsPosition.y = shipSpeed * Time.deltaTime;
				shipsPosition.x = 0;
				// Translate the ship by the newly calculated shipPosition
				transform.Translate (shipsPosition);
			}
		} 
		else {
			// resetting speed
			shipSpeed = 0;
		}

		// Moving the player side to side
		if (Input.GetKey ("e")) {

			shipsPosition.y = 0;
			shipsPosition.x = maxSpeed * Time.deltaTime;
			transform.Translate (shipsPosition);
		} 
		else if (Input.GetKey ("q")) {

			shipsPosition.y = 0;
			shipsPosition.x = -maxSpeed * Time.deltaTime;
			transform.Translate (shipsPosition);
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
			bulletSpawnPoint.transform.position = (transform.position);
			bulletSpawnPoint.transform.rotation = (transform.rotation);
			bulletSpawnPoint.transform.Translate  (bulletOffset);
			Bullet b = new Bullet (bulletSpeed, bulletName, bulletName, bulletSpawnPoint.transform);

			// setting both clip for both blocks to clip1 (sounds better than toggling)
			if (soundToggle) {
				source.clip = clip1;
				source.Play ();
				soundToggle = false;
			} 
			else {
				source.clip = clip1;
				source.Play ();
				soundToggle = true;
			}
		}
	}
}
