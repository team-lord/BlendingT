using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleFail1Move : MonoBehaviour
{
    private float time;

    public Vector3 direction;
    private Vector3 turnDirection;

    public float moveSpeed;
    public float moveAcceleration;

    public float delay1;
    private bool isTurn;
    public float delay2;
    private bool isAccelerate;
    private bool isTimeOn;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;

        TurnDirection();

        isTimeOn = true;

        isTurn = false;
        isAccelerate = false;
    }

    // Update is called once per frame
    void Update() {
        Move();

        if (isTimeOn) {
            time += Time.deltaTime;
            if (!isTurn) {
                if (time > delay1) {
                    isTurn = true;
                }
            }
            if (!isAccelerate) {
                if (time > delay1 + delay2) {
                    isAccelerate = true;
                    isTimeOn = false;
                }
            }
        }

        if (isTurn) {
            Turn();
        }
        if (isAccelerate) {
            Accelerate();
        }
    }

    void TurnDirection() {
        turnDirection = Quaternion.FromToRotation(Vector3.up, Vector3.right) * direction;
    }

    void Turn() {
        transform.Translate(turnDirection * moveSpeed / 2 * Time.deltaTime);   
    }

    void Move() {
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    void Accelerate() {
        moveSpeed += moveAcceleration;
    }
}
