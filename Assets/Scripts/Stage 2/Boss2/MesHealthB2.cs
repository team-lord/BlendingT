using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MesHealthB2 : MonoBehaviour
{
    private bool isMes;

    // Start is called before the first frame update
    void Start()
    {
        isMes = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (isMes) {
            if(collision.tag == "PlayerBullet") {
                GiveDamage(1);
                Destroy(collision.gameObject);
            } else if(collision.tag == "PlayerMelee") {
                GiveDamage(2);
            }
        }
    }

    void GiveDamage(int damage) {
        GetComponent<HealthB2>().Phase3MesHealth(damage);
    }

    public void IsMes(bool _bool) {
        isMes = _bool;
    }
}
