using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern5Maker : MonoBehaviour
{
    public GameObject laser;
    public float delay; // 마술봉을 뒤로 당긴 후 레이저를 날릴때까지의 Delay

    private GameObject player;
    private GameObject boss;

    private float time;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        boss = GameObject.Find("Boss");

        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        // 마술봉을 뒤로 당겼다가 앞으로 뻗는 애니메이션

        if(time > delay) {
            Vector3 _direction = (player.transform.position - transform.position).normalized;
            Instantiate(laser, transform.position, Quaternion.LookRotation(_direction));
            boss.GetComponent<PatternB1>().PatternEnd();
            Destroy(gameObject);
        }
    }
}
