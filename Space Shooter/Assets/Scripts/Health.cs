using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	private float maxHealth;
	private float currentHealth;

	public void setupHealth(float maxHealth) {
		this.maxHealth = maxHealth;
		this.currentHealth = maxHealth;
	}
		
	private void decreaseHealth (float amount) {
		currentHealth -= amount;

		if (currentHealth <= 0) {
			explode ();
		}
	}

	private void increaseHealth (float amount) {
		currentHealth += amount;
	}

	public float getHealth () {
		return currentHealth;
	}

	private void explode () {
		
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

		Debug.Log (getHealth ());
	}
}
