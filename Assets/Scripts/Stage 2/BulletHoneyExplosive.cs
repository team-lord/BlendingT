using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHoneyExplosive : MonoBehaviour
{
    public bool isFall;

    public GameObject BulletHoneyQ;

    // Start is called before the first frame update
    void Start()
    {
        isFall = true;        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFall) {
            Fall();
        } else {
            Explode();
        }
        
    }

    void Fall() {
        // 떨어지는 애니메이션
        CheckIsFall();
    }

    void CheckIsFall() {
        // 애니메이션이 끝나면 isFall = false;
    }

    void Explode() {
        Destroy(gameObject);
        for(int i=0; i<6; i++) {
            FireBullet(60 * i);
        }
    }

    void FireBullet(int degree) {
        Instantiate(BulletHoneyQ, transform.position, Quaternion.Euler(0, 0, degree));
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.tag == "Blanket") {
            Destroy(gameObject);
        }
    }
}
