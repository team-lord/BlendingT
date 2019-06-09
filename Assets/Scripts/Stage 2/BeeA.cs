using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeA : MonoBehaviour
{
    public float moveSpeedQ;
    public int maxHealthQ;
    private int health;
    private int phase; // 1 -> 2 -> 3
    public float phaseDelayQ;

    private bool canFire1;
    public float fireDelayQ;

    // TODO
    // 강화 b c 물어보고 구현하기

    private bool canFire2;

    public GameObject bulletQ;

    private GameObject player;
    private bool isLethal; // 원거리 공격으로는 무력화만. 마무리는 근접 공격으로만 가능.
    private float time;

    private bool isReady;
    public float reviveDelayQ;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealthQ;
        phase = 1;

        canFire1 = true;

        player = GameObject.Find("Player");
        isLethal = false;
        time = 0;

        isReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLethal) {
            time += Time.deltaTime;

            Move();

            switch (phase) {
                case 3:
                case 2:
                case 1:
                    if (canFire1) {
                        StartCoroutine(Fire1(fireDelayQ));
                    }
                    break;
                default:
                    Debug.Log("Error");
                    break;

            }

            CheckPhase();

        } else {
            if (isReady) {
                StartCoroutine(Revive(reviveDelayQ));
            }
        }
        
    }

    IEnumerator Fire1(float time) {
        canFire1 = false;
        Fire1Bullet();
        yield return new WaitForSeconds(time);
        canFire1 = true;

    }

    void Fire1Bullet() {
        Vector3 _direction = (player.transform.position - transform.position).normalized;

        Instantiate(bulletQ, transform.position, Quaternion.LookRotation(Vector3.up, _direction));
    }

    void Move() {
        Vector3 _direction = (player.transform.position - transform.position).normalized;

        transform.rotation = Quaternion.Euler(Vector3.zero);
        transform.rotation = Quaternion.LookRotation(Vector3.up, _direction);

        transform.Translate(Vector3.up * moveSpeedQ * Time.deltaTime, Space.Self);
    }

    void CheckPhase() {
        switch (phase) {
            case 1:
                if (time > phaseDelayQ) {
                    phase++;
                    time = 0;
                }
                break;
            case 2:
                if (time > phaseDelayQ) {
                    phase++;
                    time = 0;
                }
                break;
            case 3:
                break;
            default:
                Debug.Log("Error");
                break;
        }
    }

    IEnumerator Revive (float time) {
        isReady = false;
        yield return new WaitForSeconds(time);
        isLethal = false;
        if(phase < 3) {
            phase++; // 부활시 즉시 강화
        }
    }

    private void OnTriggerEnter2D (Collider2D collider) {
        if (!isLethal) {
            if(collider.tag == "PlayerBullet") {
                health--;
                CheckAlive();
            }
            /*
            if (collider.tag == "PlayerMelee") {
                health -= 2;
                CheckAlive();
            }
            */
        } else {
            if(collider.tag == "PlayerMelee") {
                Destroy(gameObject);
            }
        }
    }

    void CheckAlive() {
        if(health <= 0) {
            health = 0;
            time = 0;
            isLethal = true;
        }
    }
}
