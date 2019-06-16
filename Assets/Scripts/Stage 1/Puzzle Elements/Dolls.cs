using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dolls : MonoBehaviour
{
    private bool isReady;

    private int currentDoll;
    private int targetDoll;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        isReady = false;

        currentDoll = 3;
        targetDoll = 3;

        animator = GetComponent<Animator>();

        animator.SetFloat("Target", 3);
        animator.SetFloat("Trash", 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (isReady) {
            if (currentDoll == targetDoll) {
                // TODO - targetDoll이 내려가는 애니메이션 시작
                animator.SetFloat("Current", currentDoll);
                animator.SetFloat("Target", 3);
                animator.SetTrigger("On");

                currentDoll = 3;

            }
            else {
                animator.SetFloat("Current", currentDoll);
                animator.SetFloat("Target", targetDoll);
                animator.SetTrigger("On");
                currentDoll = targetDoll;

            }
            isReady = false;
        }
    }
    
    public void TargetDoll(int number) {
        isReady = true;
        targetDoll = number;
    }
}
