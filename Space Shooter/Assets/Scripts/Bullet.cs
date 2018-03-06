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
	string bulletName;
	SpriteRenderer renderer;
	Sprite bulletSprite;

	// Declaring list of bullets
	// -------------------------
	private static List<Bullet> bullets = new List<Bullet>(); // Contains all bullets in the game


	public Bullet ( float speed, string BulletName ) {

	}

	public static void updateBullets() {

	}

	void moveForward() {

	}

	private void loadSprite() {

		// creating new game object for the bullet
		bullet = new GameObject();

		bulletSprite = Resources.Load (bulletName);

		if (bulletSprite == null) {

			Debug.Log ("Failed to load bullet sprite: " + bulletName);
		} 
		else {

			renderer = bullet.GetComponent<SpriteRenderer> ();
			renderer.sprite = bulletSprite;
		}

	}


}
