using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Component {

	// Declaring bullet behaviour variables
	// ------------------------------------
	private float speed;
	private Vector3 bulletPosition;

	// Declaring bullet GameObject
	// ---------------------------
	private GameObject bullet;

	// Declaring objects for loading a bullet sprite into the game
	// -----------------------------------------------------------
	private string bulletName; // GameObject name
	private string spriteName;
	private string path;
	private SpriteRenderer bulletRenderer;
	private Sprite bulletSprite;
	private Transform bulletsTransform;

	// Declaring list of bullets
	// -------------------------
	private static List<Bullet> bullets = new List<Bullet>(); // Contains all bullets in the game


	public Bullet ( float speed, string spriteName, string bulletName, Transform bulletsTransform ) {

		this.speed = speed;
		bulletPosition = new Vector3 (0, 0, 0);
		this.bulletName = bulletName;
		this.spriteName = spriteName;
		path = "Lasers/" + spriteName;
		this.bulletsTransform = bulletsTransform;

		loadSprite ();
	}

	public static void updateBullets() {

		for (int i = bullets.Count - 1; i > 0; i--) {
			bullets[i].moveForward ();
		}
	}

	void moveForward() {
		// resetting speed to default max value
		bulletPosition.y = speed * Time.deltaTime;
		// Ship is already at maxSpeed so no need to calculate its speed
		bullet.transform.Translate (bulletPosition);
	}

	// This method will load the specified bullet sprite from the spriteName variable
	// Then render it into the game
	private void loadSprite() {

		// Loading the bullet sprite from the resources folder
		bulletSprite = Resources.Load<Sprite> (path);

		// checking if the bullet sprite was successfully loaded into the bulletSprite variable
		if (bulletSprite != null) {

			// creating new game object for the bullet
			bullet = new GameObject(bulletName);

			// Spawning bullet in its specified location
			bullet.transform.position = bulletsTransform.position;
			bullet.transform.rotation = bulletsTransform.rotation;

			// Adding a sprite renderer to the bullet game object
			bulletRenderer = bullet.AddComponent<SpriteRenderer>();

			// Checking if the sprite renderer was succesfully added to the game object
			if (bulletRenderer != null) {

				// Assigning the sprite to be rendered to the sprite renderer
				bulletRenderer.sprite = bulletSprite;

				// Adding this bullet object to the static list "bullets"
				bullets.Add (this);
			} 
			// Displaying error message if the sprite renderer was not attached to the bullet game object
			else {
				Debug.Log ("Failed to attach SpriteRenderer to bullet game object");
			}
		} 
		// Displaying error message if the sprite was not succesfully loaded from the resource folder
		else {
			Debug.Log ("Failed to load bullet sprite from: " + path);
		}
	}
}
