using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet3Follow1 : MonoBehaviour
{
    public float life;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, life);

        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    void Rotate() {
        Vector3 _direction = (player.transform.position - transform.position).normalized;

        float _z = 5 * Vector3.Cross(_direction, transform.up).z;
        transform.Translate(transform.right * _z * Time.deltaTime);
    }
}
