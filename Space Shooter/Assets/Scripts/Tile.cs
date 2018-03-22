using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

	// Static data

	// Will contain a list of all created tiles in the game
	static public Tile[,] tiles = new Tile[100,100];

	// Class data
	// ---------------
	// id will contain the tiles x and y position
	private int[] id;
	// size of the camara in relation to the camera size
	private int size;

	int x;
	int y;

	int row;
	int col;

	// Each tile can contain x amount of game objects

	// 1 = UFO enemy type
	int[] enemies;
	int enemiesSize;

	// 1 = Astroid field 1
	// 2 = Astroid field 2
	// 3 = Astroid field 3
	int[] astroids;
	int astroidsSize;

	// Constructor
	public Tile (int x, int y, int size) {

		this.id = new int[2];
		this.id [0] = x;
		this.id [1] = y;
		this.x = x;
		this.y = y;
		this.size = size;

		this.row = x / size;
		this.col = y / size;

		// Adding newly created tile to tiles array
		tiles [row,col] = this;



		int enemiesSize = Random.Range (1, 4);
		int astroidsSize = Random.Range (1, 4);

		for (int i = 0; i < enemiesSize; i++) {
			enemies [i] = 1;
		}

		for (int i = 0; i < astroidsSize; i++) {
			astroids [i] = Random.Range (1, 4);
		}
	}

	// Getters
	int[] getId () {
		return id;
	}

	float getX () {
		return x;
	}

	float getY () {
		return y;
	}

	// Getters for surrounding Tiles
	public Tile getNorth() {
		if (tiles [row, col + 1] == null) {
			Tile newTile = new Tile (x, y + size, size);
			return newTile;
		} else {
			return tiles [row, col + 1];
		}
	}

	public Tile getSouth() {
		if (tiles [row, col - 1] == null) {
			Tile newTile = new Tile (x, y - size, size);
			return newTile;
		} else {
			return tiles [row, col - 1];
		}
	}

	public Tile getEast() {
		if (tiles [row + 1, col] == null) {
			Tile newTile = new Tile (x + size, y, size);
			return newTile;
		} else {
			return tiles [row + 1, col];
		}
	}

	public Tile getWest() {
		if (tiles [row - 1, col] == null) {
			Tile newTile = new Tile (x - size, y, size);
			return newTile;
		} else {
			return tiles [row - 1, col];
		}
	}

	public Tile getNorthEast() {
		if (tiles [row + 1, col + 1] == null) {
			Tile newTile = new Tile (x + size, y + size, size);
			return newTile;
		} else {
			return tiles [row + 1, col + 1];
		}
	}

	public Tile getNorthWest() {
		if (tiles [row - 1, col + 1] == null) {
			Tile newTile = new Tile (x - size, y - size, size);
			return newTile;
		} else {
			return tiles [row - 1, col - 1];
		}
	}

	public Tile getSouthEast() {
		if (tiles [row + 1, col - 1] == null) {
			Tile newTile = new Tile (x + size, y - size, size);
			return newTile;
		} else {
			return tiles [row + 1, col - 1];
		}
	}

	public Tile getSouthWest() {
		if (tiles [row - 1, col - 1] == null) {
			Tile newTile = new Tile (x - size, y - size, size);
			return newTile;
		} else {
			return tiles [row - 1, col - 1];
		}
	}

	// Methods
	void renderObjects () {
		GameObject GO;

		// Rendering Astroids
		for (int i = 0; i < astroidsSize; i++) {
			if (astroids [i] == 1) {
				GO = new GameObject ("Astroid field 01");
			} 
			else if (astroids [i] == 1) {
				GO = new GameObject ("Astroid field 02");
			} 
			else if (astroids [i] == 1) {
				GO = new GameObject ("Astroid field 03");
			} 
			else {
				Debug.LogError("Incorrect value in astroids array: astroids[" + i + "] = " + astroids[i]);
			}
		}
	}
}
