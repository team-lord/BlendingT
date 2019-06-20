using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulb1 : MonoBehaviour
{
    private GameObject sunflower;
    
    private bool isBulbOn;
    private bool isReady;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        sunflower = GameObject.Find("Sunflower");

        isBulbOn = false;
        isReady = false;

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        if (isReady) {
            isReady = false;
            if (isBulbOn) {
                // TODO - 전구가 꺼지는 애니메이션 시작
                animator.SetTrigger("change");
            } else {
                // TODO - 전구가 켜지는 애니메이션 시작
                animator.SetTrigger("change");
            }
            sunflower.GetComponent<Sunflower1>().IsReady();
            isBulbOn = !isBulbOn;
        }
    }
    
    public void IsReady() {
        isReady = true;
    }
        
}
