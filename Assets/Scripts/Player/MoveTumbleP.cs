﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTumbleP : MonoBehaviour
{
    // 이동
    public float moveSpeed;

    private float h;
    private float v;

    // 구르기
    private bool canTumble;
    public float tumbleTime;
    public float tumbleSpeed;
    public float tumbleDelay;
    private bool isTumbling;

    // 패턴 4
    private bool isPattern41;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate() {
        FixRotate();    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (canTumble) {
                if (h != 0 && v != 0) {
                    StartTumble();
                }
            }            
        }

        if (isTumbling) {
            Tumble();
        } else {
            Move();
        }
    }
    void FixRotate() {
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }    

    void StartTumble() {
        StartCoroutine(CanTumble());
        StartCoroutine(IsTumbling());

        // AudienceManager에게 굴렀다는 신호 보내기
        
        if (isPattern41) {
            GameObject[] bullet4s = GameObject.FindGameObjectsWithTag("Bullet41");
            if(bullet4s != null) {
                foreach(GameObject bullet4 in bullet4s) {
                    bullet4.GetComponent<Bullet4Move1>().IsClockWise();
                }
            }
        }
    }

    public void IsPattern41(bool _bool) {
        if (_bool) {
            isPattern41 = true;
        } else {
            isPattern41 = false;
        }
    }

    IEnumerator CanTumble() {
        canTumble = false;
        yield return new WaitForSeconds(tumbleTime + tumbleDelay);
        canTumble = true;
    }

    IEnumerator IsTumbling() {
        isTumbling = true;
        yield return new WaitForSeconds(tumbleTime);
        isTumbling = false;
    }

    void Tumble() {
        transform.Translate(h * Vector3.right * tumbleSpeed * Time.deltaTime, Space.World);
        transform.Translate(v * Vector3.up * tumbleSpeed * Time.deltaTime, Space.World);
    }

    void Move() {
        if (Input.GetAxis("Horizontal") > 0) {
            h = 1;
        } else if (Input.GetAxis("Horizontal") < 0) {
            h = -1;
        } else {
            h = 0;
        }        

        if (Input.GetAxis("Vertical") > 0) {
            v = 1;
        } else if (Input.GetAxis("Vertical") < 0) {
            v = -1;
        } else {
            v = 0;
        }

        Correction();

        transform.Translate(h * Vector3.right * moveSpeed * Time.deltaTime, Space.World);
        transform.Translate(v * Vector3.up * moveSpeed * Time.deltaTime, Space.World);
    }

    void Correction() {
        if(h != 0 && v != 0) {
            h *= 1 / Mathf.Sqrt(2);
            v *= 1 / Mathf.Sqrt(2);
        }
    }

    public Vector3 MoveDirection() { // 플레이어의 이동을 예측하는 패턴에서 호출
        return new Vector3(h, v, 0);
    }
}