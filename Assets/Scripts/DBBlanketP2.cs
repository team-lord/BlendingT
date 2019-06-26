using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DBBlanketP2 : MonoBehaviour
{
    private GameObject boss;
    private bool isReady;

    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.Find("Boss");
        isReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Blanket") {
            if (isReady)
            {
                isReady = false;
                boss.GetComponent<PatternB2>().ForceStart();
                Destroy(gameObject);
            }
        }        
    }
}
