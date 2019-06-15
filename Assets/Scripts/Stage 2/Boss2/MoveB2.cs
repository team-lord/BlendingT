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

    public Animator bossAnimator;
    private Vector3 directionToPlayer;

    // Start is called before the first frame update
    void Start() {
        isMove = false;

        player = GameObject.Find("Player");

        bossAnimator = GetComponent<Animator>();
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
        LookPlayer();
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

    void LookPlayer()
    {
        directionToPlayer = (player.transform.position - transform.position).normalized;
        bossAnimator.SetFloat("directionToPlayerX", directionToPlayer.x);
        bossAnimator.SetFloat("directionToPlayerY", directionToPlayer.y);
    }
}
