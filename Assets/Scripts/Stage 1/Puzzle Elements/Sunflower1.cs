using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunflower1 : MonoBehaviour
{
    private bool isReady;
    
    private bool isBulbOn;

    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        isReady = false;
        isBulbOn = false;

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        if (isReady) {
            isReady = false;
            animator.SetTrigger("change");
            isBulbOn = !isBulbOn;
        }
    }

    public void IsReady() {
        isReady = true;
    }

}
