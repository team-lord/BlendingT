using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyExplosiveBullet2 : MonoBehaviour
{
    // TODO 
    /* 처음 시작하면 플레이어의 위치를 찾아서 날아간다
     * 터지면서 6방향으로 꿀 탄알을 날림
     * 터진 자리에 꿀 웅덩이를 남김 - 꿀 웅덩이는 Honey2
     */

    private GameObject player;
    private Vector3 target;

    public GameObject bullet;
    public GameObject honeyFloor;
    private bool isReady;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        target = player.transform.position;

        isReady = false;

        // 날아가는 애니메이션 시작
        // 애니메이션이 끝나면 isReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isReady) {
            Explode();
        }
    }

    void Explode() {
        for(int i=0; i<6; i++) {
            Fire(60 * i);
        }
        Instantiate(honeyFloor, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    void Fire(int degree) {
        Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, degree)));
    }
}
