using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public bool[] change = new bool[3];

    public float delayQ; // == 1

    public GameObject needleRed1Q;
    public GameObject needleRed2Q;
    public GameObject needleRed3Q;

    public GameObject needleGreen1Q;
    public GameObject needleGreen2Q;
    public GameObject needleGreen3Q;

    public GameObject needleBlue1Q;
    public GameObject needleBlue2Q;
    public GameObject needleBlue3Q;

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<change.Length; i++) {
            change[i] = false;
        }   
    }

    // Update is called once per frame
    void Update()
    {
        if (change[0]) {
            needleRed1Q.GetComponent<BoardNeedle>().change = true;
            needleRed2Q.GetComponent<BoardNeedle>().change = true;
            needleRed3Q.GetComponent<BoardNeedle>().change = true;
            change[0] = false;
        }
        if (change[1]) {
            needleGreen1Q.GetComponent<BoardNeedle>().change = true;
            needleGreen2Q.GetComponent<BoardNeedle>().change = true;
            needleGreen3Q.GetComponent<BoardNeedle>().change = true;
            change[1] = false;
        }
        if (change[2]) {
            needleBlue1Q.GetComponent<BoardNeedle>().change = true;
            needleBlue2Q.GetComponent<BoardNeedle>().change = true;
            needleBlue3Q.GetComponent<BoardNeedle>().change = true;
            change[2] = false;
        }
    }
}
