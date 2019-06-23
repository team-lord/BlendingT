using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBNTumble : MonoBehaviour {
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
            player.GetComponent<HealthP2>().Hit();
            if (!player.GetComponent<HealthP2>().GetIsInvincible()) {
                StartCoroutine(Destroy());
            }
        }
    }

    IEnumerator Destroy() {
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
