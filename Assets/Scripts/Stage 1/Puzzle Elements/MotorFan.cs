using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorFan : MonoBehaviour
{
    private bool isMotorFanOn;

    private bool isReady;

    public float delay;

    // Start is called before the first frame update
    void Start()
    {
        isMotorFanOn = false;

        isReady = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Wait() {
        isReady = false;
        yield return new WaitForSeconds(delay);
        isReady = true;
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (isReady) {
            if(collider.tag == "PlayerBullet") {
                StartCoroutine(Wait());
                if (!isMotorFanOn) {
                    // TODO - 들썩 거리는 애니메이션 시작 (끝 없음. 계속 반복)
                } else {
                    // TODO - 애니메이션 종료
                }
            }
        }
    }
}
