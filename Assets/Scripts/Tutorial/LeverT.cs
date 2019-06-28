using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverT : MonoBehaviour
{
    public bool isMelee;
    private bool isOn;
    public GameObject door;
    private GameObject buttonSoundBox;
    public AudioClip buttonSound;
    AudioSource buttonSoundBoxAudio;

    // Start is called before the first frame update
    void Start()
    {
        isOn = false;
        buttonSoundBox = GameObject.Find("ButtonSoundBox");
        buttonSoundBoxAudio = buttonSoundBox.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Change() {
        isOn = true;
        transform.localScale = new Vector3(-1, 1, 1);
        door.GetComponent<DoorT>().ChangeMelee(isMelee);
        buttonSoundBoxAudio.PlayOneShot(buttonSound);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (isMelee) {
            if(collision.tag == "PlayerMelee") {
                Change();
            }
        } else {
            if(collision.tag == "PlayerBullet") {
                Change();
                Destroy(collision.gameObject);
            }
        }
    }
}
