using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern6Maker2 : MonoBehaviour
{
    // TODO - 찌르기 공격
    /* 돌진 후 독침으로 찌르기 + 추가공격(독침이 빛나는 방향을 통해 공격 방향에 대한 힌트 제공)
        1. 찌르기를 회피하기 위해 구르기를 사용해야 한다.
        2. 이 때 추가공격의 방향을 고려하여 방향을 정해야한다. 
            a. 앞으로 찌르기 - 좌우로 회피 : 0
            b. 회전 - 뒤로 회피 : 1
    */

    public float life; // 대충 애니메이션 재생 길이

    private GameObject boss;
    private GameObject player;

    private Vector2 direction; // 플레이어 방향

    // Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitCheckAlive());

        boss = GameObject.Find("Boss");
        player = GameObject.Find("Player");

        // animator = GetComponent<Animator>();

        /* 첫번째는 찌르기 공격이고 그게 끝나면 앞으로 찌르거나 회전해서 공격하는 추가 공격이 있거든
         * extraAttack이 0이면 앞으로 찌르고 1이면 회전 공격이야
         * 1D blendTree 만들어서 extraAttack 미리 setFloat 해두고 trigger하면 될것 같아
         * 첫 공격은 끝나면 바로 다음 애니메이션으로 넘어가게 하고 추가 공격도 끝나면 Idle로 가면 될듯
         * LookPlayer() 만들었으니 2D blendTree로 활용할 수 있을거야
         */

        // 만약 추가 공격때 플레이어 위치를 다시 보고 싶다면 첫번째 공격 애니메이션 재생 길이를 알려줘 그럼 수정할께

        int extraAttack = Random.Range(0, 2);

        // animator.setFloat("extra", extraAttack);
        // animator.setTrigger("~~");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitCheckAlive() {
        yield return new WaitForSeconds(life);
        CheckAlive();
    }

    void CheckAlive() {
        boss.GetComponent<PatternB2>().PatternEnd();
        Destroy(gameObject);
    }

    void LookRotation() {
        direction = (player.transform.position - transform.position).normalized;
    }
}
