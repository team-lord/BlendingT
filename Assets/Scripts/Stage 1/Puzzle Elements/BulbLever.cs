using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulbLever : MonoBehaviour
{
    public GameObject bulb;

    private bool isReady;
    public float delay;

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
                StartCoroutine(Wait());
                GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
                bulb.GetComponent<Bulb>().IsReady();
            }
        }
        
    }

    IEnumerator Wait() {
        isReady = false;
        yield return new WaitForSeconds(delay);
        isReady = true;
    }
}
