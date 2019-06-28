﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainLayer : MonoBehaviour
{

    private GameObject player;

    float layer;

    SpriteRenderer rend;

    //Vector3 centerBottom;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player"); 
        rend = GetComponent<SpriteRenderer>();
    }


    void Update()
    {

        //centerBottom = transform.TransformPoint(rend.sprite.bounds.min);

        //layer = centerBottom.y + yOffset;
        if (player.transform.position.y >= 0)
            layer = 168;

        else
            layer = -168;

        rend.sortingOrder = -(int)(layer * 100);

    }
}