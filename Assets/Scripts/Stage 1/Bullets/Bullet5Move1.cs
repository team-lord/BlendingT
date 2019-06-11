using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet5Move1 : MonoBehaviour
{
    // bullet5 는 laser입니다.

    public float moveSpeed; // fast

    public GameObject echo; // 잔상
    public float afterimageDelay;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        time += Time.deltaTime;
        if(time > afterimageDelay) {
            Instantiate(echo, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    void Move() {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime, Space.Self);
    }

    // TODO - collider 설정
    // player 피격 및 공포탄 피격 collider는 laser전체. 벽 collider는 아래쪽만(그래야 사라지는게 안 이상함)
    
}
