using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhonographButton1 : MonoBehaviour {
    public Sprite onSprite;
    private Sprite offSprite;

    public float delay;

    private bool isReady;

    // Start is called before the first frame update
    void Start() {
        offSprite = GetComponent<SpriteRenderer>().sprite;
        isReady = true;
    }

    // Update is called once per frame
    void Update() {

    }

    // Sprite 바꾸기

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "PlayerBullet") {
            if (isReady) {
                StartCoroutine(IsReady());
                GetComponentInParent<Phonograph1>().Change();
            }
            Destroy(collider);
        }
    }

    IEnumerator IsReady() {
        GetComponent<SpriteRenderer>().sprite = onSprite;
        isReady = false;
        yield return new WaitForSeconds(delay);
        isReady = true;
        GetComponent<SpriteRenderer>().sprite = offSprite;
    }
}
