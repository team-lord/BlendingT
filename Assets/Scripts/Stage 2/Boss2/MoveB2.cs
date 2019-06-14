using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveB2 : MonoBehaviour {

    private Vector3 direction;

    public float moveSpeed;
    private bool isMove;

    private float time;
    public float changeDirectionDelay;

    private GameObject player;

    private Animator bossIdle;
    private Vector2 playerDirection;

    // Start is called before the first frame update
    void Start() {
        isMove = false;

        player = GameObject.Find("Player");

        bossIdle = GetComponent<Animator>();
    }

    void FixedUpdate() {
        FixRotate();
    }

    void FixRotate() {
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    // Update is called once per frame
    void Update() {
        if (isMove) {
            time += Time.deltaTime;
            if (time > changeDirectionDelay) {
                ChangeDirection();
            }
            Move();
        }
        IdleBossDirection();
    }

    public void IsMove(bool _bool) {
        isMove = _bool;
    }

    void Move() {
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    void ChangeDirection() {
        direction = (player.transform.position - transform.position).normalized;
        time = 0;
    }

    public Vector3 GiveDirection()
    {
        return direction;
    }

    void IdleBossDirection()
    {
        playerDirection = (player.transform.position - transform.position).normalized;

        if (playerDirection.x > 0)
            bossIdle.SetFloat("directionToPlayerX", 1);
        else if (playerDirection.x < 0)
            bossIdle.SetFloat("directionToPlayerX", -1);
        else if (playerDirection.x == 0)
            bossIdle.SetFloat("directionToPlayerX", 0);

        if (playerDirection.y > 0)
            bossIdle.SetFloat("directionToPlayerY", 1);
        else if (playerDirection.y < 0)
            bossIdle.SetFloat("directionToPlayerY", -1);
        else if (playerDirection.y == 0)
            bossIdle.SetFloat("directionToPlayerY", 0);
    }
}
