using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankMachineMotorFan1 : MonoBehaviour
{
    private GameObject puzzleBall;

    private GameObject motorFan;
    private bool isMotorFanOn;

    private GameObject plankMachine;
    private int plank;

    // Start is called before the first frame update
    void Start()
    {
        puzzleBall = GameObject.Find("2ndPuzzleBall");

        motorFan = GameObject.Find("MotorFan");
        plankMachine = GameObject.Find("PlankMachine");

        isMotorFanOn = true;
        plank = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "PuzzleBall") {
            // isMotorFanOn = motorFan.GetComponent<MotorFan1>().IsMotorFanOn();
            if (!isMotorFanOn) {
                puzzleBall.GetComponent<PuzzleBallMove1>().PuzzleFail();
            }    
            plank = plankMachine.GetComponent<PlankMachine1>().CurrentPlank();

            switch (plank) {
                case 0:
                    puzzleBall.GetComponent<Rigidbody2D>().AddForce(50 * Vector3.left);
                    break;
                case 1:
                    puzzleBall.GetComponent<Rigidbody2D>().AddForce(150 * Vector3.left);
                    break;
                case 2:
                    puzzleBall.GetComponent<Rigidbody2D>().AddForce(300 * Vector3.left);
                    break;
                default:
                    Debug.Log("Error");
                    break;
            }

            Destroy(gameObject);
        }
    }
}
