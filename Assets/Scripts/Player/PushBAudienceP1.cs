using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBAudienceP1 : MonoBehaviour
{
    private bool isPushed;
    public float pushedTime; // CHECK - Tumble Reverse 재생시간
    public float pushedSpeed;

    private Vector3 normalVector;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        isPushed = false;
        normalVector = Vector3.zero;

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isPushed) {
            Pushed();
        }
    }

    void Pushed() {
        transform.Translate(normalVector * pushedSpeed * Time.deltaTime, Space.Self);
    }

    public void PushStart(Vector3 _Vector3) {
        normalVector = _Vector3;
        animator.SetFloat("normalVectorX", normalVector.x);
        animator.SetFloat("normalVectorY", normalVector.y);

        animator.SetTrigger("pushed");
        StartCoroutine(IsPushed());
    }

    IEnumerator IsPushed() {
        isPushed = true;
        GetComponent<AttackFireP1>().CanAttackFire(false);
        GetComponent<MoveTumbleP1>().CanMoveTumble(false);
        yield return new WaitForSeconds(pushedTime);
        isPushed = false;
        GetComponent<AttackFireP1>().CanAttackFire(true);
        GetComponent<MoveTumbleP1>().CanMoveTumble(true);
    }
}
