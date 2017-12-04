using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Enemy {

    public Arrow arrowPrefab;
    public Arrow spawnedArrow;
    public float fireRate;
    private float nextFire;
    public Transform shotSpawn;

    void Start() {
        this.nextFire = this.fireRate;
    }
	
	void Update () {
        if (this.nextFire <= 0) {
            this.nextFire = this.fireRate;
            if (this.spawnedArrow == null)
                this.spawnedArrow = Instantiate(this.arrowPrefab, this.shotSpawn.transform.position, this.shotSpawn.transform.rotation);
        } else {
            this.nextFire -= 1;
        }
    }
}
