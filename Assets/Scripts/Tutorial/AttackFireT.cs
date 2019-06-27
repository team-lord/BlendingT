using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackFireT : MonoBehaviour {

    private bool canAttackFire;

    public float toggleDelay;
    private bool canToggle;
    private bool isMelee;

    // 근접 공격
    private GameObject meleeAttack;
    public float attackTime;
    public float attackDelay;
    private bool canAttack;

    // 원거리 공격
    public GameObject bullet;
    public float fireDelay;
    private bool canFire;
    private GameObject cursor;

    public Image attackCore;

    // Start is called before the first frame update
    void Start() {
        canAttackFire = true;

        canToggle = true;
        isMelee = false;

        meleeAttack = GameObject.Find("PlayerMeleeAttack");
        canAttack = true;

        canFire = true;
        cursor = GameObject.Find("Cursor");
    }

    // Update is called once per frame
    void Update() {
        if (canAttackFire) {
            if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)) {
                if (canToggle) {
                    StartCoroutine(CanToggle());
                    isMelee = !isMelee;
                    if (isMelee) {
                        attackCore.GetComponent<AttackCore>().Melee();
                    } else {
                        attackCore.GetComponent<AttackCore>().Range();
                    }
                }
            }

            if (isMelee) {
                if (Input.GetMouseButtonDown(0)) {
                    if (canAttack) {
                        StartAttack();
                    }
                }
            } else {
                if (Input.GetMouseButton(0)) {
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

        meleeAttack.GetComponent<MeleeAttackP>().Attack();
    }

    IEnumerator CanAttack() {
        canAttack = false;
        yield return new WaitForSeconds(attackTime + attackDelay);
        canAttack = true;
    }

    IEnumerator IsAttacking() {
        GetComponent<MoveTumbleT>().CanMoveTumble(false);
        yield return new WaitForSeconds(attackTime);
        GetComponent<MoveTumbleT>().CanMoveTumble(true);
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
