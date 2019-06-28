﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhaseB2 : MonoBehaviour
{
    public GameObject blanket;
    
    public GameObject special1Maker;

    private GameObject player;

    Animator animator;

    public GameObject levitationCore;

    private void Awake()
    {
        transform.GetChild(1).gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Phase1() {
        GetComponent<PatternB2>().PatternArray(new int[] { 0, 1, 4, 2, 3, 7 });
        GetComponent<HealthB2>().Phase(1);
    }

    public void Phase2() {
        animator.SetBool("spin", false);

        StartCoroutine(Phase2CameraWalk());

        Instantiate(blanket, Vector3.zero, Quaternion.identity);

        GetComponent<PatternB2>().PatternPhase(false);

        GetComponent<MoveB2>().IsMove1(false);

        GetComponent<HealthB2>().Phase(2);

        animator.SetFloat("phase2Health", 3f);

        transform.GetChild(1).gameObject.SetActive(true);
    }

    IEnumerator Phase2CameraWalk() {
        Camera.main.GetComponent<CameraMove2>().WatchRight();
        yield return new WaitForSeconds(1f);
        Camera.main.GetComponent<CameraMove2>().WatchPlayerCenter();
    }

    public void Phase3() {
        GetComponent<PatternB2>().PatternPhase(true);
        GetComponent<PatternB2>().ForcePatternStart();
        GetComponent<MoveB2>().IsMove1(true);
        GetComponent<HealthB2>().Phase(3);

        GetComponent<PatternB2>().PatternForge(0);
        GetComponent<PatternB2>().PatternForge(1);

        GetComponent<MakeBeeB2>().IsReady(true);
        GetComponent<FireBulletB2>().IsReady(true);

        player.GetComponent<BlanketP2>().GetBlanket();
    }

    public void Phase4() {
        GetComponent<HealthB2>().Phase(4);
        GetComponent<PatternB2>().PatternForge(4);
        GetComponent<MakeBeeB2>().Forge();
    }

    public void Phase5() {

        Instantiate(blanket, Vector3.zero, Quaternion.identity);
        Camera.main.GetComponent<CameraMove2>().WatchPlayerCenter();

        GetComponent<MoveB2>().IsMove1(false);
        GetComponent<PatternB2>().PatternPhase(false);

        Instantiate(levitationCore, transform.position, Quaternion.identity);

        transform.position = new Vector3(64, 0, 0);


        // 데모 버젼 끝

        /*
        Instantiate(blanket, Vector3.zero, Quaternion.identity);

        GetComponent<HealthB2>().Phase(5);
        GetComponent<PatternB2>().PatternPhase(false);
        GetComponent<MoveB2>().IsMove(true);

        GetComponent<MakeBeeB2>().IsReady(false);
        GetComponent<FireBulletB2>().IsReady(false);
        // 필살기 2

        Instantiate(special1Maker, Vector3.zero, transform.rotation);

        */
    }

    public void Phase6() {
        GetComponent<HealthB2>().Phase(6);
        // TODO - 이벤트 씬
    }
}
