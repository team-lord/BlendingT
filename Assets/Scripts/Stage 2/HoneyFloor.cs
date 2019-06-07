using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyFloor : MonoBehaviour
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

    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.tag == "Player") {
            collider.GetComponent<Player2>().isHoneyAttached = true;
            Destroy(gameObject);
            // player의 sprite를 꿀 묻은 형태로 바꾸기
        }

    }
    
}
