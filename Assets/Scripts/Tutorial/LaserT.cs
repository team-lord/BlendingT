using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserT : MonoBehaviour
{
    private GameObject player;
    public GameObject respawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if(collision.tag == "Player") {
            if (player.GetComponent<HealthT>().GetIsInvincible()) {

            }
        }
    }
}
