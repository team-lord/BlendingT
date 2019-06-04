using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardLever : MonoBehaviour
{
    public int colorQ; // 1: red, 2: green, 3: blue
    public float delayQ;

    private bool isReady;

    // Start is called before the first frame update
    void Start()
    {
        isReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (isReady) {
            if (collider.tag == "PlayerMelee") {
                GetComponentInParent<Board>().change[colorQ] = true;
                StartCoroutine(Wait(delayQ));
                if (GetComponent<SpriteRenderer>().flipX) {
                    GetComponent<SpriteRenderer>().flipX = false;
                } else {
                    GetComponent<SpriteRenderer>().flipX = true;
                }
            }
        }
    }

    IEnumerator Wait(float time) {
        isReady = false;
        yield return new WaitForSeconds(time);
        isReady = true;
    }
}
