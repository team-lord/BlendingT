﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFireP1 : MonoBehaviour {

    private bool canAttackFire;

    public float toggleDelay;
    private bool canToggle;
    private bool isMelee;

    // 근접 공격
    public GameObject meleeAttack;
    public float attackTime;
    public float attackDelay;
    private bool canAttack;

    // 원거리 공격
    public GameObject bullet;
    public float fireDelay;
    private bool canFire;
    private GameObject cursor;
   
    // Start is called before the first frame update
    void Start()
    {
        canAttackFire = true;

        canToggle = true;
        isMelee = false;

        canAttack = true;

        canFire = true;
        cursor = GameObject.Find("Cursor");
    }

    // Update is called once per frame
    void Update()
    {
        if (canAttackFire) {
            if (Input.GetKeyDown(KeyCode.LeftShift)) {
                if (canToggle) {
                    StartCoroutine(CanToggle());
                    isMelee = !isMelee;
                }
            }

            if (Input.GetMouseButton(0)) {
                if (isMelee) {
                    if (canAttack) {
                        StartAttack();
                    }
                } else {
                    if (canFire) {
                        Fire();
                    }
                }

            }
        }              
    }

    public void CanAttackFire(bool _bool) {
        canAttackFire = _bool;
    }

    IEnumerator CanToggle() {
        canToggle = false;
        yield return new WaitForSeconds(toggleDelay);
        canToggle = true;
    }

    void StartAttack() {
        StartCoroutine(CanAttack());
        StartCoroutine(IsAttacking());

        // TODO - 애니메이션에서 방향 정하고 처리
    }

    IEnumerator CanAttack() {
        canAttack = false;
        yield return new WaitForSeconds(attackTime + attackDelay);
        canAttack = true;
    }

    IEnumerator IsAttacking() {
        GetComponent<MoveTumbleP1>().CanMoveTumble(false);
        yield return new WaitForSeconds(attackTime);
        GetComponent<MoveTumbleP1>().CanMoveTumble(true);
    }

    void Fire() {
        StartCoroutine(CanFire());
        Vector3 _direction = (cursor.transform.position - transform.position).normalized;
        Instantiate(bullet, transform.position, Quaternion.FromToRotation(Vector3.up, _direction));
    }

    IEnumerator CanFire() {
        canFire = false;
        yield return new WaitForSeconds(fireDelay);
        canFire = true;
    }

}
