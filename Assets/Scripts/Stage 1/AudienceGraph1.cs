using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceGraph1 : MonoBehaviour
{
    private int score;

    private bool isReady;

    // Start is called before the first frame update
    void Start()
    {
        score = 100;

        isReady = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isReady) {
            isReady = false;
            // score와 관계된 sprite/애니메이션 처리
        }
    }

    public void ScoreChange(int changedScore) {
        score = changedScore;
        isReady = true;
    }
}
