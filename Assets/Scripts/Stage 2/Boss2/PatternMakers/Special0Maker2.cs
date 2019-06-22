using System.Collections;
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

        boss.GetComponent<JumpB2>().Jump();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (!isReady) {
            if (time > fallDelay) {
                boss.GetComponent<JumpB2>().Fall(new Vector3(0, 15, 0));
                
                isReady = true;
            }
        } else {
            // (대충 bee를 Instantiate하는 코드)
        }
        
        if (time > timeLimit) { // 시간 초과
            Instantiate(special0FailBullets, transform.position, transform.rotation);
            boss.GetComponent<PhaseB2>().Phase3();
            Destroy(gameObject);
        }
    }
}
