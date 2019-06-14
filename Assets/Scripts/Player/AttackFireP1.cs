using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFireP1 : MonoBehaviour {

    public float toggleDelay;
    private bool canToggle;
    private bool isMelee;

    // 근접 공격
    public GameObject sword;
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
        canToggle = true;
        isMelee = false;

        canAttack = true;

        canFire = true;
        cursor = GameObject.Find("Cursor");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            if (canToggle) {
                StartCoroutine(CanToggle());
                isMelee = !isMelee;
            }            
        }

        if (Input.GetMouseButton(0)) {
            if (isMelee) {
                if (canAttack) {
                    Attack();
                }
            } else {
                if (canFire) {
                    Fire();
                }
            }
            
        }
    }

    IEnumerator CanToggle() {
        canToggle = false;
        yield return new WaitForSeconds(toggleDelay);
        canToggle = true;
    }

    void Attack() {
        StartCoroutine(CanAttack());
        // TODO - 근접 공격
        Debug.Log("Attack");
    }

    IEnumerator CanAttack() {
        canAttack = false;
        yield return new WaitForSeconds(attackDelay);
        canAttack = true;
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
