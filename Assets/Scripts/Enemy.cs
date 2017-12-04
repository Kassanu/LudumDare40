using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public Coin coinPrefab;

    void Start() {
        
    }

    void Update () {
       
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            collision.gameObject.GetComponent<Player>().takeDamage();
            Destroy(this.gameObject);
        }
    }

    public void kill() {
        Instantiate(this.coinPrefab, this.transform.position, new Quaternion(0,0,0,0));
        Destroy(this.gameObject);
    }

}
