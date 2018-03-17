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
	private BoxCollider2D collider;
	private Vector2 colliderBoxSize;
	private DetectCollision detection;

	// Declaring list of bullets
	// -------------------------
	private static List<Bullet> bullets = new List<Bullet>(); // Contains all bullets in the game

	public static float red01 = 20f;
	public static float red02 = 20f;
	public static float blue01 = 20f;

	public Bullet ( float speed, string spriteName, string bulletName, Transform bulletsTransform ) {

		this.speed = speed;
		bulletPosition = new Vector3 (0, 0, 0);
		this.bulletName = bulletName;
		this.spriteName = spriteName;
		path = "Models/Lasers/" + spriteName;
		this.bulletsTransform = bulletsTransform;
		colliderBoxSize = new Vector2 (0.1f, 0.5f);
		loadSprite ();
	}

	public static void updateBullets() {

		for (int i = bullets.Count - 1; i >= 0; i--) {

			if (bullets [i].bullet == null) {
				Destroy (bullets [i].bullet);
				bullets.RemoveAt(i);
			}
			else if (!Bounds.inBounds (bullets [i].bullet.transform.position.x, bullets [i].bullet.transform.position.y)) {
				Destroy (bullets [i].bullet);
				bullets.RemoveAt(i);
			} 
			else {
				bullets [i].moveForward ();
			}
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
			bullet = new GameObject (bulletName);

			// Spawning bullet in its specified location
			bullet.transform.position = bulletsTransform.position;
			bullet.transform.rotation = bulletsTransform.rotation;

			// Adding a componets to the bullet game object
			bulletRenderer = bullet.AddComponent<SpriteRenderer> ();
			collider = bullet.AddComponent<BoxCollider2D> ();
			bullet.AddComponent<DetectCollision> ();
	
			// Checking if the sprite renderer was succesfully added to the game object
			if (bulletRenderer != null && collider != null) {

				bullet.tag = spriteName;

				// Assigning the sprite to be rendered to the sprite renderer
				bulletRenderer.sprite = bulletSprite;

				// setting default size for the bullets collider box
				collider.size = colliderBoxSize;

				// Adding this bullet object to the static list "bullets"
				Bullet.bullets.Add (this);
			} 
			// Displaying error message if the sprite renderer was not attached to the bullet game object
			else {
				Debug.Log ("Failed to attach component to bullet game object");
			}
		} 
		// Displaying error message if the sprite was not succesfully loaded from the resource folder
		else {
			Debug.Log ("Failed to load bullet sprite from: " + path);
		}
	}
}
