using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardLever1 : MonoBehaviour
{
    public int color; // 1: red, 2: green, 3: blue
    public float delay;

    private bool isReady;

    public AudioClip buttonSound;
    AudioSource soundBoxAudio;
    GameObject buttonSoundBox;

    // Start is called before the first frame update
    void Start()
    {
        isReady = true;
        buttonSoundBox = GameObject.Find("ButtonSoundBox");
        soundBoxAudio = buttonSoundBox.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (isReady) {
            if (collision.tag == "PlayerMelee") {
                StartCoroutine(Wait());
                GetComponentInParent<Board1>().Rotate(color);
                float _x = transform.localScale.x;
                transform.localScale = new Vector3(-_x, 1, 1);
                soundBoxAudio.PlayOneShot(buttonSound);
            }
        }
    }

    IEnumerator Wait() {
        isReady = false;        
        yield return new WaitForSeconds(delay);
        isReady = true;
    }
}
