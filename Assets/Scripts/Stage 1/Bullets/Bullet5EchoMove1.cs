﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet5EchoMove1 : MonoBehaviour
{
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();        
    }

    private void Move() {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
    }
}
