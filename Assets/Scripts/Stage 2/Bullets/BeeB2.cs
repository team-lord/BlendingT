using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeB2 : MonoBehaviour
{
    private int phase;
    private bool isLethal;

    public float phaseDelay;
    private float phaseTime;
    private float time;
    private GameObject player;

    public GameObject bullet;
    public float phase0Delay;

    public float phase1Delay;

    public GameObject honeyExplosiveBullet;
    public float phase2Delay;

    public float moveSpeed;
    private Vector3 direction;
    private float rotateTime;
    public float rotateDelay;

    Animator animator;

    // 움직이는 것 아직 구현 안 되어있음

    // Start is called before the first frame update
    void Start() {
        phase = 0;
        isLethal = false;

        time = 0;
        phaseTime = 0;
        rotateTime = 0;
        player = GameObject.Find("Player");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        if (!isLethal) {
            time += Time.deltaTime;
            phaseTime += Time.deltaTime;

            if (phaseTime > phaseDelay) {
                if (phase < 2) {
                    phase++;
                    time = 0;
                    phaseTime = 0;
                }
            }

            Move();

            if (rotateTime > rotateDelay) {
                Rotate();
                rotateTime = 0;
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
        }
    }

    public void Move() {
        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
    }

    public void Rotate() {
        int _degree = Random.Range(0, 360);
        direction = new Vector3(Mathf.Cos(_degree * Mathf.Deg2Rad), Mathf.Sin(_degree * Mathf.Deg2Rad), 0).normalized;
        animator.SetFloat("directionX", direction.x);
        animator.SetFloat("directionY", direction.y);
    }

    public void IsLethal(bool _bool) {
        isLethal = _bool;

        time = 0;
        phaseTime = 0;

        if (_bool) {
            // TODO - 바둥거리는 애니메이션 시작
            animator.SetBool("mes", true);
        } else {
            if (phase < 2) {
                phase++;
            }
            // TODO - 바둥거리는 애니메이션 끝
            animator.SetBool("mes", false);
        }
    }
}
