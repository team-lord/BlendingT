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

    public int debugPattern;

    public GameObject[] patternMakers = new GameObject[8];
    public GameObject[] forgedPatternMakers = new GameObject[8];

    private int[] patternArray;

    Animator animator;

    private int _number;

    // Start is called before the first frame update
    void Start() {
        isPatternPhase = true;

        isPatternForged = false;

        previousPattern = -1;
        currentPattern = -1;

        patternStart = true;

        patternArray = new int[] { 0, 1, 2, 3, 4, 7 };

        animator = GetComponent<Animator>();
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
        
        
        do {
            _number = Random.Range(0, patternArray.Length); 
        } while (patternArray[_number] == currentPattern);

        previousPattern = currentPattern;
        currentPattern = patternArray[_number];

        if (isPatternForged) {
            Debug.Log("PatternMaker_Instantiate");
            Instantiate(forgedPatternMakers[currentPattern], transform.position, transform.rotation);
        } else {
            Debug.Log("PatternMaker_Instantiate");
            Instantiate(patternMakers[currentPattern], transform.position, transform.rotation);
        }
        
        //Instantiate(forgedPatternMakers[debugPattern], transform.position, transform.rotation);

    }

    public void PatternEnd() { // patternMaker가 이 함수를 호출
        if(_number == 0) //보스의 cardFire애니메이션이 자연스럽지 못해서 만들어놓음 문제있으면 자세한건 이재상한테 물어보셈
        {
            StartCoroutine(ForCardFireSmooth());
        }
        else
        {
            GetComponent<MoveFireB1>().IsMove(true);
            StartCoroutine(PatternStart());
        }
        
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
    IEnumerator ForCardFireSmooth() //보스의 cardFire애니메이션이 자연스럽지 못해서 만들어놓음 문제있으면 자세한건 이재상한테 물어보셈
    {
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("cardFire", false);
        GetComponent<MoveFireB1>().IsMove(true);
        StartCoroutine(PatternStart());
    }
}
