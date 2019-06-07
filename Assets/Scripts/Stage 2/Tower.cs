using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public int maxHealthQ;
    public int health;

    public int indexQ; // 0, 1, 2

    public bool isAttack;

    public GameObject laserQ;

    private float time;

    public Sprite TowerOnQ;
    public Sprite TowerOff;
    public Sprite TowerDestoryQ;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealthQ;

        isAttack = false;

        time = 0;

        TowerOff = GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update() {

        if (isAttack) {
            time += Time.deltaTime;

            switch (GetComponent<Towers>().number) {
                case 3:
                    // 레이저 3갈래
                    break;
                case 2:
                    // 레이저 4갈래
                    break;
                case 1:
                    // 레이저 4갈래 + 전방위 탄막
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
            if (collider.tag == "PlayerMelee") {
                // health -= 2;
            }
            CheckAlive();
        }
    }

    void CheckAlive() {
        if(health <= 0) {
            GetComponentInParent<Towers>().status[indexQ] = 2;
            GetComponentInParent<Towers>().number--;

            GetComponentInParent<Towers>().isDestroyed = true;

            time = 0;
            // Destroy(gameObject);
            GetComponent<SpriteRenderer>().sprite =TowerDestoryQ;
        }
    }
}
