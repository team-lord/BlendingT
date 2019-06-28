﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlanketP2 : MonoBehaviour {
    public GameObject blanket;
    private GameObject usingNullifyingCore;
    private bool canBlanket;

    public Image blanketImage;

    // Start is called before the first frame update
    void Start() {
        canBlanket = true;
        usingNullifyingCore = GameObject.Find("UsingNullifyingCore");
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (canBlanket) {
                UseBlanket();
            }
        }
    }

    void UseBlanket() {
        canBlanket = false;
        Instantiate(blanket, transform.position, Quaternion.identity);
        usingNullifyingCore.GetComponent<UsingNullifyingCoreP>().UseNullyfingCore();
        blanketImage.GetComponent<NullifyingCore>().UseBlanket();
    }

    public void GetBlanket() {
        canBlanket = true;
        blanketImage.GetComponent<NullifyingCore>().GetBlanket();
    }
}
