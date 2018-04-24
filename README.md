# Assignment2
Object Oriented Programming Assignment for College

Simple 2D space shooter with an infinite procedural generating world. The objective is to kill and many UFOs before dying. All assets where obtained for free from https://opengameart.org/.

![alt text](https://github.com/titanProgram/Assignment2/raw/master/pic.png "Logo Title Text 1")

![Watch gameplay video](https://plays.tv/video/5adf4966bcd93e4eaf/d)


---
## MAIN FEATURES

### World Generation
The world is divided up into tiles. each tile has a number of game objects that it will store. When the player is is in a tile, all the game objects (enemies, asteroids, etc) will be loaded into the game and all game objects not in the players view will get removed from the game. The game objects in each tile are generated randomaly.

### Bullets
All bullets originate from the Bullet class. When a bullet object is created it is stored in a static array which stores all bulllets. All the bullets are updated with a single function at the same time. When a bullet is out of bounds of the camera it is destroyed to free up memory.

### Health
All ships have a Health component that I created. When they take damage their health is decreased when it gets to 0 a "kill" function will get called which will destroy the game object and display an explosion.

---

> Almost all of the components and game objects are generated/created with code.

#### Learning Outcomes
During this assignment I learnt how to use an industry standard game engine and 2D procedural world generation

---

## Where to download the game
Within the first three days my game has gotten 30+ downloads on the indie game website itch.io.
>Link to my game: https://bobthecoderr.itch.io/space-shooter
