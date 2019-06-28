using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsingNullifyingCoreP : MonoBehaviour
{
    Animator animator;
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UseNullifyingCore()
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

    public void NullifyingCoreUsingSound()
    {
        audio.Play();
    }
}
