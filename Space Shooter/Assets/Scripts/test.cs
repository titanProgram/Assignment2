using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

	RaycastHit2D hit;
	Vector2 pos1;
	Vector2 pos2;
	float x;
	float y;
	LineRenderer LR;



	// Use this for initialization
	void Start () {
		pos1 = new Vector2 (0, 0);
		pos2 = new Vector2 (0, 0);

		LR = this.gameObject.AddComponent<LineRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		x = transform.position.x;
		y = transform.position.y;

		pos1.x = x;
		pos1.y = y;

		pos2.x = pos1.x;
		pos2.y = pos1.y + 2222;

		pos2 = transform.rotation * pos2;

		hit = Physics2D.Linecast (pos1, pos2);

		Debug.DrawLine (pos1, pos2, Color.green);
		//Debug.Log (hit.point);

		if (hit.point.x == 0 && hit.point.y == 0){
			
			Debug.Log ("NO HIT");
		} else {
			//Debug.Log ("hit");
			Debug.DrawLine (pos1, hit.point, Color.red);
			Debug.Log (hit.distance);
		}
	}
}
