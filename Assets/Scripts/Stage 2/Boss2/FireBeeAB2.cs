using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBeeAB2 : MonoBehaviour
{
    public GameObject beebulletA;

    public AudioClip hitHoney;
    AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire() {
        audio.PlayOneShot(hitHoney);
        Instantiate(beebulletA, transform.position + 2 * Vector3.left, transform.rotation);
        Instantiate(beebulletA, transform.position + 2 * Vector3.right, transform.rotation);
    }
}
