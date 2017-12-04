using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed;
    [SerializeField]
    private BagManager bag;
    private int health = 1;
    public GameObject sword;

    public BagManager Bag {
        get {
            return bag;
        }

        set {
            bag = value;
        }
    }

    void Start () {
		
	}

    void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            this.sword.SetActive(true);
        }
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (horizontal != 0 || vertical != 0) {
            Vector3 move = new Vector3(horizontal, vertical, 0);
            float reduction = (float)Mathf.Log((float)( this.Bag.Gold/13 ), 2f)/3;
            if (reduction < 0) {
                reduction = 0;
            }
            float currentSpeed = ( this.speed - reduction );
            if (currentSpeed < 1) {
                currentSpeed = 1;
            }
            Debug.Log(currentSpeed);
            this.transform.position += move * currentSpeed * Time.deltaTime;

            float angle = Mathf.Atan2(move.y, move.x) * Mathf.Rad2Deg;
            this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    public void takeDamage() {
        this.health -= 1;
    }

    public void pickupCoin() {
        this.Bag.addGold(10);
    }

    public bool isDead() {
        return health <= 0;
    }

}
