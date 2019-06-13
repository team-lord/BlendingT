﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternB2 : MonoBehaviour
{
    private int previousPattern;
    private int currentPattern; // 중복 방지

    public float patternDelay;

    private bool patternStart;

    public GameObject[] patternMakers = new GameObject[9];
    public GameObject[] forgedPatternMakers = new GameObject[9]; // 0, 1, 4

    private int[] patternArray;

    private bool patternPhase;

    // Start is called before the first frame update
    void Start() {
        previousPattern = -1;
        currentPattern = -1;

        patternStart = true;

        patternArray = new int[] {0, 1, 4, 2, 6, 5, 8};

        patternPhase = true;
    }
    // Update is called once per frame
    void Update() {
        if (patternPhase) {
            if (patternStart) {
                patternStart = false;
                GetComponent<MoveB2>().IsMove(false);

                Pattern();
            }
        }
        
    }

    void Pattern() {
        int _number;

        do {
            _number = Random.Range(0, patternArray.Length);
        } while (patternArray[_number] == currentPattern);

        previousPattern = currentPattern;
        currentPattern = patternArray[_number];

        GetComponent<MakeBeeB2>().MakeBee();
        Instantiate(patternMakers[currentPattern], transform.position, transform.rotation);
        
    }

    public void PatternEnd() { // patternMaker가 이 함수를 호출
        StartCoroutine(PatternStart());
    }

    IEnumerator PatternStart() {
        GetComponent<MoveB2>().IsMove(true);
        yield return new WaitForSeconds(patternDelay);
        patternStart = true;
    }

    public void PatternForge(int number) {
        patternMakers[number] = forgedPatternMakers[number];
    }

    public void ForceStart() {
        StartCoroutine(Rest()); // 운이 안좋으면 벌이 네마리 나올 수도 있으므로 잠시 꺼준다
        previousPattern = currentPattern;
        patternStart = true;
    }

    IEnumerator Rest() {
        GetComponent<MakeBeeB2>().IsReady(false);
        yield return new WaitForSeconds(0.1f);
        GetComponent<MakeBeeB2>().IsReady(true);
    }

    public void PatternArray(int[] array) {
        patternArray = array;
    }

    public void PatternPhase(bool _bool) {
        patternPhase = _bool;
    }
}