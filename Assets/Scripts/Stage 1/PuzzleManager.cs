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
    public GameObject phonograph;
    private int phonographNumber; // answer = 2
    private bool isPhonographOn;

    // Fan
    public bool isMotorFanOn;

    // PlankMachine
    public GameObject plankMachine;
    public int plankNumber; // 0: Rubber, 1: Wood, 2: Ice, answer = 1

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
        /*
        if (onPuzzle) {
            ballQ.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
        */

        // 공이 당구대 앞을 통과하면 당구대의 공들의 gravityScale을 다 1로 바꿔줘야 합니다
        // 아무튼 어떻게 할지 잘 모르겠음
    }

    public void Ready() {

        plankNumber = plankMachine.GetComponent<PlankMachine>().CurrentPlank(); // 요딴 식으로 합시다
        phonographNumber = phonograph.GetComponent<Phonograph>().CurrentButton();
        if(phonographNumber >= 0) { // -1 means isPhonographOn = false;
            isPhonographOn = true;
        }

        onPuzzle = true;

    }
}
