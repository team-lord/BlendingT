using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern2Maker2 : MonoBehaviour
{
    public GameObject bullet2; // bulletMine

    public float throwDelay; // throw 애니메이션 재생시간 
    public float ballFallDelay; // 공이 떨어지는데 걸리는 시간
    private float time;

    private GameObject player;
    private GameObject boss;
    public GameObject ball;

    private bool isReady;
    private bool isReady2;

    private bool checkCase;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;

        player = GameObject.Find("Player");
        boss = GameObject.Find("Boss");

        checkCase = GameObject.FindGameObjectsWithTag("EnemyBulletMine").Length != 0;
        if (checkCase)
        {
            CheckForceDestroy();
            return;
        }        

        isReady = false;
        isReady2 = true;

        boss.GetComponent<MoveB2>().IsMove(false);
        boss.GetComponent<Animator>().SetTrigger("throw");
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
            if (isReady2) {
                if (time > throwDelay) {
                    Instantiate(ball,new Vector3 (0,0,0), ball.transform.rotation);
                    isReady2 = false;
                    boss.GetComponent<MoveB2>().IsMove(true);
                    isReady = true;
                    time = 0;
                }
            }            
        } else {//throw가 끝난 후 
            if (time > ballFallDelay)
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
        Instantiate(bullet2, Vector3.zero, Quaternion.Euler(new Vector3(0, 0, degree)));
    }

    void CheckDestroy() {
        boss.GetComponent<PatternB2>().PatternEnd();
        Destroy(gameObject);
    }
}
