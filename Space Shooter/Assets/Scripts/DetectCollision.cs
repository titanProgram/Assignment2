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

		// remove health if it is not a bullet
		//if (col.gameObject.tag == "Player" || col.gameObject.tag == "Enemy") {
			explode = new GameObject ();
			explode.transform.position = transform.position;
			explode.transform.Translate (explosionOffSet);
			rend = explode.AddComponent<SpriteRenderer> ();
			Sprite expolison = Resources.Load<Sprite> ("Models/Explosion/" + this.tag);
			rend.sprite = expolison;

			Destroy (gameObject);
			Destroy (explode, 0.1f);
		//} 
		//else {
			//Destroy (this, 0.5f);
			//Debug.Log(col.gameObject.tag);
		//}
	}
}
