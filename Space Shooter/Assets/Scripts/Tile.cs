using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile {

	// Static data
	// -----------

	// Will contain a list of all created tiles in the game
	public static int tilesSize = 100;
	static public Tile[,] tiles = new Tile[tilesSize,tilesSize];


	// Class data
	// ----------

	// size of the tile in relation to the camera size
	private int size;

	// Tiles x, y position (center of tile)
	int x;
	int y;

	// Tiles current position in the tiles array
	int row;
	int col;

	// Lists of enemies and astroids that will be randomdly generatied

	GameObject[] enemyType;
	GameObject[] enemies;
	int enemiesSize;

	GameObject[] asteroidType;
	GameObject[] asteroids;
	int asteroidsSize;

	bool loadEnemy;

	// Constructor
	public Tile (int x, int y, int size) {

		this.x = x;
		this.y = y;
		this.size = size;

		this.row = x / size;
		this.col = y / size;

		// Adding newly created tile to tiles array
		tiles [row,col] = this;


		enemiesSize = Random.Range (1, 4); // number of enemies in a tile
		asteroidsSize = Random.Range (1, 4); // number of asteroids in a tile

		asteroidType = new GameObject[asteroidsSize]; // Stores the asteroid prefab
		asteroids = new GameObject[asteroidsSize]; // stores the asteroid gameobject

		enemyType = new GameObject[enemiesSize]; // stores the enemy prefab
		enemies = new GameObject[enemiesSize]; // stores the enemy gameobject

		// Choosing a random asteroid prefab to be rendered
		randomAsteriods ();
		randomEnemies ();

		displayTileBox ();
	}

	// Getters
	// -------

	public int getX () {
		return x;
	}

	public int getY () {
		return y;
	}

	public float getSize () {
		return size;
	}

	// Getters for surrounding Tiles
	// -----------------------------

	public Tile getNorth() {
		if (row > 0) {
			if (tiles [row - 1, col] == null) {
				tiles [row - 1, col] = new Tile (x - size, y, size);
				return tiles [row - 1, col];
			} else {
				return tiles [row - 1, col];
			}
		} 
		else {
			Debug.LogError ("trying to access tiles[" + (row - 1) + "][" + col + "] - index out of bounds array size = [" + tilesSize + "][" + tilesSize + "] - N");
			return null;
		}
	}

	public Tile getSouth() {
		if (row < tilesSize) {
			if (tiles [row + 1, col] == null) {
				tiles [row + 1, col] = new Tile (x + size, y, size);
				return tiles [row + 1, col];
			} else {
				return tiles [row + 1, col];
			}
		}
		else {
			Debug.LogError ("trying to access tiles[" + (row + 1) + "][" + col + "] - index out of bounds array size = [" + tilesSize + "][" + tilesSize + "] - S");
			return null;
		}
	}

	public Tile getEast() {
		if (col < tilesSize) {
			if (tiles [row, col + 1] == null) {
				tiles [row, col + 1] = new Tile (x, y + size, size);
				return tiles [row, col + 1];
			} else {
				return tiles [row, col + 1];
			}
		}
		else {
			Debug.LogError ("trying to access tiles[" + row + "][" + (col + 1) + "] - index out of bounds array size = [" + tilesSize + "][" + tilesSize + "] - E");
			return null;
		}
	}

	public Tile getWest() {
		if (col > 0) {
			if (tiles [row, col - 1] == null) {
				tiles [row, col - 1] = new Tile (x, y - size, size);
				return tiles [row, col - 1];
			} else {
				return tiles [row, col - 1];
			}
		}
		else {
			Debug.LogError ("trying to access tiles[" + row + "][" + (col - 1) + "] - index out of bounds array size = [" + tilesSize + "][" + tilesSize + "] - W");
			return null;
		}
	}

	public Tile getNorthEast() {
		if (row > 0 && col < tilesSize) {
			if (tiles [row - 1, col + 1] == null) {
				tiles [row - 1, col + 1] = new Tile (x - size, y + size, size);
				return tiles [row - 1, col + 1];
			} else {
				return tiles [row - 1, col + 1];
			}
		}
		else {
			Debug.LogError ("trying to access tiles[" + (row - 1) + "][" + (col + 1) + "] - index out of bounds array size = [" + tilesSize + "][" + tilesSize + "] - NE");
			return null;
		}
	}

	public Tile getNorthWest() {
		if (row > 0 && col > 0) {
			if (tiles [row - 1, col - 1] == null) {
				tiles [row - 1, col - 1] = new Tile (x - size, y - size, size);
				return tiles [row - 1, col - 1];
			} else {
				return tiles [row - 1, col - 1];
			}
		}
		else {
			Debug.LogError ("trying to access tiles[" + (row - 1) + "][" + (col - 1) + "] - index out of bounds array size = [" + tilesSize + "][" + tilesSize + "] - NW");
			return null;
		}
	}

	public Tile getSouthEast() {
		if (row < tilesSize && col < tilesSize) {
			if (tiles [row + 1, col + 1] == null) {
				tiles [row + 1, col + 1] = new Tile (x + size, y + size, size);
				return tiles [row + 1, col + 1];
			} else {
				return tiles [row + 1, col + 1];
			}
		}
		else {
			Debug.LogError ("trying to access tiles[" + (row + 1) + "][" + (col +1) + "] - index out of bounds array size = [" + tilesSize + "][" + tilesSize + "] SE");
			return null;
		}
	}

	public Tile getSouthWest() {
		if (row < tilesSize && col > 0) {
			if (tiles [row + 1, col - 1] == null) {
				tiles [row + 1, col - 1] = new Tile (x + size, y - size, size);
				return tiles [row + 1, col - 1];
			} else {
				return tiles [row + 1, col - 1];
			}
		}
		else {
			Debug.LogError ("trying to access tiles[" + (row + 1) + "][" + (col - 1) + "] - index out of bounds array size = [" + tilesSize + "][" + tilesSize + "] - SW");
			return null;
		}
	}

	// This function will get a random asteroid an store it in a GameObject array
	void randomAsteriods () {

		for (int i = 0; i < asteroidsSize; i++) {
			int randNum = Random.Range (1, 4);
			if (randNum == 1) {
				if (Resources.Load<GameObject> ("Models/Asteriods/Prefabs/AsteriodField01") != null) {
					asteroidType [i] = Resources.Load<GameObject> ("Models/Asteriods/Prefabs/AsteriodField01");
					asteroids [i] = asteroidType [i];
				} 
				else {
					Debug.Log ("Cant load file");
				}
			} 
			else if (randNum == 2) {
				if (Resources.Load<GameObject> ("Models/Asteriods/Prefabs/AsteriodField02") != null) {
					asteroidType [i] = Resources.Load<GameObject> ("Models/Asteriods/Prefabs/AsteriodField02");
					asteroids [i] = asteroidType [i];
				} 
				else {
					Debug.Log ("Cant load file");
				}
			} 
			else if (randNum == 3) {
				if (Resources.Load<GameObject> ("Models/Asteriods/Prefabs/AsteriodField03") != null) {
					asteroidType [i] = Resources.Load<GameObject> ("Models/Asteriods/Prefabs/AsteriodField03");
					asteroids [i] = asteroidType [i];
				} 
				else {
					Debug.Log ("Cant load file");
				}
			} 
			else {
				Debug.Log ("Invalid number: " + randNum);
			}
		}
	}

	void randomEnemies () {
		int randomNum = Random.Range (0, 4);

		if (randomNum == 2) {
			enemyType [0] = Resources.Load<GameObject> ("ufoRed");
			enemies [0] = enemyType [0];
			loadEnemy = true;
		} 
		else {
			loadEnemy = false;
		}
	}

	// Methods
	public void renderObjects () {
		Vector3 offset = new Vector3 (3.3f, 0f, 0f);
		Vector3 curPos = new Vector3 (x, y, 0);

		for (int i = 0; i < asteroidsSize; i++) {
			asteroids [i] = GameObject.Instantiate (asteroidType [i]) as GameObject;
			asteroids [i].transform.position = curPos;
			curPos += offset;
		}

		if (loadEnemy) {
			enemies [0] = GameObject.Instantiate (enemyType [0]) as GameObject;
			enemies [0].transform.position = new Vector3 (x, y, 0) + new Vector3 (0, -2.5f, 0);
		}
	}

	public void destoryAllObjects () {
		for (int i = 0; i < asteroidsSize; i++) {
			GameObject.Destroy (asteroids [i]);
		}
		if (loadEnemy) {
			GameObject.Destroy (enemies [0]);
		}
	}

	// Display tiles in game
	void displayTileBox() {
		GameObject sq = new GameObject ("Tile " + x + ", " + y);
		SpriteRenderer r = sq.AddComponent<SpriteRenderer> ();
		r.sprite = Resources.Load<Sprite> ("Square");
		r.color = Random.ColorHSV ();
		sq.transform.position = new Vector3 (x, y, 2);
		sq.transform.localScale = new Vector3 (10, 10, 10);
	}

}
