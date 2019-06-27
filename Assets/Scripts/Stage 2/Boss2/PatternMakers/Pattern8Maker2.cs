using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern8Maker2 : MonoBehaviour
{
    // TODO
    /* 플레이어가 보스와 일정거리를 유지하도록
        1. 날아올랐다가 낙하 +  전방위 탄막(플레이어가 일정거리 이상 멀어질 시) - 일반 탄알
        2. 찌르기나 회전 등으로 직접 공격(플레이어가 일정거리까지 접근할 시)
    */

    public int minimumRange;
    public int maximumRange;
    private bool isSweep; // true: sweep, false: fly

    public float sweepDelay; // 휩쓰는 애니메이션 시간
    
    public GameObject shadow;
    public float flyDelay; // 날아서 그림자가 보일때까지의 시간
    
    private float time;

    private GameObject player;
    private GameObject boss;

    // Start is called before the first frame update
    void Start()
    {
        isSweep = true;

        time = 0;

        player = GameObject.Find("Player");
        boss = GameObject.Find("Boss");

        CheckCase();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (isSweep) {
            if(time > sweepDelay) {
                CheckDestroy();
            }
        } else {
            if(time > flyDelay) {
                Instantiate(shadow, player.transform.position, transform.rotation);
                Destroy(); // PatternEnd는 Shadow가 호출
            }
        }
    }

    void CheckCase() {
        float _length = (player.transform.position - transform.position).magnitude;

        if (_length < minimumRange) {
            boss.GetComponent<SweepB2>().Sweep();
            isSweep = true;
        } else if (maximumRange < _length) {
            boss.GetComponent<JumpB2>().Jump();
            isSweep = false;
        } else {
            CheckForceDestroy();
        }
    }

    void Destroy() {
        Destroy(gameObject);
    }

    void CheckDestroy() {
        boss.GetComponent<PatternB2>().PatternEnd();
        Destroy(gameObject);
    }

    void CheckForceDestroy() {
        boss.GetComponent<PatternB2>().ForceStart();
        Destroy(gameObject);
    }
}
