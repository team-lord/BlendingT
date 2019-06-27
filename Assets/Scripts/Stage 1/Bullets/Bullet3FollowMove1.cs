using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet3FollowMove1 : MonoBehaviour
{
    public float life;
    public float moveSpeed;

    private GameObject player;

    public float delay;
    private float time;

    private Vector2 direction;
    private float dot;
    private float angle;
    private float z;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, life);

        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        Move();
        if (time > delay) {
            Rotate();
            time = 0;
        }
    }

    void Move() {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime, Space.Self);
    }

    void Rotate() {
        if (gameObject.activeSelf) {
            direction = (player.transform.position - transform.position).normalized;
            dot = Vector3.Dot(transform.up, direction);
            if (dot < 1) {
                angle = Mathf.Acos(dot) * Mathf.Rad2Deg;
                z = Vector3.Cross(transform.up, direction).z;

                if (z > 0) {
                    angle = transform.rotation.eulerAngles.z + Mathf.Min(10, angle);
                } else {
                    angle = transform.rotation.eulerAngles.z - Mathf.Min(10, angle);
                }

                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            }
        }
    }
}
