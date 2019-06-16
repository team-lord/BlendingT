using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardNeedle1 : MonoBehaviour
{
    private bool isReady;

    // public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        isReady = false;
    }
    
    // Update is called once per frame
    void Update() {
        if (isReady) {            
            //if (animator.GetCurrentAnimatorStateInfo(0).IsName("Rotate")) {
                // TODO - 애니메이션 끝

            //}            
        }
    }

    public void Rotate() {
        isReady = true;

        // TODO - 애니메이션 시작
        
        // 20 -> 70, 70 -> 20, 200 -> 250, 250 -> 200 확인할 것  
    }
}
