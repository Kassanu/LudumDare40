using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Bag") {
            collision.GetComponent<BagManager>().AtTarget = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.tag == "Bag") {
            collision.GetComponent<BagManager>().AtTarget = false;
        }
    }
}
