using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulbLever : MonoBehaviour
{
    public GameObject bulb;

    private bool isReady;
    public float delayQ;

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
                StartCoroutine(BulbPulse(delayQ));
            }
        }
        
    }

    IEnumerator BulbPulse(float time) {
        isReady = false;
        GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
        bulb.GetComponent<Bulb>().bulbPulse = true;
        yield return new WaitForSeconds(time);
        isReady = true;
    }
}
