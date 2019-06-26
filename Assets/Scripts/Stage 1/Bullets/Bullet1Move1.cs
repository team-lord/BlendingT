using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1Move1 : MonoBehaviour {

    private GameObject player;
    private GameObject boss;

    private int phase;

    public float moveSpeed; // 0
    public float time0; // 처음 날아가는 시간

    public float time1; // 정지해 있는 시간
    private float z;

    public float rotatingVelocity; // 2

    public float fastMoveSpeed; // 3

    private float time;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.Find("Player");
        boss = GameObject.Find("Boss");

        phase = 0;

        time = 0;
    }

    // Update is called once per frame
    void Update() {
        switch (phase) {
            case 0:
                time += Time.deltaTime;
                if (time > time0) {
                    phase = 1;
                    time = 0;
                } else {
                    Move();
                }
                break;
            case 1:
                time += Time.deltaTime;
                if (time > time1) {
                    phase = 2;
                    time = 0;
                    MakeDirection();
                } // 멈춰있음
                break;
            case 2:
                time += Time.deltaTime;

                Rotate();
                break;
            case 3:
                time += Time.deltaTime;
                fastMoveSpeed += Time.deltaTime * 2;
                FastMove();
                break;
            default:
                Debug.Log("Error");
                break;
        }
    }

    void Move() {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime, Space.Self);
    }

    void MakeDirection() {
        Vector3 _direction = (((player.transform.position * 2) + (boss.transform.position * 3)) / 5 - transform.position).normalized;
        z = Quaternion.FromToRotation(Vector3.up, _direction).eulerAngles.z;
    }

    void Rotate() {
        float _z = transform.rotation.eulerAngles.z;
        _z += rotatingVelocity;
        if (_z > 360) {
            _z -= 360;
        }
        if (_z > z) {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, z));
            phase = 3;
            time = 0;
        } else {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, _z));
        }
    }

    void FastMove() {
        transform.Translate(Vector3.up * fastMoveSpeed * Time.deltaTime, Space.Self);
    }
}
