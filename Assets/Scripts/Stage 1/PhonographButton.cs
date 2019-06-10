﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhonographButton : MonoBehaviour
{
    public int numberQ; // answer = 2; 0, 1, 2
    
    public Sprite onSpriteQ;
    private Sprite offSprite;

    // Start is called before the first frame update
    void Start()
    {
        offSprite = GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnOff() {
        GetComponent<SpriteRenderer>().sprite = offSprite;
    }

    private void OnTriggerEnter2D(Collider2D collider) {

        if (collider.tag == "PlayerBullet") {
            Change();
        }
    }

    void Change() {
        
        GetComponentInParent<Phonograph>().Change(numberQ);
        GetComponent<SpriteRenderer>().sprite = onSpriteQ;
      
    }
}
