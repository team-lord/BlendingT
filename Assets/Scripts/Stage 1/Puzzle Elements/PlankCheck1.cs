using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankCheck1 : MonoBehaviour
{
    private GameObject puzzleBall;
    private GameObject plankMachine;

    // Start is called before the first frame update
    void Start()
    {
        puzzleBall = GameObject.Find("2ndPuzzleBall");
        plankMachine = GameObject.Find("PlankMachine");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "PuzzleBall") {
            if(plankMachine.GetComponent<PlankMachine1>().CurrentPlank() != 2) {
                puzzleBall.GetComponent<PuzzleBallMove1>().PuzzleFail();
            }
        }
    }
}
