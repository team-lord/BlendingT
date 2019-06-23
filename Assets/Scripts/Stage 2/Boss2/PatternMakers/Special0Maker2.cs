﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special0Maker2 : MonoBehaviour
{
    private GameObject boss;

    public GameObject bee;

    public float fallDelay;
    private bool isReady;
    private float time;

    public float timeLimit;

    public GameObject special0FailBullets;

    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.Find("Boss");

        isReady = false;
        time = 0;

        for(int i=0; i<6; i++) {
            MakeBee(60 * i);
        }

        StartCoroutine(JumpFall());
    }

    void MakeBee(int degree) {
        Instantiate(bee, boss.transform.position, Quaternion.Euler(new Vector3(0, 0, degree)));
    }

    IEnumerator JumpFall() {
        boss.GetComponent<JumpB2>().Jump();
        yield return new WaitForSeconds(fallDelay);
        boss.GetComponent<JumpB2>().Special0Fall(new Vector3(0, 20, 0));
        yield return new WaitForSeconds(2f);
        boss.GetComponent<Animator>().SetTrigger("special0"); // 수정 가능성 있음
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        
        if (time > timeLimit) { // 시간 초과
            time = 0;
            Instantiate(special0FailBullets, transform.position, transform.rotation);
            boss.GetComponent<Animator>().SetTrigger("special0Fire");
            boss.GetComponent<PhaseB2>().Phase3();
            Destroy(gameObject);
        }
    }
}
