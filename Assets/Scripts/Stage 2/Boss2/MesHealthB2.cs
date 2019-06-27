using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MesHealthB2 : MonoBehaviour
{
    private bool isMes;
    private int damage;

    // Start is called before the first frame update
    void Start()
    {
        isMes = false;
        damage = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (isMes) {
            if(collision.tag == "PlayerBullet") {
                damage++;
                Destroy(collision.gameObject);
            } else if(collision.tag == "PlayerMelee") {
                damage += 2;
            }
        }
    }

    public void IsMes(bool _bool) {
        isMes = _bool;
    }
    
    public int Damage() {
        return damage;
    }
}
