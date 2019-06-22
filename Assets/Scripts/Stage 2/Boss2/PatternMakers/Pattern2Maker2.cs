using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern2Maker2 : MonoBehaviour
{
    public GameObject bullet2; // bulletMine

    public float delay; // 올라가서 떨어질 때까지의 Delay
    public float fallDelay; // 떨어지기 시작해서 지면에 닿을 때까지의 Delay: 즉 떨어지는 애니메이션에 걸리는 시간
    private float time;

    private GameObject player;
    private GameObject boss;

    private bool isReady;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;

        player = GameObject.Find("Player");
        boss = GameObject.Find("Boss");

        CheckCase();

        isReady = false;

        boss.GetComponent<MoveB2>().IsMove(false);
        // 보스가 뛰어오르는 애니메이션
        boss.GetComponent<JumpB2>().Jump();
    }

    void CheckCase() {
        if (GameObject.FindGameObjectsWithTag("EnemyBulletMine").Length != 0) {
            CheckForceDestroy();
        }
    }

    void CheckForceDestroy() {
        boss.GetComponent<PatternB2>().ForceStart();
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (!isReady) {
            if (time > delay) {
                // 보스가 떨어지는 애니메이션
                boss.GetComponent<JumpB2>().Fall(Vector3.zero);
                isReady = true;
                time = 0;
            }
        } else {
            if (time > fallDelay)
            {
                for (int i = 0; i < 6; i++)
                {
                    Fire(60 * i);
                }
                CheckDestroy();
            }            
        }        
    }

    void Fire(int degree) {
        Instantiate(bullet2, transform.position, Quaternion.Euler(new Vector3(0, 0, degree)));
    }

    void CheckDestroy() {
        boss.GetComponent<PatternB2>().PatternEnd();
        Destroy(gameObject);
    }
}
