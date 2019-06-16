using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardLever1 : MonoBehaviour
{
    public int color; // 1: red, 2: green, 3: blue
    public float delay;

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

    private void OnTriggerEnter2D(Collider2D collision) {
        if (isReady) {
            if (collision.tag == "PlayerMelee") {
                StartCoroutine(Wait());
                GetComponentInParent<Board1>().Rotate(color);
                GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
            }
        }
    }

    IEnumerator Wait() {
        isReady = false;        
        yield return new WaitForSeconds(delay);
        isReady = true;
    }
}
