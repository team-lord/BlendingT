﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternB2 : MonoBehaviour
{
    private int previousPattern;
    private int currentPattern; // 중복 방지

    public float patternDelay;
    public int debugPattern;

    private bool patternStart;

    public GameObject[] patternMakers = new GameObject[9];
    public GameObject[] forgedPatternMakers = new GameObject[9]; // 0, 1, 4

    private int[] patternArray;

    private bool patternPhase;

    Animator animator;

    // Start is called before the first frame update
    void Start() {
        previousPattern = -1;
        currentPattern = -1;

        patternStart = true;

        patternArray = new int[] {0, 2};

        patternPhase = true;

        animator = GetComponent<Animator>();
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
        
        //Instantiate(patternMakers[debugPattern], transform.position, transform.rotation);
    }

    public void PatternEnd() { // patternMaker가 이 함수를 호출
        StartCoroutine(PatternStart());
    }

    IEnumerator PatternStart() {
        GetComponent<MoveB2>().IsMove(true);
        yield return new WaitForSeconds(patternDelay);
        patternStart = true;
    }

    public void ForcePatternStart()
    {
        patternStart = true;
    }

    public void PatternForge(int number) {
        patternMakers[number] = forgedPatternMakers[number];
    }

    private bool forceStartIsReady = true;

    public void ForceStart() {
        if (forceStartIsReady) {
            StartCoroutine(ForceStartIsReady());
            previousPattern = currentPattern;
            animator.SetBool("spin", false);
            animator.SetTrigger("attackedByBlanket");
            PatternEnd();
        }
    }

    IEnumerator ForceStartIsReady()
    {
        forceStartIsReady = false;
        yield return new WaitForSeconds(5f);
        forceStartIsReady = true;
    }

    public void PatternArray(int[] array) {
        patternArray = array;
    }

    public void PatternPhase(bool _bool) {
        patternPhase = _bool;
    }
}
