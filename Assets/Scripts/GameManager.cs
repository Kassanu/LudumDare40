using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    private BoardManager boardManager;
    public Enemy[] enemyPrefabs;
    public Coin coinPrefab;
    public Player player;
    public int minBoardWidth, maxBoardWidth, minBoardHeight, maxBoardHeight;
    public int minSpawnTime, maxSpawnTime, timeToSpawn;
    public Text goldText;
    public GameObject blackScreen;
    private bool isGameOver, restart;

    void Start () {
        this.isGameOver = false;
        this.restart = false;
        this.boardManager = GetComponent<BoardManager>();
        this.boardManager.BoardSetup(this.minBoardWidth, this.maxBoardWidth, this.minBoardHeight, this.maxBoardHeight);
        this.timeToSpawn = Random.Range(this.minSpawnTime, this.maxSpawnTime);
    }
	
	void Update () {
        if (this.restart) {
            if (Input.GetKeyDown(KeyCode.R)) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            this.blackScreen.SetActive(true);
        } else {

            if (this.player.isDead()) {
                this.gameOver();
            } else {
                if (this.timeToSpawn <= 0) {
                    this.spawnEnemies();
                    this.timeToSpawn = Random.Range(this.minSpawnTime, this.maxSpawnTime);
                } else {
                    this.timeToSpawn -= 1;
                }
                this.goldText.text = "Gold: " + this.player.Bag.Gold;
            }
        }
    }

    void spawnEnemies() {
        int amount = Random.Range(1, 4);
        Quaternion rotation = Quaternion.identity;
        Vector3 spawnLocation = Vector3.zero;
        int enemy = 0;
        for (int i = 0; i < amount; i++) {
            enemy = Random.Range(0, this.enemyPrefabs.Length);
            rotation = Quaternion.identity;
            spawnLocation = Vector3.zero;
            int wall = 3;
            if (enemy == 0) {
                //spawn chaser
                spawnLocation = new Vector3(Random.Range(0, this.boardManager.Columns), Random.Range(0, this.boardManager.Rows), 0);
                while (this.tooCloseToPlayer(spawnLocation)) {
                    spawnLocation = new Vector3(Random.Range(0, this.boardManager.Columns), Random.Range(0, this.boardManager.Rows), 0);
                }
                rotation = new Quaternion(0, 0, 0, 0);
            } else if (enemy == 1) {
                //spawn archer
                wall = Random.Range(0, 4); //0 = top, 1 = right, 2 = bottom, 3 = left wall spawn
                switch (wall) {
                    case 3: //left wall spawn first col random row - face right
                        spawnLocation = new Vector3(0, Random.Range(0, this.boardManager.Rows), 0);
                        break;
                    case 2: //bottom wall spawn random col first row - face up
                        spawnLocation = new Vector3(Random.Range(0, this.boardManager.Columns), 0, 0);
                        rotation = Quaternion.AngleAxis(90, Vector3.forward);
                        break;
                    case 1:  //right wall last col random row - face left
                        spawnLocation = new Vector3(this.boardManager.Columns - 1, Random.Range(0, this.boardManager.Rows), 0);
                        rotation = Quaternion.AngleAxis(180, Vector3.forward);
                        break;
                    default: //top wall spawn random col last row - face down
                        spawnLocation = new Vector3(Random.Range(0, this.boardManager.Columns), this.boardManager.Rows - 1, 0);
                        rotation = Quaternion.AngleAxis(-90, Vector3.forward);
                        break;

                }
            }
            Instantiate(this.enemyPrefabs[enemy], spawnLocation, rotation);
        }
    }

    private bool tooCloseToPlayer(Vector3 position) {
        return Vector3.Distance(this.player.transform.position, position) < 2;
    }

    public void spawnGold() {
        Vector3 spawnLocation = new Vector3(Random.Range(0, this.boardManager.Columns), Random.Range(0, this.boardManager.Rows), 0);
        Instantiate(this.coinPrefab, spawnLocation, new Quaternion(0,0,0,0));
    }

    public void gameOver() {
        this.isGameOver = true;
        this.restart = true;
    }

}
