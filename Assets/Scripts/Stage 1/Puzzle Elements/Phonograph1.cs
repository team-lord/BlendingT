using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phonograph1 : MonoBehaviour
{
    private GameObject dolls;

    private int currentNumber; // 0, 1, 2, 3: Off

    //Animator animator;

    GameObject platformB;
    AudioSource platformBaudio;

    GameObject kid;
    AudioSource kidaudio;

    GameObject guy;
    AudioSource guyaudio;

    GameObject old;
    AudioSource oldaudio;
    
    // Start is called before the first frame update

    void Start()
    {
        dolls = GameObject.Find("Dolls");

        currentNumber = 3;

        platformB = GameObject.Find("PlatformB");
        platformBaudio = platformB.GetComponent<AudioSource>();

        kid = GameObject.Find("Kid");
        kidaudio = kid.GetComponent<AudioSource>();

        guy = GameObject.Find("Guy");
        guyaudio = guy.GetComponent<AudioSource>();

        old = GameObject.Find("Old");
        oldaudio = old.GetComponent<AudioSource>();

       // animator.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Change() {

        if(currentNumber < 3) {
            currentNumber++;
        } else {
            currentNumber = 0;
        }

        dolls.GetComponent<Dolls1>().Change(currentNumber);
        /*
        if(currentNumber == 3)
        {
            animator.SetBool("phonographPlay", false);
        }
        else
        {
            animator.SetBool("phonographPlay", true);
        }
        */
        /*
        switch (currentNumber)
        {
            case 0:
                StartCoroutine(ChangeBGM(platformBaudio, kidaudio));
                break;
            case 1:
                StartCoroutine(ChangeBGM(kidaudio, guyaudio));
                break;
            case 2:
                StartCoroutine(ChangeBGM(guyaudio, oldaudio));
                break;
            case 3:
                StartCoroutine(ChangeBGM(oldaudio, platformBaudio));
                break;
        }
        */
    }
    /*
    IEnumerator ChangeBGM(AudioSource offAudio, AudioSource onAudio)
    {
        offAudio.volume = 0.9f;
        yield return new WaitForSeconds(0.1f);
        offAudio.volume = 0.8f;
        yield return new WaitForSeconds(0.1f);
        offAudio.volume = 0.7f;
        yield return new WaitForSeconds(0.1f);
        offAudio.volume = 0.6f;
        yield return new WaitForSeconds(0.1f);
        offAudio.volume = 0.5f;
        yield return new WaitForSeconds(0.1f);
        offAudio.volume = 0.4f;
        yield return new WaitForSeconds(0.1f);
        offAudio.volume = 0.3f;
        yield return new WaitForSeconds(0.1f);
        offAudio.volume = 0.2f;
        yield return new WaitForSeconds(0.1f);
        offAudio.volume = 0.1f;
        onAudio.Play();
        yield return new WaitForSeconds(0.1f);
        offAudio.Stop();
        offAudio.volume = 1;
    }
    */
}
