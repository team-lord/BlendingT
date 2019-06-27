using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeB2 : MonoBehaviour {
    private int phase;
    private bool isLethal;

    public float phaseDelay;
    private float phaseTime;
    private float time;
    private GameObject player;

    public GameObject bullet;
    public float phase0Delay;

    public float phase1Delay;

    public float phase2Delay;

    public float moveSpeed;
    private Vector3 direction;
    private float rotateTime;
    public float rotateDelay;

    public int maxHealth;
    private int health;
    public float wakeDelay;

    public GameObject honeyExplosiveBullet;

    Animator animator;

    // Start is called before the first frame update
    void Start() {
        phase = 0;
        isLethal = false;

        time = 0;
        phaseTime = 0;
        rotateTime = 0;
        player = GameObject.Find("Player");

        health = maxHealth;

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        if (!isLethal) {
            time += Time.deltaTime;
            rotateTime += Time.deltaTime;

            Move();

            if (rotateTime > rotateDelay) {
                Rotate();
                rotateTime = 0;
            }

            if (phase < 2) {
                phaseTime += Time.deltaTime;
                if (phaseTime > phaseDelay) {
                    phase++;
                    phaseTime = 0;
                }
            }

            switch (phase) {
                case 0:
                    if (time > phase0Delay) {
                        Vector3 _direction = (player.transform.position - transform.position).normalized;
                        Instantiate(bullet, transform.position, Quaternion.FromToRotation(Vector3.up, _direction));
                        time = 0;
                    }
                    break;
                case 1:
                    if (time > phase1Delay) {
                        Vector3 _playerDirection = player.GetComponent<MoveTumbleP2>().MoveDirection();
                        Vector3 _direction = player.transform.position - transform.position;
                        Instantiate(bullet, transform.position, Quaternion.FromToRotation(Vector3.up, (_direction - 4 * _playerDirection).normalized));
                        Instantiate(bullet, transform.position, Quaternion.FromToRotation(Vector3.up, (_direction - 2 * _playerDirection).normalized));
                        Instantiate(bullet, transform.position, Quaternion.FromToRotation(Vector3.up, _direction.normalized));
                        Instantiate(bullet, transform.position, Quaternion.FromToRotation(Vector3.up, (_direction + 2 * _playerDirection).normalized));
                        Instantiate(bullet, transform.position, Quaternion.FromToRotation(Vector3.up, (_direction + 4 * _playerDirection).normalized));
                        Instantiate(bullet, transform.position, Quaternion.FromToRotation(Vector3.up, (_direction + 6 * _playerDirection).normalized));
                        time = 0;
                    }
                    break;
                case 2:
                    if (time > phase2Delay) {
                        Instantiate(honeyExplosiveBullet, transform.position, transform.rotation);
                        time = 0;
                    }
                    break;
                default:
                    Debug.Log("Error");
                    break;
            }
        } else {
            time += Time.deltaTime;
            if (time > wakeDelay) { // 부활
                animator.SetBool("mes", false);
                health = maxHealth / 2;
                isLethal = false;
                time = 0;
                if (phase < 2) {
                    phase++;
                }
            }
        }
    }

    public void Move() {
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    public void Rotate() {
        int _degree = Random.Range(0, 360);
        direction = new Vector3(Mathf.Cos(_degree * Mathf.Deg2Rad), Mathf.Sin(_degree * Mathf.Deg2Rad), 0).normalized;
        animator.SetFloat("directionX", direction.x);
        animator.SetFloat("directionY", direction.y);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "NearbyWall") {
            Back();
            rotateTime = 0;
        }

        if (isLethal) {
            if (collision.tag == "PlayerMelee") {
                Destroy(gameObject);
            }
        } else {
            if (collision.tag == "PlayerBullet") {
                health--;
                Destroy(collision.gameObject);

                CheckAlive();
            } else if (collision.tag == "PlayerMelee") {
                health -= 2;
                CheckAlive();
            }
        }
    }

    void Back() {
        direction = Quaternion.Euler(new Vector3(0, 0, 180)) * direction;
    }

    void CheckAlive() {
        if (health <= 0) {
            animator.SetBool("mes", true);
            isLethal = true;
            health = 0;
            time = 0;
            rotateTime = 0;
            phaseTime = 0;
        }
    }

}
