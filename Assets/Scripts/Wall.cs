using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    // 총알들을 소멸시키는 스크립트

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.tag=="PlayerBullet" || collider.tag == "EnemyBullet") {
            Destroy(collider);
        }
    }
}
