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
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Jump() {
        isJump = true;
        animator.SetTrigger("jump");
        StartCoroutine(JumpCollider());
    }

    IEnumerator JumpCollider() {
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<MoveB2>().IsMove(false);        
        Debug.Log(false);
        yield return new WaitForSeconds(0.6f);
        transform.position = new Vector3(64, 0, 0);
        GetComponent<CircleCollider2D>().enabled = true;
        Debug.Log(true);
    }

    public void Fall(Vector3 _vector3) {
        if (!isJump) {
            return;
        }
        isJump = false;
        transform.position = _vector3;
        
        //GetComponent<MoveB2>().IsMove(true);

        animator.SetTrigger("fall");
    }

    public void Special0Fall(Vector3 _vector3) {
        if (!isJump) {
            return;
        }
        isJump = false;
        transform.position = _vector3;

        animator.SetTrigger("fall");
    }

}
