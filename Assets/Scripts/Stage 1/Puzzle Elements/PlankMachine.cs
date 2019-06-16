using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankMachine : MonoBehaviour
{
    private int currentPlank; // 0:Rubber, 1:Wood, 2:Ice

    private bool isReady;
    public float delay;

    public GameObject leftButton;
    public GameObject rightButton;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        currentPlank = 0;
        isReady = true;

        animator = GetComponent<Animator>();

        animator.SetFloat("Current", 0);
        animator.SetFloat("Trash", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeNext() { // 0 -> 1 -> 2 -> 0

        if (isReady) {
            StartCoroutine(IsReady());
            animator.SetFloat("Go", currentPlank);
            animator.SetFloat("Back", 7);
            animator.SetTrigger("On");

            if(currentPlank < 2) {
                currentPlank++;
            } else {
                currentPlank = 0;
            }

            animator.SetFloat("Current", currentPlank);

            rightButton.GetComponent<PlankMachineButton>().Change();
        }
    }

    public void ChangePrevious() { // 2 -> 1 -> 0 -> 2
        if (isReady) {
            StartCoroutine(IsReady());
            animator.SetFloat("Go", 7);
            animator.SetFloat("Back", currentPlank);
            animator.SetTrigger("On");

            if (currentPlank > 0) {
                currentPlank--;
            } else {
                currentPlank = 2;
            }

            animator.SetFloat("Current", currentPlank);

            leftButton.GetComponent<PlankMachineButton>().Change();
        }
    }

    IEnumerator IsReady() {
        isReady = false;
        yield return new WaitForSeconds(delay);
        isReady = true;
    }
}
