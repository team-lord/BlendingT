using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Towers2 : MonoBehaviour
{
    public GameObject[] towers = new GameObject[3];
    private int[] towersStatus = new int[3]; // 0: isAttack = false, 1: isAttack = true, 2: Destroyed

    private int number;

    private float time;
    public float moveLaserDelay;

    private GameObject boss;

    // Start is called before the first frame update
    void Start()
    {
        number = 3;

        for(int i=0; i<towersStatus.Length; i++) {
            towersStatus[i] = 0;
        }
        int _random = Random.Range(0, 3);
        towersStatus[_random] = 1;
        towers[_random].GetComponent<Tower2>().IsAttack(true, number);

        time = 0;

        boss = GameObject.Find("Boss");
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;      
        if(time > moveLaserDelay) {
            MoveLaser();
        }
    }

    void MoveLaser() {
        int _currentIndex = -1;
        int _targetIndex = -1;
        switch (number) {
            case 3:
                for (int i = 0; i < towersStatus.Length; i++) {
                    if (towersStatus[i] == 1) {
                        _currentIndex = i;
                    }
                    do {
                        _targetIndex = Random.Range(0, 3);
                    } while (_targetIndex == _currentIndex);
                }
                break;
            case 2:                
                for(int i=0; i<towersStatus.Length; i++) {
                    if (towersStatus[i] == 1) {
                        _currentIndex = i;
                    } else if (towersStatus [i] == 0) {
                        _targetIndex = i;
                    }
                }
                break;
            case 1:
                // 아무것도 안함
                break;
            default:
                Debug.Log("Error");
                break;
        }
        towers[_currentIndex].GetComponent<Tower2>().IsAttack(false, number);
        towers[_targetIndex].GetComponent<Tower2>().IsAttack(true, number);

    }

    public void Destroy(int index) {
        int _targetIndex = -1;
        number--;
        towersStatus[index] = 2;
        time = 0;
        switch (number) {
            case 2:
                do {
                    _targetIndex = Random.Range(0, 3);
                } while (towersStatus[_targetIndex] == 2);
                break;
            case 1:
                for (int i = 0; i < towersStatus.Length; i++) {
                    if (towersStatus[i] == 0) {
                        _targetIndex = i;
                    }
                }
                break;
            case 0:
                boss.GetComponent<PhaseB2>().Phase6();
                Destroy(gameObject);
                break;
            default:
                Debug.Log("Error");
                break;
        }
        towers[_targetIndex].GetComponent<Tower2>().IsAttack(true, number);        
    }
}
