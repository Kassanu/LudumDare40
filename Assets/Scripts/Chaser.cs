using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : Enemy {

    public float speed;
    public GameObject moveTarget;

    void Start () {
        this.moveTarget = GameObject.FindWithTag("Player");
    }
	
	void Update () {
        this.transform.position = Vector3.MoveTowards(this.transform.position, this.moveTarget.transform.position, this.speed * Time.deltaTime);
        float angle = Mathf.Atan2(this.moveTarget.transform.position.y - this.transform.position.y, this.moveTarget.transform.position.x - this.transform.position.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
