﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceManager : MonoBehaviour
{
    // TODO - 관객의 환호도를 결정하는 스크립트

    /*
    관객의 환호도가 (UI 혹은 맵 내의 전광판에) 표시되며, 이는 보스전에 영향을 전혀 미치지 않는다. - 즉,‘도전과제’용 + 재미
    처음은 Boring에서 시작
    피격시 상승, 2 Phase 퍼즐 성공시 크게 상승, 패턴을 ‘아름답게(No bombs, no hits)’ 피할 시 상승 
    벽에 부딪혔을 시 하락, 공포탄을 사용할 시 하락, 2 Phase에서 조금씩 계속 하락. 최하는 Rubbish. -> 도전과제 ‘Rubbish’
    2 Phase 퍼즐 성공시 상승하는 환호도는 Exciting을 뚫을 수 있음(그 외는 Exciting이 최대).
    즉, 환호도가 높은 상태에서 2 Phase 퍼즐을 성공했다면 Exciting 뒤의 숨겨진 Masterpiece를 달성 가능 -> 도전과제 ‘Masterpiece’
    */

    private GameObject player;
    private GameObject boss;

    public GameObject audienceGraph;

    private int score;

    public int playerHitScore;
    public int puzzleCompleteScore;
    public int beautifulPatternScore;
    public float beaultifulPatternDelay; // PatternMaker가 등장한 이후로 이 시간동안 구르지도, 맞지도 않아야 함;
    private bool isBeautiful;
    private float time;

    public int wallHitScore;
    public int blanketScore;
    public int puzzlePhaseScore;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        boss = GameObject.Find("Boss");

        audienceGraph = GameObject.Find("AudienceGraph");

        score = 100;

        time = 0;
        isBeautiful = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isBeautiful) {
            time += Time.deltaTime;
            if(time > beaultifulPatternDelay) {
                isBeautiful = false;
                time = 0;
                BeautifulPattern();
            }
        }
    }

    public void PatternStart() {
        isBeautiful = true;
        time = 0;
    }

    public void Tumble() {
        isBeautiful = false;
        time = 0;
    }

    public void PlayerHit() {
        // 관객들의 환호성
        if (score <= 300) {
            score += playerHitScore;
            CorrectionExciting();
            ScoreChange();
        }
    }

    public void PuzzleComplete() {
        // 관객들의 엄청나게 큰 환호성
        score += puzzleCompleteScore;
        CorrectionMasterpiece();
        ScoreChange();
    }

    void BeautifulPattern() {
        // 관객들의 환호성
        if (score <= 300) {
            score += beautifulPatternScore; // TODO // 여기서 처리
            CorrectionExciting();
            ScoreChange();
        }
    }


    public void WallHit() {
        // 관객들의 야유 효과음
        score -= wallHitScore;
        CorrectionRubbish();
        ScoreChange();
    }

    public void Blanket() {
        score -= blanketScore;
        CorrectionRubbish();
        ScoreChange();
    }

    public void PuzzlePhase() {
        score -= puzzlePhaseScore;
        CorrectionRubbish();
        ScoreChange();
    }

    void ScoreChange() {
        audienceGraph.GetComponent<AudienceGraph>().ScoreChange(score);
        // TODO - 자식 audience 들에게 ScoreChange 해주기
    }

    void CorrectionRubbish() {
        if(score < 0) {
            score = 0;
        }
    }

    void CorrectionExciting() {
        if(score > 300) {
            score = 300;
        }
    }

    void CorrectionMasterpiece() {
        if(score > 400) {
            score = 400;
        }
    }
}