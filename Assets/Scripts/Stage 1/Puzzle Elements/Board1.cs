using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board1 : MonoBehaviour
{
    public GameObject[] needleReds = new GameObject[3];
    public GameObject[] needleGreens = new GameObject[3];
    public GameObject[] needleBlues = new GameObject[3];

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Rotate(int color) {
        switch (color) {
            case 0:
                foreach(GameObject needleRed in needleReds) {
                    needleRed.GetComponent<BoardNeedle1>().Rotate();
                }
                break;
            case 1:
                foreach (GameObject needleGreen in needleGreens) {
                    needleGreen.GetComponent<BoardNeedle1>().Rotate();
                }
                break;
            case 2:
                foreach (GameObject needleBlue in needleBlues) {
                    needleBlue.GetComponent<BoardNeedle1>().Rotate();
                }
                break;
            default:
                Debug.Log("Error");
                break;
        }
    }
}
