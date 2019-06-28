using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainLayer : MonoBehaviour
{
    public float yOffset;

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
            layer = -16860;

        else
            layer = 16860;

        rend.sortingOrder = -(int)(layer * 100);

    }
}
