using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    // Main Ball
    public GameObject ballQ;

    // Bulb
    public bool isBulbOn;

    // Phonograph
    public int phonographNumber; // answer = 3

    // Fan
    public bool isMotorFanOn;

    // PlankMachine
    public int plankNumber; // 1: Rubber, 2: Wood, 3: Ice, answer = 20

    public bool onPuzzle;

    // Start is called before the first frame update
    void Start()
    {
        isBulbOn = false;

        phonographNumber = 0;

        isMotorFanOn = false;

        plankNumber = 1;

        onPuzzle = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (onPuzzle) {
            ballQ.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
}
