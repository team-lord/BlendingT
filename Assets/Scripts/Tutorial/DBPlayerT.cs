using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBPlayerT : MonoBehaviour {

    private GameObject player;
    public Vector3 respawnLocation;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            if (!player.GetComponent<HealthT>().GetIsInvincible()) {
                player.transform.position = respawnLocation;
            }
        }
    }

}
