using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseB1 : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Phase1() {
        // TODO - 보스가 폴짝 뒤며 사라짐
        // TODO - Puzzle Elements가 나타남
        GetComponent<MoveB1>().enabled = false;
        GetComponent<PatternB1>().enabled = false;
        GetComponent<PuzzleB1>().enabled = true;
    }

    public void Phase2() {
        // TODO - 패턴이 끝났을 때 나오는 애니메이션들
        // TODO - 보스가 맵 중앙으로 떨어져서 나타남
        GetComponent<MoveB1>().enabled = true;
        GetComponent<PatternB1>().enabled = true;
        GetComponent<PuzzleB1>().enabled = false;
        GetComponent<PatternB1>().PatternForge(); 
    }
}
