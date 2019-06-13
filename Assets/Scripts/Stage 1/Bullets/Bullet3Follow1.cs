using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet3Follow1 : MonoBehaviour
{
    public float life;

    public float moveSpeed;
    public float coefficient;

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

        float _z = Vector3.Cross(transform.up, _direction).z;
        transform.Translate(Vector3.right * _z * Time.deltaTime);
    }
}
