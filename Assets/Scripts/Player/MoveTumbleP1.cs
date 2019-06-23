using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTumbleP1 : MonoBehaviour
{
    private bool canMoveTumble;

    // 이동
    public float moveSpeed;

    private float h;
    private float v;

    // 구르기
    private bool canTumble;
    public float tumbleTime;
    public float tumbleSpeed;
    public float tumbleDelay;
    private bool isTumbling;

    private GameObject audienceManager;

    Animator animator;

    private GameObject cursor;

    // Start is called before the first frame update
    void Start()
    {
        canMoveTumble = true;

        canTumble = true;
        isTumbling = false;
        audienceManager = GameObject.Find("AudienceManager");
        animator = GetComponent<Animator>();

        cursor = GameObject.Find("Cursor");
    }

    // Update is called once per frame
    void Update()
    { 
        if (canMoveTumble) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                if (canTumble) {
                    if (h != 0 || v != 0) {
                        StartTumble();
                    animator.SetTrigger("startTumble");

                    }
                }
            }
        }
        SetCursorDirection();
    }

    void FixedUpdate() {
        if (canMoveTumble) {
            if (isTumbling) {
                Tumble();
            } else {
                Move();
            }
        }        
    }

    public void CanMoveTumble(bool _bool) {
        canMoveTumble = _bool;
    }

    void StartTumble() {
        StartCoroutine(CanTumble());
        StartCoroutine(IsTumbling());
        
        audienceManager.GetComponent<AudienceManager1>().Tumble();
        
    }

    IEnumerator CanTumble() {
        canTumble = false;
        yield return new WaitForSeconds(tumbleTime + tumbleDelay);
        canTumble = true;
    }

    IEnumerator IsTumbling() {
        isTumbling = true;
        GetComponent<AttackFireP1>().CanAttackFire(false);
        GetComponent<HealthP1>().IsInvincible(true);
        yield return new WaitForSeconds(tumbleTime);
        isTumbling = false;
        GetComponent<AttackFireP1>().CanAttackFire(true);
        GetComponent<HealthP1>().IsInvincible(false);
    }

    void Tumble() {
        transform.Translate(h * Vector3.right * tumbleSpeed * Time.deltaTime, Space.World);
        transform.Translate(v * Vector3.up * tumbleSpeed * Time.deltaTime, Space.World);
    }

    void Move() {
        if (Input.GetAxis("Horizontal") > 0) {
            h = 1;
        } else if (Input.GetAxis("Horizontal") < 0) {
            h = -1;
        } else {
            h = 0;
        }        

        if (Input.GetAxis("Vertical") > 0) {
            v = 1;
        } else if (Input.GetAxis("Vertical") < 0) {
            v = -1;
        } else {
            v = 0;
        }
        

        Correction();

        if (h == 0 && v == 0)
        {
            animator.SetBool("isMove", false);
        }
        else
        {
            animator.SetBool("isMove", true);
            animator.SetFloat("lastMoveDirectionX", h);
            animator.SetFloat("lastMoveDirectionY", v);
        }

        transform.Translate(h * Vector3.right * moveSpeed * Time.deltaTime, Space.World);
        transform.Translate(v * Vector3.up * moveSpeed * Time.deltaTime, Space.World);
    }

    void Correction() {
        if(h != 0 && v != 0) {
            h *= 1 / Mathf.Sqrt(2);
            v *= 1 / Mathf.Sqrt(2);
        }
    }

    public Vector3 MoveDirection() { // 플레이어의 이동을 예측하는 패턴에서 호출
        return new Vector3(h, v, 0);
    }

    void SetCursorDirection()
    {
        Vector2 _direction = (cursor.transform.position - transform.position).normalized;
        animator.SetFloat("cursorDirectionX", _direction.x);
        animator.SetFloat("cursorDirectionY", _direction.y);
    }
}