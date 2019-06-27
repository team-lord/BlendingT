using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpB2 : MonoBehaviour
{
    // 애니메이션 전용

    private bool isJump;

    Animator bossAnimator;
    Animator shadowAnimator;

    GameObject boss;
    GameObject shadow;

    // Start is called before the first frame update
    void Start()
    {
        isJump = false;
        boss = GameObject.Find("Boss");
        bossAnimator = boss.GetComponent<Animator>();
        shadow = GameObject.Find("Shadow");
        shadowAnimator = shadow.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Jump() {
        isJump = true;
        // TODO - 날기
        GetComponent<MoveB2>().IsMove(false);

        GetComponent<CircleCollider2D>().enabled = false;

        bossAnimator.ResetTrigger("throw");

        bossAnimator.SetTrigger("jump");
        shadowAnimator.SetTrigger("shadowOff");
    }

    public void Fall(Vector3 _vector3) {
        if (!isJump) {
            return;
        }
        isJump = false;
        transform.position = _vector3;
        
        //GetComponent<MoveB2>().IsMove(true);

        GetComponent<CircleCollider2D>().enabled = true;

        bossAnimator.SetTrigger("fall");
        shadowAnimator.SetTrigger("shadowOn");
    }

    public void Special0Fall(Vector3 _vector3) {
        if (!isJump) {
            return;
        }
        isJump = false;
        transform.position = _vector3;
        
        GetComponent<CircleCollider2D>().enabled = true;

        bossAnimator.SetTrigger("fall");
        shadowAnimator.SetTrigger("shadowOn");
    }

}
