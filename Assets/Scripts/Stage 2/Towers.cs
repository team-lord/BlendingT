using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towers : MonoBehaviour {
    public bool[] isDestroyed = new bool[3];
    public int[] status = new int[3]; // 0: exist, 1: vulnerable, 2: destroyed
    private int currentAttack;
    public int number; // 3 -> 2 ->1

    public GameObject[] towersQ = new GameObject[3];

    private int towerMaxHealth;

    private float time;

    public float laserMinimumDelayQ;
    public float laserMaximumDelayQ;
    private float delay;
    private bool isDelayDetermined;

    // Start is called before the first frame update
    void Start() {
        for (int i = 0; i < 3; i++) {
            isDestroyed[i] = false;
            status[i] = 0;
        }

        currentAttack = Random.Range(0, 3);
        status[currentAttack] = 1;
        towersQ[currentAttack].GetComponent<Tower>().isAttack = true;

        number = 3;

        towerMaxHealth = towersQ[0].GetComponent<Tower>().maxHealthQ;

        time = 0;

        delay = 0;
        isDelayDetermined = false;
    }

    // Update is called once per frame
    void Update() {
        time += Time.deltaTime;

        CheckNumber();

    }
    
    void CheckNumber() {

        if (isDestroyed[currentAttack]) {
            status[currentAttack] = 2;
            for (int j = 0; j < 3; j++) {
                if (status[j] != 2) {
                    towersQ[j].GetComponent<Tower>().health = towerMaxHealth;
                }
            }
            MoveLaser();
        }

    }

    void ReadyMoveLaser() {
        if (!isDelayDetermined) {
            delay = Random.Range(laserMinimumDelayQ, laserMaximumDelayQ);
            isDelayDetermined = true;
        } else {
            if (time > delay) {
                MoveLaser();
                time = 0;
                isDelayDetermined = false;
            }
        }
    }

    void MoveLaser() {
        int _count = 0;
        for(int i=0; i<3; i++) {
            if (status[i] != 2) {
                _count++;
            }
        }
        if(_count == 1) {
            return;
        }

        if(_count <= 0) {

        }
    }
}
