using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BlanketT : MonoBehaviour {
    public GameObject blanket;
    private GameObject usingNullifyingCore;
    private bool canBlanket;

    public Image nullifyingCore;

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
        usingNullifyingCore.GetComponent<UsingNullifyingCoreP>().UseNullifyingCore();
        usingNullifyingCore.GetComponent<UsingNullifyingCoreP>().NullifyingCoreUsingSound();
        nullifyingCore.GetComponent<NullifyingCore>().UseBlanket(); 
    }

    public void GetBlanket() {
        canBlanket = true;
    }
}
