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

	Vector3 CurrentPosition;

	// Use this for initialization
	void Start () {
		currentTile = new Tile (0, 0, 10);

		northTile = currentTile.getNorth();
		southTile = currentTile.getSouth();
		eastTile = currentTile.getEast();
		westTile = currentTile.getWest();
		northEastTile = currentTile.getNorthEast();
		northWestTile = currentTile.getNorthWest();
		southEastTile = currentTile.getSouthEast();
		southWestTile = currentTile.getSouthWest();

	}
	
	// Update is called once per frame
	void Update () {
		CurrentPosition = transform.position;
	}

	void updateTiles () {
		// check if distance of current pos from current tile is greated than the tile size

	}


}
