using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurpriseBox : MonoBehaviour
{
    public bool collided;

    // Start is called before the first frame update
    void Start()
    {
        collided = false;    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider) {
        collided = true;
    }

    void OnTriggerExit2D(Collider2D collision) {
        collided = false;
    }
}

// TODO