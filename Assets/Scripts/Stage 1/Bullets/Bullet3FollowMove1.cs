using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet3FollowMove1 : MonoBehaviour
{
    public float life;
    public float moveSpeed;
    public float coefficient;

    private Vector2 direction;

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
        Follow();
    }

    public void Direction(Vector2 _direction) {
        direction = _direction;
    }

    void Move() {
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    void Follow() {
        Vector2 _direction = (player.transform.position - transform.position).normalized;
        transform.Translate(_direction * coefficient * Time.deltaTime);
    }
}
