using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyExplosiveBullet2 : MonoBehaviour
{
    // TODO - 꼭 확인
    /* 처음 시작하면 플레이어의 위치를 찾아서 날아간다
     * 터지면서 6방향으로 꿀 탄알을 날림
     * 터진 자리에 꿀 웅덩이를 남김 - 꿀 웅덩이는 Honey2
     */

    private GameObject player;
    private Vector3 target;
    
    public float delay; // 몇초 후에 떨어지기 시작?

    public GameObject bullet;
    public GameObject honeyFloor;
    private bool isReady;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        target = player.transform.position;

        isReady = false;

        animator = GetComponent<Animator>();
        
        StartCoroutine(Fall());
    }

    IEnumerator Fall() { // 애니메이션 보스처럼 구현하면 됨
        animator.SetTrigger("jump"); // 확인
        yield return new WaitForSeconds(delay);
        transform.position = target;
        //animator.SetTrigger("fall"); // 확인
        StartCoroutine(Explode());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Explode() {
        yield return new WaitForSeconds(0.2f);
        for(int i=0; i<6; i++) {
            Fire(60 * i);
        }
        Instantiate(honeyFloor, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    void Fire(int degree) {
        Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, degree)));
    }
}
