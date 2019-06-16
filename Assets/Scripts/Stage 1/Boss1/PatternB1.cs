using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternB1 : MonoBehaviour
{
    private bool isPatternPhase;

    private bool isPatternForged;

    private int previousPattern;
    private int currentPattern; // 중복 방지

    public float patternDelay;

    private bool patternStart;

    public GameObject[] patternMakers = new GameObject[8];
    public GameObject[] forgedPatternMakers = new GameObject[8];

    // Start is called before the first frame update
    void Start() {
        isPatternPhase = true;

        isPatternForged = false;

        previousPattern = -1;
        currentPattern = -1;

        patternStart = true;
    }
    // Update is called once per frame
    void Update() {
        if (isPatternPhase) {
            if (patternStart) {
                patternStart = false;
                GetComponent<MoveFireB1>().IsMove(false);

                Pattern();
            }
        }

    }

    public void IsPatternPhase(bool _bool) {
        isPatternPhase = _bool;
    }

    void Pattern() {
        /*
        int _number;
        do {
            _number = Random.Range(0, patternMakers.Length); // patternMakers.Length == 8
        } while (_number == currentPattern);

        previousPattern = currentPattern;
        currentPattern = _number;

        if (isPatternForged) {
            Instantiate(forgedPatternMakers[_number], transform.position, transform.rotation);
        } else {
            Instantiate(patternMakers[_number], transform.position, transform.rotation);
        }
        */
        Instantiate(patternMakers[0], transform.position, transform.rotation);

    }

    public void PatternEnd() { // patternMaker가 이 함수를 호출
        GetComponent<MoveFireB1>().IsMove(true);
        StartCoroutine(PatternStart());
    }

    IEnumerator PatternStart() {
        yield return new WaitForSeconds(patternDelay);
        patternStart = true;
    }

    public void PatternForge() {
        isPatternForged = true;
    }

    public void ForceStart() { // 강제로 패턴을 다시 시작할 때 호출 ex) surpriseBox가 아직 존재
        currentPattern = previousPattern;
        patternStart = true;
    }
}
