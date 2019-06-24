using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke1 : MonoBehaviour
{
    // TODO - 연막탄 등장 및 소멸

    public float life;

    Animator animator;
    AudioSource myaudio;
    public AudioClip smokeSound;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, life);

        animator = GetComponent<Animator>();

        myaudio = GetComponent<AudioSource>();

        // animator.SetTrigger("start");
        animator.SetTrigger("smoke");
        myaudio.PlayOneShot(smokeSound);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
