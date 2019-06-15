﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever1 : MonoBehaviour
{
    private bool isReal;
    public int number;

    private bool isReady;

    // Start is called before the first frame update
    void Awake()
    {
        isReal = false;
    }

    void Start() {
        isReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IsReal(bool _bool) {
        isReal = _bool;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "PlayerMelee") {
            if (isReal) {
                if (isReady) {
                    StartCoroutine(IsReady());
                    GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
                    GameObject.Find("Bulb").GetComponent<Bulb>().IsReady();
                }
            } else {
                GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
                GetComponentInParent<Levers1>().Change(number);
            }
        }
    }

    public void TurnOff() {
        GetComponent<SpriteRenderer>().flipX = false;
    }

    IEnumerator IsReady() {
        isReady = false;
        yield return new WaitForSeconds(GetComponentInParent<Levers1>().delay);
        isReady = true;
    }
}