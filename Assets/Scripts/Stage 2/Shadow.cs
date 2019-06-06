using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour {
    private GameObject player;
    /*
    1안: 플레이어와 이동속도 무조건 똑같음(구르기 포함)
    2안: 플레이어와 무관한 이동속도. 방향만 따라감

    이 스크립트는 1안 기준이며 수정될 수 있음

    확인 - 1안으로 결정
    */

    public float delay1Q; // 그림자가 이동하는 시간, 0.5
    public float delay2Q; // 그림자가 멈추고 떨어질때까지 걸리는 시간, 1
    private float time;
    private bool isFollowing;

    public GameObject bulletQ;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.Find("Player");

        time = 0;
        isFollowing = true;

        transform.localScale = new Vector3(0.5f, 0.5f, 0);
    }

    // Update is called once per frame
    void Update() {
        time += Time.deltaTime;

        if (isFollowing) {
            Follow();
            CheckFollowing();
        } else {
            Fall(); // 커지는 애니메이션 포함(localScale을 Update)
            // 보스가 떨어지는 애니메이션은 보스에서 처리
            CheckDestroying();
        }

    }

    void Follow() {
        transform.position = player.transform.position;
    }

    void Fall() {
        float _scale = time / (2 * delay2Q) + 0.5f;
        transform.localScale = new Vector3 (_scale, _scale, 1);
    }

    void CheckFollowing() {
        if (time >= delay1Q) {
            isFollowing = false;
            time = 0;
        }
    }

    void CheckDestroying() {
        if(time >= delay2Q) {
            Destroy(gameObject);
        }
    }
}
