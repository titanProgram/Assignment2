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


		GameObject soundGO = new GameObject ();
		explode = new GameObject ();
		explode.transform.position = transform.position;
		explode.transform.Translate (explosionOffSet);
		rend = explode.AddComponent<SpriteRenderer> ();
		Sprite expolison = Resources.Load<Sprite> ("Models/Explosion/" + this.tag);
		rend.sprite = expolison;

		AudioSource source = soundGO.AddComponent<AudioSource> ();
		source.clip = Resources.Load<AudioClip> ("Sound/boom6");
		source.Play ();

		Destroy (gameObject);
		Destroy (explode, 0.1f);
		Destroy (soundGO, 1.5f);
	}
}
