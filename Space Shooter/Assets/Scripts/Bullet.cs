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

	// Declaring list of bullets
	// -------------------------
	private List<Bullet> bullets = new List<Bullet>();


	public Bullet ( float speed, string BulletName ) {

	}

	public static void updateBullets() {

	}

	void moveForward() {

	}

	private void loadSprite() {

	}


}
