using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BlanketT : MonoBehaviour {
    public GameObject blanket;
    private bool canBlanket;

    public Image nullifyingCore;

    // Start is called before the first frame update
    void Start() {
        canBlanket = true;
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
        nullifyingCore.GetComponent<NullifyingCore>().UseBlanket(); 
    }

    public void GetBlanket() {
        canBlanket = true;
    }
}
