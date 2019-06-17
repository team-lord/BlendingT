using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dolls1 : MonoBehaviour
{
    public Collider2D[] colliders = new Collider2D[4];

    private int currentDoll;
    private int targetDoll;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {

        currentDoll = 3;
        targetDoll = 3;

        animator = GetComponent<Animator>();

        animator.SetFloat("Current", 3);
        animator.SetFloat("Next", 0);

        foreach(Collider2D collider in colliders) {
            collider.enabled = false;
        }
        colliders[3].enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
        
    public void Change(int number) {
        colliders[currentDoll].enabled = false;

        animator.SetFloat("Next", number);
        animator.SetTrigger("On");
        animator.SetFloat("Current", number);

        currentDoll = number;

        colliders[currentDoll].enabled = true;
    }
}
