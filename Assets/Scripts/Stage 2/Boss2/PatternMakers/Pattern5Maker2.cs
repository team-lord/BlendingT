using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern5Maker2 : MonoBehaviour
{
    // TODO - 바닥패턴
    // 시간을 두고 위험 지역과 안전 지역을 알려줌 (네크로댄서)

    /* 이건 맵이랑 다 나와야 할 수 있을 듯
     * 정확히 어떤 식으로 하는지도 아직 안정해졌고
     */

    private GameObject boss;

    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.Find("Boss");

        CheckAlive();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckAlive() {
        boss.GetComponent<PatternB2>().PatternEnd();
        Destroy(gameObject);
    }
}
