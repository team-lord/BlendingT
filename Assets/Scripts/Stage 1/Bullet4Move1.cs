﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet4Move1 : MonoBehaviour
{
    // 속도
    public Vector3 direction;
    public float moveSpeedQ;

    // 수명 - 이 친구는 있어야 함
    public float lifeQ;

    // 유도
    public bool isFollowing;
    private GameObject player;
    public float coefficientQ; // 유도의 정도를 정하는 계수

    // Start is called before the first frame update
    void Start() {
        Destroy(gameObject, lifeQ); // 유도 기능이 있으므로 이게 정말 중요하다. 평생 안사라질 수도 있음

        isFollowing = false;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update() {
       
        if (!isFollowing) {
            Move();
        } else {
            MoveFollow();
        }

    }

    void Move() {
        transform.Translate(Vector3.up * moveSpeedQ * Time.deltaTime, Space.Self);
    }

    void MoveFollow() {
        // TODO
        // 유도탄 날아가기
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Blanket") {
            Destroy(gameObject);
        }
    }
}
