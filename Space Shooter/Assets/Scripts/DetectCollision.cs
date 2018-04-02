using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour {


	GameObject explode;
	SpriteRenderer rend;

	private Vector3 explosionOffSet;

	// Use this for initialization
	void Start () {

		explosionOffSet = new Vector3 (0, 0, -5);

	}

	void OnCollisionEnter2D(Collision2D col) {

		explode = new GameObject ();
		explode.transform.position = transform.position;
		explode.transform.Translate (explosionOffSet);
		rend = explode.AddComponent<SpriteRenderer> ();
		Sprite expolison = Resources.Load<Sprite> ("Models/Explosion/" + this.tag);
		rend.sprite = expolison;

		Destroy (gameObject);
		Destroy (explode, 0.1f);
	}
}
