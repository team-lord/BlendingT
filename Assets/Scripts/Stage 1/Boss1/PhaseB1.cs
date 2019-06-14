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
        GetComponent<MoveFireB1>().IsMove(false); // 이딴식 안됨!!! TODO - 고치기
        GetComponent<PatternB1>().IsPatternPhase(false);
        GetComponent<PuzzleB1>().IsPuzzlePhase(true);
    }

    public void Phase2() {
        // TODO - 패턴이 끝났을 때 나오는 애니메이션들
        // TODO - 보스가 맵 중앙으로 떨어져서 나타남
        GetComponent<MoveFireB1>().IsMove(true);
        GetComponent<PatternB1>().IsPatternPhase(true);
        GetComponent<PuzzleB1>().IsPuzzlePhase(false);
        GetComponent<PatternB1>().PatternForge();
    }

    public void Phase3() {
        // TODO - 이벤트 씬
    }
}
