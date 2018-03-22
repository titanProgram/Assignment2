using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

	private Vector3 cameraPosition;

	// Use this for initialization
	void Start () {

		cameraPosition = new Vector3 (0, 0, -10);
	}
	
	// Update is called once per frame
	void Update () {
		
		Camera.main.transform.position = transform.position + cameraPosition;
		//Camera.main.transform.rotation = transform.rotation;
	}
}
