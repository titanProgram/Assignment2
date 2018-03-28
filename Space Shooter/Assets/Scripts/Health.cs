using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	// Health stats variables
	// ----------------------
	private float maxHealth;
	private float currentHealth;


	GameObject explosionGO;
	Sprite explosionSprite;
	SpriteRenderer explosionRenderer;

	float x;
	float y;

	Vector3 pos = new Vector3 (0, 0, 0);
	Vector3 scale = new Vector3 (0, 0, 0);

	// Use this for initialization
	void Start () {
		

	}

	public void setupHealth(float maxHealth) {
		this.maxHealth = maxHealth;
		this.currentHealth = maxHealth;
	}
		
	private void decreaseHealth (float amount) {
		currentHealth -= amount;

		if (currentHealth <= 0) {
			kill ();
		}
	}

	private void increaseHealth (float amount) {
		currentHealth += amount;
	}

	public float getHealth () {
		return currentHealth;
	}

	private void kill () {
		
		for (int i = 0; i < 5; i++) {
			loadSprites ();
		}
		//
		Destroy (this.gameObject);
	}

	private void loadSprites () {

		explosionGO = new GameObject ("BOOM");

		pos = transform.position;
		scale = transform.localScale;

		pos.x += Random.Range (-scale.x / 2, scale.x / 2);
		pos.y += Random.Range (-scale.y / 2, scale.y / 2);

		scale.x = scale.x / 1.3f;
		scale.y = scale.y / 1.3f;

		explosionGO.transform.position = pos;
		explosionGO.transform.localScale = scale;

		explosionSprite = Resources.Load<Sprite> ("Models/Explosion/Red03");
		explosionRenderer = explosionGO.AddComponent<SpriteRenderer> ();
		explosionRenderer.sprite = explosionSprite;

		Destroy(explosionGO, Random.Range(0.1f, 0.6f));
	}

	void OnCollisionEnter2D(Collision2D col) {

		float removeHealth;

		if (col.gameObject.tag == "Red01") {
			removeHealth = Bullet.red01;
			decreaseHealth (removeHealth);
		} 
		else if (col.gameObject.tag == "Red02") {
			removeHealth = Bullet.red02;
			decreaseHealth (removeHealth);
		}
		else if (col.gameObject.tag == "Blue01") {
			removeHealth = Bullet.blue01;
			decreaseHealth (removeHealth);
		}
	}
}
