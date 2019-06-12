using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower2 : MonoBehaviour
{
    public int maxHealth;
    private int health;

    public int index; // 0, 1, 2
    private int number; // 남은 tower의 개수

    private bool isAttack;

    public GameObject laser;
    public float laserDelay;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;

        isAttack = false;

        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttack) {
            time += Time.deltaTime;
            if(time > laserDelay) {
                time = 0;
                Fire();
            }
        }
    }

    void Fire() {
        switch (number) {
            case 3:
                // TODO - 레이저 3갈래
                break;
            case 2:
                // TODO - 레이저 4갈래
                break;
            case 1:
                // TODO - 레이저 4갈래 + 전방위
                break;
            default:
                Debug.Log("Error");
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (isAttack) {
            if (collision.tag == "PlayerBullet") {
                health--;
                CheckAlive();
            } else if (collision.tag == "PlayerMelee") {
                // health -= 2;
                CheckAlive();
            }
        }        
    }

    void CheckAlive() {
        if(health <= 0) {
            GetComponentInParent<Towers2>().Destroy(index);
            isAttack = false;
            // 쓰러지는 애니메이션 시작
        }
    }

    public void IsAttack(bool _bool, int _int) {
        if (_bool) {
            // 켜지는 애니메이션 시작
        } else {
            // 꺼지는 애니메이션 시작
        }
        isAttack = _bool;
        number = _int;
    }
}
