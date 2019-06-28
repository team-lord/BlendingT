using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsingNullifyingCoreP : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UseNullyfingCore()
    {
        StartCoroutine(BecomingNullifyingCore());
    }

    IEnumerator BecomingNullifyingCore()
    {
        transform.localPosition = Vector3.zero;
        animator.SetTrigger("change");
        yield return new WaitForSeconds(0.25f);
        transform.localPosition = new Vector3(0, 64, 0);
    }
}
