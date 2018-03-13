using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour {


	GameObject explode;
	SpriteRenderer rend;
	GameObject n = null;

	// Use this for initialization
	void Start () {
		

	}
	void OnCollisionEnter2D(Collision2D col) {



		// remove health if it is not a bullet
		if (col.gameObject.tag == "Player" || col.gameObject.tag == "Enemy") {
			explode = new GameObject ();
			explode.transform.position = transform.position;
			rend = explode.AddComponent<SpriteRenderer> ();
			Sprite expolison = Resources.Load<Sprite> ("Models/Explosion/" + this.tag);
			rend.sprite = expolison;
			//explode.transform.localScale = new Vector3 (5, 5, 0);
			// remove health
			//Destroy (col.gameObject);
			Debug.Log("in");

			Destroy (gameObject);
			Destroy (explode, 0.2f);
		} 
		else {
			Destroy (this, 0.5f);
			Debug.Log(col.gameObject.tag);
		}
	}
}
