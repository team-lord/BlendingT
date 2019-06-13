using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeB2 : MonoBehaviour
{

    private int phase;
    private bool isLethal;

    private float phaseDelay;
    private float phaseTime;
    private float time;
    private GameObject player;

    public GameObject bullet;
    public float phase0Delay;

    public float phase1Delay;

    public GameObject honeyExplosiveBullet;
    public float phase2Delay;

    // Start is called before the first frame update
    void Start() {
        phase = 0;
        isLethal = false;

        time = 0;
        phaseTime = 0;
        player = GameObject.Find("Player");
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
                        Vector3 _playerDirection = player.GetComponent<MoveTumbleP>().MoveDirection();
                        Vector3 _direction = player.transform.position - transform.position;
                        Instantiate(bullet, transform.position, Quaternion.FromToRotation(Vector3.up, (_direction - 2 * _playerDirection).normalized));
                        Instantiate(bullet, transform.position, Quaternion.FromToRotation(Vector3.up, (_direction - _playerDirection).normalized));
                        Instantiate(bullet, transform.position, Quaternion.FromToRotation(Vector3.up, _direction.normalized));
                        Instantiate(bullet, transform.position, Quaternion.FromToRotation(Vector3.up, (_direction + _playerDirection).normalized));
                        Instantiate(bullet, transform.position, Quaternion.FromToRotation(Vector3.up, (_direction + 2 * _playerDirection).normalized));
                        Instantiate(bullet, transform.position, Quaternion.FromToRotation(Vector3.up, (_direction + 3 * _playerDirection).normalized));
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

    public void IsLethal(bool _bool) {
        isLethal = _bool;

        time = 0;
        phaseTime = 0;

        if (_bool) {
            // TODO - 바둥거리는 애니메이션 시작
        } else {
            if (phase < 2) {
                phase++;
            }
            // TODO - 바둥거리는 애니메이션 끝
        }
    }
}
