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
      
    private Vector3 directionToPlayer;

    Animator animator;

    // Start is called before the first frame update
    void Start() {
        isMove = true;

        player = GameObject.Find("Player");

        animator = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void FixedUpdate() {
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
        animator.SetFloat("directionToPlayerX", directionToPlayer.x);
        animator.SetFloat("directionToPlayerY", directionToPlayer.y);
    }
}
