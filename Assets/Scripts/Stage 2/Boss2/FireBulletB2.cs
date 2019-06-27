using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBulletB2 : MonoBehaviour
{
    public GameObject honeyBullet;

    public float delay;
    private float time;

    private GameObject player;

    private bool isReady;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;

        player = GameObject.Find("Player");

        isReady = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isReady) {
            time += Time.deltaTime;

            if (time > delay) {
                time = 0;
                Fire();
            }
        }       
    }

    void Fire() {
        Vector3 _direction = (player.transform.position - transform.position).normalized;

        Instantiate(honeyBullet, transform.position, Quaternion.FromToRotation(Vector3.up, _direction));
    }

    public void IsReady(bool _bool) {
        isReady = _bool;
    }
}
