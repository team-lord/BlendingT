using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowMove2 : MonoBehaviour
{
    // TODO - 떨어지는 애니메이션 언제 시작할지 잘 생각해서 알려주세요

    public GameObject bullet8;

    private GameObject player;
    private GameObject boss;
    
    public float movingDelay; // 플레이어를 따라서 이동하는 시간 ~= 0.5
    public float fallDelay; // 이동을 멈추고 지면에 떨어질때 까지의 시간 ~= 1
    private bool isMove;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        boss = GameObject.Find("Boss");

        isMove = true;
        time = 0;

        // localScale = new Vector3 (0, 0, 1) 부터 시작. 점점 커지는 애니메이션 시작
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (isMove) {
            transform.position = player.transform.position;
            if(time > movingDelay) {
                isMove = false;
                boss.transform.position = transform.position;
                time = 0;
            }
        } else {
            if(time > fallDelay) {
                // 보스가 지면에 떨어지는 애니메이션은 여기서 끝나야 함!
                // 그와 동시에 localScale = new Vector3 (1, 1, 1)이 되는 커지는 애니메이션도 종료(Destroy 예정이므로 굳이 종료할 필요는 없음)
                for(int i=0; i<20; i++) {
                    Fire(18 * i);
                }
                CheckDestroy();
            }
        }
        
    }

    void Fire(int degree) {
        Instantiate(bullet8, transform.position, Quaternion.Euler(new Vector3(0, 0, degree)));
    }

    void CheckDestroy() {
        boss.GetComponent<PatternB2>().PatternEnd();
        Destroy(gameObject);
    }
}
