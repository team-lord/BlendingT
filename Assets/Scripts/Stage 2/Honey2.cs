using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Honey2 : MonoBehaviour
{
    private GameObject boss;

    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.Find("Boss");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player") {
            boss.GetComponent<FireBeeAB2>().Fire();

            GameObject[] _beeBs = GameObject.FindGameObjectsWithTag("EnemyBeeB");
            foreach(GameObject _beeB in _beeBs) {
                _beeB.GetComponent<BulletBeeB2>().Turn();
            }

            Destroy(gameObject);
            // 플레이어 꿀 맞은 스프라이트
        }
    }
}
