using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet3Honey2 : MonoBehaviour
{
    private GameObject player;
    private GameObject boss;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        boss = GameObject.Find("Boss");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            if (!player.GetComponent<HealthP2>().GetIsInvincible()) {
                boss.GetComponent<FireBeeAB2>().Fire();
            }

            /*
            GameObject[] _beeBs = GameObject.FindGameObjectsWithTag("EnemyBeeB");
            Debug.Log(_beeBs.Length);
            
            for(int i=0; i<_beeBs.Length; i++) {
                _beeBs[i].GetComponent<BulletBeeB2>().Turn();
            }
            */

            player.GetComponent<HealthP2>().Hit();
            StartCoroutine(Destroy());
        }
    }

    IEnumerator Destroy() {
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
