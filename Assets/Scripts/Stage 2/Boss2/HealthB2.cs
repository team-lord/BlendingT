﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthB2 : MonoBehaviour {
    private int phase;

    public int[] phaseMaxHealths = new int[7];
    private int[] phaseHealths = new int[7];

    // Start is called before the first frame update
    void Start() {
        phase = 0;

        for (int i = 0; i < phaseHealths.Length; i++) {
            phaseHealths[i] = phaseMaxHealths[i];
        }
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (phase == 0) {
            if (collision.tag == "PlayerBullet") {
                phaseHealths[0]--;
                CheckAlive();
            } else if (collision.tag == "PlayerMelee") {
                // phaseHealths[0] -= 2;
                CheckAlive();
            }
        } else if (phase == 1) {
            if (collision.tag == "PlayerBullet") {
                phaseHealths[1]--;
                CheckAlive();
            } else if (collision.tag == "PlayerMelee") {
                // phaseHealths[1] -= 2;
                CheckAlive();
            }
        } else if (phase == 2) {
            if (collision.tag == "PlayerBulletHoney") { // PlayerBulletHoney 확인할 것

                phaseHealths[0]--;
                CheckAlive();
            }
        } else if (phase == 3) {
            if (collision.tag == "PlayerBullet") {
                phaseHealths[3]--;
                CheckAlive();
            } else if (collision.tag == "PlayerMelee") {
                // phaseHealths[3] -= 2;
                CheckAlive();
            }
        } else if (phase == 4) {
            if (collision.tag == "PlayerBullet") {
                phaseHealths[4]--;
                CheckAlive();
            } else if (collision.tag == "PlayerMelee") {
                // phaseHealths[4] -= 2;
                CheckAlive();
            }
        } else if (phase == 5) {
            // 보스 위로 올라가 있어서 때릴 수 없음
        } else if (phase == 6) {
            // TODO - 이벤트 씬. 피격시 사망. 시간이 흐를시 자비.
        }
    }

    void CheckAlive() {
        if (phase == 0) {
            if (phaseHealths[0] <= 0) {
                phaseHealths[0] = 0;
                GetComponent<PhaseB2>().Phase1();
            }
        } else if (phase == 1) {
            if (phaseHealths[1] <= 0) {
                phaseHealths[1] = 0;
                GetComponent<PhaseB2>().Phase2();
            }
        } else if (phase == 2) {
            if (phaseHealths[2] <= 0) {
                phaseHealths[2] = 0;
                Destroy(GameObject.Find("Special0Maker2"));
                GetComponent<PhaseB2>().Phase3();
            }
        } else if (phase == 3) {
            if (phaseHealths[3] <= 0) {
                phaseHealths[3] = 0;
                GetComponent<PhaseB2>().Phase4();
            }
        } else if (phase == 4) {
            if (phaseHealths[4] <= 0) {
                phaseHealths[4] = 0;
                GetComponent<PhaseB2>().Phase5();
            }
        } else if (phase == 5) {
            if (phaseHealths[5] <= 0) {
                phaseHealths[5] = 0;
                GetComponent<PhaseB2>().Phase6();
            }
        } else if (phase == 6) {

        }
    }

    public void Phase(int i) {
        phase = i;
    }
}