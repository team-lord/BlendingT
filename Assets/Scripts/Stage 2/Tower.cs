using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public int maxHealthQ;
    public int health;

    public bool isAttack;
    private int number; // 3 -> 2 -> 1

    public int indexQ;

    public GameObject laserQ;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealthQ;

        isAttack = false;
        number = 0;

    }

    // Update is called once per frame
    void Update() {

        if (isAttack) {
            switch (number) {
                case 3:

                    break;
                case 2:
                    break;
                case 1:
                    break;
                default:
                    Debug.Log("Error");
                    break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (isAttack) {
            if (collider.tag == "PlayerBullet") {
                health--;
            }
            if(collider.tag == "PlayerMelee") {
                // health -= 2;
            }
            CheckAlive();
        }
    }

    void CheckAlive() {
        if(health <= 0) {
            GetComponentInParent<Towers>().isDestroyed[indexQ] = true;
            Destroy(gameObject);
        }
    }
}
