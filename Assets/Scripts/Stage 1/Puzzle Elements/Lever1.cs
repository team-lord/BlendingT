using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever1 : MonoBehaviour
{
    private bool isReal;
    public int number;

    private bool isReady;
    private bool isReadyFake;

    public AudioClip normalButtonSound;
    public AudioClip specialButtonSound;
    
    private GameObject buttonSoundBox;

    AudioSource audio;

    // Start is called before the first frame update
    void Awake()
    {
        isReal = false;
    }

    void Start() {
        isReady = true;
        isReadyFake = true;
        buttonSoundBox = GameObject.Find("ButtonSoundBox");
        audio = buttonSoundBox.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IsReal(bool _bool) {
        isReal = _bool;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "PlayerMelee") {
            if (isReal) {
                if (isReady) {
                    StartCoroutine(IsReady());
                    float _x = transform.localScale.x;
                    transform.localScale = new Vector3(-_x, 1, 1);
                    GameObject.Find("Bulb").GetComponent<Bulb1>().IsReady();
                    audio.PlayOneShot(specialButtonSound);
                }
            } else {
                if (isReadyFake) {
                    StartCoroutine(IsReadyFake());
                    float _x = transform.localScale.x;
                    transform.localScale = new Vector3(-_x, 1, 1);
                    audio.PlayOneShot(normalButtonSound);
                }
            }
        }
    }

    public void TurnOff() {
        GetComponent<SpriteRenderer>().flipX = false;
    }

    IEnumerator IsReady() {
        isReady = false;
        yield return new WaitForSeconds(GetComponentInParent<Levers1>().delay);
        isReady = true;
    }

    IEnumerator IsReadyFake() {
        isReadyFake = false;
        yield return new WaitForSeconds(0.1f);
        isReadyFake = true;
    }
}
