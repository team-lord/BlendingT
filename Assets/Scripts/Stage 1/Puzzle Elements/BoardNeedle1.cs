using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardNeedle1 : MonoBehaviour
{
    private bool isReady;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        isReady = false;
        animator = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update() {
        if (isReady) {            
                   
        }
    }

    public void Rotate() {
        isReady = true;

        // TODO - 애니메이션 시작
        animator.SetTrigger("Change");
        // 20 -> 70, 70 -> 20, 200 -> 250, 250 -> 200 확인할 것  
    }
}
