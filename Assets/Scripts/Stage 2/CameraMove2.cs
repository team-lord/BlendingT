﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WatchPlayer() {
        GetComponent<CameraMove>().IsWatchingPlayer(true);
    }

    public void WatchPlayerCenter() {
        GetComponent<CameraMove>().IsWatchingPlayerCenter(true);
    }

    public void WatchRight() {
        GetComponent<CameraMove>().IsWatchingRight(true);
    }

    public void WatchCore(Vector3 position) {
        GetComponent<CameraMove>().IsWatchingCore(true, position);
    }
}
