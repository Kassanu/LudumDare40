using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour {
    private int columns = 8;
    private int rows = 8;
    public GameObject[] floorTiles;                                 
    public GameObject[] wallTiles;
    private Transform board;

    public int Columns {
        get {
            return columns;
        }

        set {
            columns = value;
        }
    }

    public int Rows {
        get {
            return rows;
        }

        set {
            rows = value;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BoardSetup(int minBoardWidth, int maxBoardWidth, int minBoardHeight, int maxBoardHeight) {

        this.Columns = Random.Range(minBoardWidth, maxBoardWidth);
        this.Rows = Random.Range(minBoardHeight, maxBoardHeight);

        this.board = new GameObject("Board").transform;

        for (int x = -1; x < this.Columns + 1; x++) {
            for (int y = -1; y < this.Rows + 1; y++) {
                GameObject toInstantiate = this.floorTiles[Random.Range(0, this.floorTiles.Length)];

                if (x == -1 || x == this.Columns || y == -1 || y == this.Rows)
                    toInstantiate = this.wallTiles[Random.Range(0, this.wallTiles.Length)];

                GameObject instance = Instantiate(toInstantiate, new Vector3(x, y, 0f), Quaternion.identity) as GameObject;

                instance.transform.SetParent(this.board);
            }
        }

    }

}
