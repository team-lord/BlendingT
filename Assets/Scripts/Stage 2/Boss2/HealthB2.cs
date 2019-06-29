using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthB2 : MonoBehaviour {

    private int phase;

    public int[] phaseMaxHealths = new int[7];
    private int[] phaseHealths = new int[7];

    public float phase2MesTime;

    private bool isReady;

    public Text health;

    Animator animator;

    // Start is called before the first frame update
    void Start() {
        phase = 0;

        for (int i = 0; i < phaseHealths.Length; i++) {
            phaseHealths[i] = phaseMaxHealths[i];
        }

        isReady = true;

        animator = GetComponent<Animator>();

        health.text = (phaseHealths[0] + phaseHealths[1]).ToString();
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
                phaseHealths[0] -= 2;
                CheckAlive();
            }
        } else if (phase == 1) {
            if (collision.tag == "PlayerBullet") {
                phaseHealths[1]--;
                CheckAlive();
            } else if (collision.tag == "PlayerMelee") {
                phaseHealths[1] -= 2;
                CheckAlive();
            }
        } else if (phase == 2) {
            if (isReady) {
                if (collision.tag == "PlayerBulletHoney") {
                    phaseHealths[2]--;
                    CheckAlive();
                }
            }            
        } else if (phase == 3) {
            if (collision.tag == "PlayerBullet") {
                phaseHealths[3]--;
                CheckAlive();
            } else if (collision.tag == "PlayerMelee") {
                phaseHealths[3] -= 2;
                CheckAlive();
            }
        } else if (phase == 4) {
            if (collision.tag == "PlayerBullet") {
                phaseHealths[4]--;
                CheckAlive();
            } else if (collision.tag == "PlayerMelee") {
                phaseHealths[4] -= 2;
                CheckAlive();
            }
        } else if (phase == 5) {
            // 보스 위로 올라가 있어서 때릴 수 없음
        } else if (phase == 6) {
            // TODO - 이벤트 씬. 피격시 사망. 시간이 흐를시 자비.
        }

        if (collision.tag == "PlayerBullet" || collision.tag == "PlayerBulletHoney") {
            Destroy(collision.gameObject);
        }
    }

    void CheckAlive() {
        if (phase == 0) {
            ChangeHeart01();
            if (phaseHealths[0] <= 0) {
                GetComponent<PhaseB2>().Phase1();
            }
        } else if (phase == 1) {
            ChangeHeart01();
            if (phaseHealths[1] <= 0) {
                phaseHealths[1] = 0;
                health.text = phaseHealths[2].ToString();
                GetComponent<PatternB2>().PatternEnd();
                Destroy(GameObject.FindGameObjectWithTag("PatternMaker"));
                GetComponent<PhaseB2>().Phase2();

            }
        } else if (phase == 2) {
            animator.SetFloat("phase2Health", phaseHealths[2]);
            ChangeHeart2();
            if (phaseHealths[2] <= 0) {
                phaseHealths[2] = 0;
                GameObject.FindGameObjectWithTag("PatternMaker").GetComponent<Special0Maker2>().FireSpecialBullet(true);
                StartCoroutine(Phase2Mes());
                Destroy(GameObject.FindGameObjectWithTag("PatternMaker"));
                health.text = (phaseHealths[3]+phaseHealths[4]).ToString();
            }
        } else if (phase == 3) {
            ChangeHeart34();
            if (phaseHealths[3] <= 0) {
                GetComponent<PhaseB2>().Phase4();
            }
        } else if (phase == 4) {
            ChangeHeart34();
            if (phaseHealths[4] <= 0) {
                phaseHealths[4] = 0;
                GetComponent<PatternB2>().PatternEnd();
                Destroy(GameObject.FindGameObjectWithTag("PatternMaker"));
                GetComponent<PhaseB2>().Phase5();
            }
        } else if (phase == 5) {
            if (phaseHealths[5] <= 0) {
                phaseHealths[5] = 0;
                GetComponent<PhaseB2>().Phase6();
                Destroy(GameObject.FindGameObjectWithTag("PatternMaker"));

            }
        } else if (phase == 6) {

        }
    }

    IEnumerator Phase2Mes() {
        isReady = false;
        yield return new WaitForSeconds(2.85f);
        animator.SetTrigger("mes");
        GetComponent<MesHealthB2>().IsMes(true);
        yield return new WaitForSeconds(phase2MesTime);
        isReady = true;
        animator.SetTrigger("idle");
        GetComponent<MesHealthB2>().IsMes(false);
        GetComponent<PhaseB2>().Phase3();
    }

    public void Phase(int i) {
        phase = i;
    }

    void ChangeHeart01() {
        health.text = (phaseHealths[0]+phaseHealths[1]).ToString();
    }

    void ChangeHeart2() {
        health.text = phaseHealths[2].ToString();
    }

    void ChangeHeart34() {
        health.text = (phaseHealths[3] + phaseHealths[4]).ToString();
    }

    public void Phase3MesHealth(int damage) {
        phaseHealths[3] -= damage;
        ChangeHeart34();
    }
}
