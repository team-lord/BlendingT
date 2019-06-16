using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dolls1 : MonoBehaviour
{
    private bool isReady;

    public Collider2D[] colliders = new Collider2D[4];

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

        foreach(Collider2D collider in colliders) {
            collider.enabled = false;
        }
        colliders[3].enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isReady) {
            colliders[currentDoll].enabled = false;

            if (currentDoll == targetDoll) {
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

            colliders[currentDoll].enabled = true;

        }
    }
    
    public void TargetDoll(int number) {
        isReady = true;
        targetDoll = number;
    }
}
