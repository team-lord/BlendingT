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
    public bool isPhonographOn;

    // Fan
    public bool isMotorFanOn;

    // PlankMachine
    public int plankNumber; // 1: Rubber, 2: Wood, 3: Ice, answer = 2

    public bool onPuzzle;

    // Start is called before the first frame update
    void Start()
    { // 퍼즐 요소들이 보내주나?
        isBulbOn = false;

        phonographNumber = 0;
        isPhonographOn = false;

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

        // 공이 당구대 앞을 통과하면 당구대의 공들의 gravityScale을 다 1로 바꿔줘야 합니다
    }
}
