using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towers : MonoBehaviour {
    public int[] status = new int[3]; // 0: exist, 1: isAttack, 2: destroyed
    public int number; // 3 -> 2 ->1

    public GameObject[] towersQ = new GameObject[3];

    private int towerMaxHealth;

    private float time;

    public float energyMinimumDelayQ;
    public float energyMaximumDelayQ;
    private float delay;
    private bool isDelayDetermined;

    public bool isDestroyed;

    private GameObject boss;

    // Start is called before the first frame update
    void Start() {
        for (int i = 0; i < 3; i++) {
            status[i] = 0;
        }

        int _first = Random.Range(0, 3);
        status[_first] = 1;
        towersQ[_first].GetComponent<Tower>().isAttack = true;
        // sprite 바꾸기

        number = 3;

        towerMaxHealth = towersQ[0].GetComponent<Tower>().maxHealthQ;

        time = 0;

        delay = 0;
        isDelayDetermined = false;

        isDestroyed = false;

        boss = GameObject.Find("Boss");
    }

    // Update is called once per frame
    void Update() {
        time += Time.deltaTime;

        CheckDestroyMoveEnergy();
        CheckMoveEnergy();
        
        
    }

    void TowerOn(int index) {
        status[index] = 1;
        towersQ[index].GetComponent<Tower>().isAttack = true;
        towersQ[index].GetComponent<SpriteRenderer>().sprite = towersQ[index].GetComponent<Tower>().TowerOnQ;
    }

    void TowerOff(int index) {
        status[index] = 0;
        towersQ[index].GetComponent<Tower>().isAttack = false;
        towersQ[index].GetComponent<SpriteRenderer>().sprite = towersQ[index].GetComponent<Tower>().TowerOff;
    }
    

    void CheckMoveEnergy() {
        if (!isDelayDetermined) {
            delay = Random.Range(energyMinimumDelayQ, energyMaximumDelayQ);
            isDelayDetermined = true;
        }
        if(time > delay) {
            MoveEnergy();
            time = 0;
            isDelayDetermined = false;
        }
    }

    void MoveEnergy() {
        if (number == 1) { // {2, 2, 1}
            return;
        } else if (number == 2) { // {2, 1, 0} -> {2, 0, 1}
            for (int i = 0; i < 3; i++) {
                if (status[i] == 0) {
                    TowerOn(i);
                } else if(status[i] == 1) {
                    TowerOff(i);
                }
                   
                
            }
        } else if (number == 3) { // {1, 0, 0} -> {0, 1, 0}
            int[] _number = new int[2];
            int _index = 0;
            for (int i = 0; i < 3; i++) {
                if (status[i] == 0) {
                    _number[_index] = i;
                    _index++;
                } else if (status[i] == 1) {
                    TowerOff(i);
                }
            }
            int _nextAttack = _number[Random.Range(0, 2)];
            TowerOn(_nextAttack);
            
        } else {
            Debug.Log("Error");
        }
    }

    void CheckDestroyMoveEnergy() {
        if (isDestroyed) {
            DestroyMoveEnergy();
            isDestroyed = false;

            isDelayDetermined = false;
            time = 0;
        }
    }

    void DestroyMoveEnergy() {
        if(number == 0) { // {2, 2, 2}
            boss.GetComponent<Boss2>().special2End = true;
        } else if(number == 1) { // {2, 2, 0} -> {2, 2, 1}
            for(int i=0; i<3; i++) {
                if (status[i] == 0) {
                    TowerOn(i);
                    
                    return;
                }
            }
        } else if (number == 2) { // {2, 0, 0} -> {2, 1, 0}
            int[] _number = new int[2];
            int _index = 0;
            for (int i = 0; i < 3; i++) {
                if (status[i] == 0) {
                    _number[_index] = i;
                    _index++;
                }
            }
            int _nextAttack = _number[Random.Range(0, 2)];

            TowerOn(_nextAttack);
            
        }
    }
}
