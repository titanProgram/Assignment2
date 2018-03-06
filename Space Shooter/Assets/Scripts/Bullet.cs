using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Component {

	// Declaring bullet behaviour variables
	// ------------------------------------
	float speed;

	// Declaring bullet GameObject
	// ---------------------------
	GameObject bullet;

	// Declaring object for loading a bullet sprite into the game
	// ----------------------------------------------------------
	string bulletName; // GameObject name
	string spriteName;
	string path;
	SpriteRenderer bulletRenderer;
	Sprite bulletSprite;

	// Declaring list of bullets
	// -------------------------
	private static List<Bullet> bullets = new List<Bullet>(); // Contains all bullets in the game


	public Bullet ( float speed, string spriteName, string bulletName ) {

		this.speed = speed;
		this.bulletName = bulletName;
		this.spriteName = spriteName;
		path = "Lasers/" + spriteName;

		loadSprite ();
	}

	public static void updateBullets() {

	}

	void moveForward() {

	}

	private void loadSprite() {



		bulletSprite = Resources.Load<Sprite> (path);

		if (bulletSprite == null) {

			Debug.Log ("Failed to load bullet sprite from: " + path);
		} 
		else {
			// creating new game object for the bullet
			bullet = new GameObject(bulletName);

			bulletRenderer = bullet.GetComponent<SpriteRenderer>();
			bulletRenderer.sprite = bulletSprite;
		}

	}


}
