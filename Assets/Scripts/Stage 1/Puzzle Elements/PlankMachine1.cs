using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankMachine1 : MonoBehaviour
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

        animator.SetFloat("current", 0);
        animator.SetFloat("trash", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeNext() { // 0 -> 1 -> 2 -> 0

        if (isReady) {
            StartCoroutine(IsReady());
            animator.SetFloat("go", currentPlank);
            animator.SetFloat("back", 7);
            animator.SetTrigger("on");

            if(currentPlank < 2) {
                currentPlank++;
            } else {
                currentPlank = 0;
            }

            animator.SetFloat("current", currentPlank);

            rightButton.GetComponent<PlankMachineButton1>().Change();
        }
    }

    public void ChangePrevious() { // 2 -> 1 -> 0 -> 2
        if (isReady) {
            StartCoroutine(IsReady());
            animator.SetFloat("go", 7);
            animator.SetFloat("back", currentPlank);
            animator.SetTrigger("on");

            if (currentPlank > 0) {
                currentPlank--;
            } else {
                currentPlank = 2;
            }

            animator.SetFloat("current", currentPlank);

            leftButton.GetComponent<PlankMachineButton1>().Change();
        }
    }

    IEnumerator IsReady() {
        isReady = false;
        yield return new WaitForSeconds(delay);
        isReady = true;
    }

    public int CurrentPlank() {
        return currentPlank;
    }
}
