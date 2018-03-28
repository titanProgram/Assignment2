using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile {

	// Static data

	// Will contain a list of all created tiles in the game
	public static int tilesSize = 100;
	static public Tile[,] tiles = new Tile[tilesSize,tilesSize];


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

		enemies = new int[enemiesSize];
		astroids = new int[astroidsSize];
		for (int i = 0; i < enemiesSize; i++) {
			enemies [i] = 1;
		}

		for (int i = 0; i < astroidsSize; i++) {
			astroids [i] = Random.Range (1, 4);
		}
			
	}

	// Getters
	public int[] getId () {
		return id;
	}

	public float getX () {
		return x;
	}

	public float getY () {
		return y;
	}

	public float getSize () {
		return size;
	}

	// Getters for surrounding Tiles
	public Tile getNorth() {
		if (col < tilesSize) {
			if (tiles [row, col + 1] == null) {
				tiles [row, col + 1] = new Tile (x, y + size, size);
				return tiles [row, col + 1];
			} else {
				return tiles [row, col + 1];
			}
		} 
		else {
			Debug.LogError ("trying to access tiles[" + col + "][" + row + "] - index out of bounds array size = [" + tilesSize + "][" + tilesSize + "]");
			return null;
		}
	}

	public Tile getSouth() {
		if (col > 0) {
			if (tiles [row, col - 1] == null) {
				tiles [row, col - 1] = new Tile (x, y - size, size);
				return tiles [row, col - 1];
			} else {
				return tiles [row, col - 1];
			}
		}
		else {
			Debug.LogError ("trying to access tiles[" + col + "][" + row + "] - index out of bounds array size = [" + tilesSize + "][" + tilesSize + "]");
			return null;
		}
	}

	public Tile getEast() {
		if (row < tilesSize) {
			if (tiles [row + 1, col] == null) {
				tiles [row + 1, col] = new Tile (x + size, y, size);
				return tiles [row + 1, col];
			} else {
				return tiles [row + 1, col];
			}
		}
		else {
			Debug.LogError ("trying to access tiles[" + col + "][" + row + "] - index out of bounds array size = [" + tilesSize + "][" + tilesSize + "]");
			return null;
		}
	}

	public Tile getWest() {
		if (row > 0) {
			if (tiles [row - 1, col] == null) {
				tiles [row - 1, col] = new Tile (x - size, y, size);
				return tiles [row - 1, col];
			} else {
				return tiles [row - 1, col];
			}
		}
		else {
			Debug.LogError ("trying to access tiles[" + col + "][" + row + "] - index out of bounds array size = [" + tilesSize + "][" + tilesSize + "]");
			return null;
		}
	}

	public Tile getNorthEast() {
		if (row < tilesSize && col < tilesSize) {
			if (tiles [row + 1, col + 1] == null) {
				tiles [row + 1, col + 1] = new Tile (x + size, y + size, size);
				return tiles [row + 1, col + 1];
			} else {
				return tiles [row + 1, col + 1];
			}
		}
		else {
			Debug.LogError ("trying to access tiles[" + col + "][" + row + "] - index out of bounds array size = [" + tilesSize + "][" + tilesSize + "]");
			return null;
		}
	}

	public Tile getNorthWest() {
		if (row > 0 && col < tilesSize) {
			if (tiles [row - 1, col + 1] == null) {
				tiles [row - 1, col + 1] = new Tile (x - size, y - size, size);
				return tiles [row - 1, col + 1];
			} else {
				return tiles [row - 1, col - 1];
			}
		}
		else {
			Debug.LogError ("trying to access tiles[" + col + "][" + row + "] - index out of bounds array size = [" + tilesSize + "][" + tilesSize + "]");
			return null;
		}
	}

	public Tile getSouthEast() {
		if (row < tilesSize && col > 0) {
			if (tiles [row + 1, col - 1] == null) {
				tiles [row + 1, col - 1] = new Tile (x + size, y - size, size);
				return tiles [row + 1, col - 1];
			} else {
				return tiles [row + 1, col - 1];
			}
		}
		else {
			Debug.LogError ("trying to access tiles[" + col + "][" + row + "] - index out of bounds array size = [" + tilesSize + "][" + tilesSize + "]");
			return null;
		}
	}

	public Tile getSouthWest() {
		if (row > 0 && col > 0) {
			if (tiles [row - 1, col - 1] == null) {
				tiles [row - 1, col - 1] = new Tile (x - size, y - size, size);
				return tiles [row - 1, col - 1];
			} else {
				return tiles [row - 1, col - 1];
			}
		}
		else {
			Debug.LogError ("trying to access tiles[" + col + "][" + row + "] - index out of bounds array size = [" + tilesSize + "][" + tilesSize + "]");
			return null;
		}
	}

	void randomAstroids () {

	}
	// Methods
	/*void renderObjects () {
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
	}*/
}
