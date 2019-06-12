using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForgedPattern4Maker2 : MonoBehaviour {
    public GameObject[] bullet4s = new GameObject[5];

    private GameObject player;
    private GameObject boss;

    private Vector3[] directions = new Vector3[5];
    private Vector3 playerMovement;
    private float time;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.Find("Player");
        boss = GameObject.Find("Boss");

        playerMovement = player.GetComponent<MoveTumbleP>().MoveDirection();
        Vector3 _direction = player.transform.position - transform.position;
        time = _direction.magnitude / bullet4s[0].GetComponent<BulletMove>().moveSpeed;

        directions[0] = _direction;
        directions[1] = _direction + playerMovement * time;
        directions[2] = _direction - playerMovement * time;
        directions[3] = directions[0] + directions[1];
        directions[4] = directions[0] + directions[2];

        for (int i = 0; i < 5; i++) {
            Fire(i);
        }

        CheckDestroy();
    }

    void Fire(int i) {
        Instantiate(bullet4s[i], transform.position, Quaternion.FromToRotation(Vector3.up, directions[i].normalized)); // 사실 normalized는 의미없음
    }

    // Update is called once per frame
    void Update() {

    }

    void CheckDestroy() {
        boss.GetComponent<PatternB2>().PatternEnd();
        Destroy(gameObject);
    }
}
