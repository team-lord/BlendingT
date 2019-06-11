using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet3FollowMove1 : MonoBehaviour
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
        Move();
        Rotate();
    }

    void Move() {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime, Space.Self);
    }

    void Rotate() {
        float _z = transform.rotation.eulerAngles.z;
        Vector3 _direction = new Vector3(Mathf.Cos(Mathf.Deg2Rad * _z), Mathf.Sin(Mathf.Deg2Rad * _z), 0);

        transform.Translate(_direction * coefficient * Time.deltaTime);
    }
}
