using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special0Honey2 : MonoBehaviour
{
    public GameObject playerBulletHoney;

    // Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        // animator = GetComponent<Animator>();

        // 계속 움직이는(Loop) 상태가 Default State
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "PlayerBullet") {
            Instantiate(playerBulletHoney, collision.transform.position, collision.transform.rotation);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
