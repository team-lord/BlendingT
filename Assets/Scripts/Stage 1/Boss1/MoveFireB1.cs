﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFireB1 : MonoBehaviour {

    private Vector3 direction; // for animation

    public float moveSpeed;
    private bool isMove;

    private float time;
    public float changeDirectionDelay;

    private GameObject player;

    public GameObject bullet;
    private bool canFire;
    public float fireDelay;

    private Vector3 directionToPlayer;

    Animator animator;
    
    // Start is called before the first frame update
    void Start() {
        isMove = true;

        player = GameObject.Find("Player");

        direction = Vector3.down;
        ChangeDirection();

        time = 0;

        canFire = true;

        animator = GetComponent<Animator>();
        animator.SetBool("isBossMove", true);
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (isMove) {
            time += Time.deltaTime;
            if (time > changeDirectionDelay) {
                ChangeDirection();
            }
            Move();
            if (canFire) {
                Fire();
            }
        }
        LookPlayer();
    }

    public void IsMove(bool _bool) {
        isMove = _bool;
        animator.SetBool("isBossMove", _bool);
    }

    void Move() {
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    void ChangeDirection() {
        direction = (player.transform.position - transform.position).normalized;
        time = 0;
    }

    void Fire() {
        StartCoroutine(CanFire());
        
        float _range = Random.Range(0, 1f);
        int _degree = Random.Range(0, 360);
        Vector3 _randomVector = _range * new Vector3(Mathf.Cos(_degree * Mathf.Deg2Rad), Mathf.Sin(_degree * Mathf.Deg2Rad), 0);

        Vector3 _direction = (player.transform.position + _randomVector - transform.position).normalized;
        
        Instantiate(bullet, transform.position, Quaternion.FromToRotation(Vector3.up, _direction));
    }

    IEnumerator CanFire() {
        canFire = false;
        yield return new WaitForSeconds(fireDelay);
        canFire = true;
    }

    void LookPlayer()
    {
        directionToPlayer = (player.transform.position - transform.position).normalized;
        animator.SetFloat("directionToPlayerX", directionToPlayer.x);
        animator.SetFloat("directionToPlayerY", directionToPlayer.y);
    }
}
