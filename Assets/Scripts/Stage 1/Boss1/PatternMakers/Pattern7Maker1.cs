using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern7Maker1 : MonoBehaviour {
    public GameObject[] waveMakers = new GameObject[4];
    public GameObject wave;

    private GameObject player;
    private GameObject boss;

    private float time;
    public float delay;

    private bool isReady;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.Find("Player");
        boss = GameObject.Find("Boss");

        time = 0;
        isReady = true;

        transform.position = player.transform.position;

        // 7번 패턴임을 알려주는 효과음
    }

    // Update is called once per frame
    void Update() {
        if (isReady) {
            time += Time.deltaTime;
            if (time > delay) {
                isReady = false;
                foreach (GameObject waveMaker in waveMakers) {
                    Instantiate(wave, waveMaker.transform.position, Quaternion.identity);
                }
                CheckAlive();
            }
        }
        
    }

    IEnumerator WaitDestroy() {
        yield return new WaitForSeconds(1f);
        foreach (GameObject waveMaker in waveMakers) {
            Destroy(gameObject);
        }
        boss.GetComponent<PatternB1>().PatternEnd();
    }

    void CheckAlive() {
        StartCoroutine(WaitDestroy());
    }
}