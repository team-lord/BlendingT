using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorFan1 : MonoBehaviour
{
    private bool isMotorFanOn;

    private bool isReady;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        isMotorFanOn = false;

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Change() {
        isMotorFanOn = !isMotorFanOn;
        // animator에서 isMotorFanOn을 받아가세요
        animator.SetTrigger("change");
    }

    IEnumerator WaitChange(float time)
    {
        yield return new WaitForSeconds(time);
        animator.SetTrigger("change");

    }
}
