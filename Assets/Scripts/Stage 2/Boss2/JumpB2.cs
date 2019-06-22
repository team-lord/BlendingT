using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpB2 : MonoBehaviour
{
    // 애니메이션 전용

    private bool isJump;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        isJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Jump() {
        isJump = true;
        // TODO - 날기

        animator.SetTrigger("jump");
    }

    public void Fall() {
        if (!isJump) {
            return;
        }
        transform.position = Vector3.zero;

        // TODO - 떨어지기
        animator.SetTrigger("fall");
    }
}
