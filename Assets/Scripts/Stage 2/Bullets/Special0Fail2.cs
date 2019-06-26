using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special0Fail2 : MonoBehaviour {

    public float delay;
    private float time;

    private GameObject player;

    private Vector3 direction;
    private float dot;
    private float angle; // degree
    private float z;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.Find("Player");

        time = 0;
    }

    // Update is called once per frame
    void FixedUpdate() {
        time += Time.deltaTime;
        if (time > delay) {
            Rotate();
            time = 0;
        }
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
