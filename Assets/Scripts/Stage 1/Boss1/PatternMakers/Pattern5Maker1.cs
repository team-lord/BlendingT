using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern5Maker1 : MonoBehaviour
{
    public GameObject laser;
    public float delay; // 마술봉을 뒤로 당긴 후 레이저를 날릴때까지의 Delay
    public GameObject echo;
    public float echoDelay;

    private GameObject player;
    private GameObject boss;

    private float time;

    private bool isReady;

    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        boss = GameObject.Find("Boss");

        time = 0;
        isReady = false;

        // 마술봉을 뒤로 당겼다가 앞으로 뻗는 애니메이션 시작
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
       
        if (!isReady) {
            if (time > delay) {
                // 마술봉을 뒤로 당겼다가 앞으로 뻗는 애니메이션 끝
                direction = (player.transform.position - transform.position).normalized;
                Instantiate(laser, transform.position, Quaternion.FromToRotation(Vector3.up, direction));
                isReady = true;
                time = 0;
            }
        } else {
            if(time > echoDelay) {
                Instantiate(echo, transform.position, Quaternion.FromToRotation(Vector3.up, direction));
                boss.GetComponent<PatternB1>().PatternEnd();
                Destroy(gameObject);
            }
        }

        
    }
}
