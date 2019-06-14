using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBPlayer2 : MonoBehaviour {
    private GameObject player;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            player.GetComponent<HealthP1>().Hit();
            StartCoroutine(Destroy());
        }
    }

    IEnumerator Destroy() {
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
