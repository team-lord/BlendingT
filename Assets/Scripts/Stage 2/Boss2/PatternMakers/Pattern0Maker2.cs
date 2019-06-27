using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern0Maker2 : MonoBehaviour {
    public GameObject bullet0;

    public int repetition;
    private int count;
    public float delay;
    private float time;

    private GameObject player;
    private GameObject boss;

    // Start is called before the first frame update
    void Start() {
        count = 0;
        time = 0;

        player = GameObject.Find("Player");
        boss = GameObject.Find("Boss");

    }

    // Update is called once per frame
    void Update() {
        time += Time.deltaTime;
        if (time > delay) {
            // 6각형 탄알 쏘는 애니메이션 시작
            Fire();

            time = 0;
            count++;
            CheckDestroy();
        }
    }

    void Fire() {
        Vector3 _direction = (player.transform.position - transform.position).normalized;

        Instantiate(bullet0, transform.position, Quaternion.FromToRotation(Vector3.up, _direction));
    }

    void CheckDestroy() {
        if (count >= repetition) {
            boss.GetComponent<PatternB2>().PatternEnd();
            Destroy(gameObject);
        }
    }
}
