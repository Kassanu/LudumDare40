using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagManager : MonoBehaviour {

    public int gold;
    private Transform player;
    public Transform moveTarget;
    private bool atTarget = false;
    private float scale;
    private float speed;

    public int Gold {
        get { return gold; }
        set { gold += value; }
    }

    public bool AtTarget {
        get { return atTarget; }
        set { atTarget = value;  }
    }

    public void addGold(int amount) {
        this.Gold = amount;
        this.updateBagSize();
    }

    public void updateBagSize() {
        this.scale = 1 + Mathf.Log(this.Gold/11, 2f)/5f;
        if (float.IsInfinity(this.scale)) {
            this.scale = 1;
        }
        transform.localScale = new Vector3(this.scale, this.scale, 0);
    }

    void Start () {
        this.player = this.transform.parent;
        this.scale = 0.0f;
        this.speed = 3.25f;
    }

    void Update() {
        if (!atTarget) {
            float reduction = (float)Mathf.Log((float)( this.Gold / 13 ), 2f) / 3;
            if (reduction < 0) {
                reduction = 0;
            }
            float currentSpeed = ( this.speed - reduction );
            if (currentSpeed < 0.75) {
                currentSpeed = 0.75f;
            }
            this.transform.position = Vector3.MoveTowards(this.transform.position, this.moveTarget.position, currentSpeed * Time.deltaTime);
        }
    }
}
