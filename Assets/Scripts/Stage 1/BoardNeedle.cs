using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardNeedle : MonoBehaviour
{
    private bool isStraight; // true = Straight, false = Reversed
    public bool change;

    public float cooltimeQ; // cooltime < 1
    public float angularVelocityQ;

    private bool waitChange;

    private float originalZ;
    private float currentZ;

    private bool isIncreasing; // true = Increasing, false = Decreasing

    // Start is called before the first frame update
    void Start()
    {
        originalZ = transform.rotation.eulerAngles.z;
        CheckStraight();

        change = false;
        waitChange = true;

        CheckIncreasing();
    }

    void CheckStraight() {
        if (originalZ < 135) {
            isStraight = true;
        } else {
            isStraight = false;
        }
    }

    void CheckIncreasing() {
        if (isStraight) {
            if (originalZ < 45) { // originalZ = 20
                isIncreasing = true;
            } else { // originalZ = 70
                isIncreasing = false;
            }
        } else {
            if (originalZ < 225) { // originalZ = 200
                isIncreasing = true;
            } else { // originalZ = 250
                isIncreasing = false;
            }
        }
    }

    // Update is called once per frame
    void Update() {
        if (change) {
            if (waitChange) {
                StartCoroutine(Wait(cooltimeQ));
            }

            currentZ = transform.rotation.eulerAngles.z;

            if (isStraight) {
                if (isIncreasing) {
                    if (currentZ < 70) {
                        currentZ += angularVelocityQ * Time.deltaTime;
                    }
                    if (currentZ > 70) {
                        Correction(70);
                    }
                } else {
                    if (currentZ > 20) {
                        currentZ -= angularVelocityQ * Time.deltaTime;
                    }
                    if (currentZ < 20) {
                        Correction(20);
                    }
                }
            } else {
                if (isIncreasing) {
                    if (currentZ < 250) {
                        currentZ += angularVelocityQ * Time.deltaTime;
                    }
                    if (currentZ > 250) {
                        Correction(250);
                    }
                } else {
                    if (currentZ > 200) {
                        currentZ -= angularVelocityQ * Time.deltaTime;
                    }
                    if (currentZ < 200) {
                        Correction(200);
                    }
                }
            }

            transform.rotation = Quaternion.Euler(new Vector3(0, 0, currentZ));
        }
    }

    void Correction(int limit) {
        currentZ = limit;
        waitChange = true;
        change = false;
    }


    IEnumerator Wait(float time) {
        waitChange = false;
        yield return new WaitForSeconds(time);
        isIncreasing = !isIncreasing;
        waitChange = true;
        change = false;
    }
}
