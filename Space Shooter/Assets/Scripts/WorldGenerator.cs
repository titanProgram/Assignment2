using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour {

	Tile currentTile;
	Tile northTile;
	Tile southTile;
	Tile eastTile;
	Tile westTile;
	Tile northEastTile;
	Tile northWestTile;
	Tile southEastTile;
	Tile southWestTile;

	Tile[] currentTiles;

	Vector3 CurrentPosition;

	bool switchTile;

	// Use this for initialization
	void Start () {
		currentTile = new Tile (500, 500, 10);
		currentTiles = new Tile[8];
		switchTile = false;

		if (currentTile == null) {
			Debug.Log ("Failed to load current tile");
		} 
		else {
			Debug.Log (currentTile.getX());
		}

		setTiles ();

	}
	
	// Update is called once per frame
	void Update () {
		CurrentPosition = transform.position;
		updateTiles ();
	}

	void updateTiles () {
		Vector2 a = new Vector2 (CurrentPosition.x, CurrentPosition.y);

			
		Vector2 b = new Vector2 ((float) currentTile.getX(), (float) currentTile.getY());

		if (Vector2.Distance(a, b) > currentTile.getSize () / 2 || Vector2.Distance(b, a) > currentTile.getSize() / 2){

			float x;
			float y;

			for (int i = 0; i < 8; i++) {
				x = currentTiles [i].getX ();
				y = currentTiles [i].getY ();
				Vector2 v = new Vector2 (x, y);

				if (Vector2.Distance (v, a) < currentTile.getSize () / 2) {
					currentTile.destoryAllObjects ();
					currentTile = currentTiles [i];
					switchTile = true;
				}
			}

			if (switchTile) {
				for (int i = 0; i < 8; i++) {
					currentTiles [i].destoryAllObjects ();
				}
				setTiles ();
				switchTile = false;
			}
		}
	}

	void setTiles() {
		northTile = currentTile.getNorth();
		southTile = currentTile.getSouth();
		eastTile = currentTile.getEast();
		westTile = currentTile.getWest();
		northEastTile = currentTile.getNorthEast();
		northWestTile = currentTile.getNorthWest();
		southEastTile = currentTile.getSouthEast();
		southWestTile = currentTile.getSouthWest();

		currentTiles[0] = currentTile.getNorth();
		currentTiles[1] = currentTile.getSouth();
		currentTiles[2] = currentTile.getEast();
		currentTiles[3] = currentTile.getWest();
		currentTiles[4] = currentTile.getNorthEast();
		currentTiles[5] = currentTile.getNorthWest();
		currentTiles[6] = currentTile.getSouthEast();
		currentTiles[7] = currentTile.getSouthWest();
	
		northTile.renderObjects();
		southTile.renderObjects();
		eastTile.renderObjects();
		westTile.renderObjects();
		northEastTile.renderObjects();
		northWestTile.renderObjects();
		southEastTile.renderObjects();
		southWestTile.renderObjects();
		currentTile.renderObjects ();

		Debug.Log ("Current Tile: " + currentTile.getX () + ", " + currentTile.getY ());
	}




}
