using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    public float speed;

	void Update () {
        this.transform.position += transform.right * this.speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            collision.gameObject.GetComponent<Player>().takeDamage();
        }
        if (collision.gameObject.tag == "Enemy") {
            collision.gameObject.GetComponent<Enemy>().kill();
        }

        Destroy(this.gameObject);
    }
}
