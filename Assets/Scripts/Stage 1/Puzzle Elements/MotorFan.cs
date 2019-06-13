using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorFan : MonoBehaviour
{
    private bool isMotorFanOn;

    private bool isReady;
    public float delayQ;

    public Sprite[] sprites = new Sprite[4];

    private float time;
    public float onOffDelayQ;
    public float animationDelayQ;
    private bool isUp;

    // Start is called before the first frame update
    void Start()
    {
        isMotorFanOn = false;

        isReady = true;

        sprites[0] = GetComponent<SpriteRenderer>().sprite;
        time = 0;
        isUp = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMotorFanOn) {
            Dance();
        }
    }

    void TurnOn() {
        StartCoroutine(AnimationTurnOn(onOffDelayQ));
    }

    IEnumerator AnimationTurnOn(float time) {
        GetComponent<SpriteRenderer>().sprite = sprites[1];
        yield return new WaitForSeconds(time);
        GetComponent<SpriteRenderer>().sprite = sprites[2];
        isMotorFanOn = true; // 끝나고 해야 Dance()랑 안겹침
        isUp = true;
        time = 0;
    }

    void TurnOff() {
        StartCoroutine(AnimationTurnOff(onOffDelayQ));
    }

    IEnumerator AnimationTurnOff(float time) {
        isMotorFanOn = false; // 시작하자마자 해야 Dance()랑 안겹침
        GetComponent<SpriteRenderer>().sprite = sprites[1];
        yield return new WaitForSeconds(time);
        GetComponent<SpriteRenderer>().sprite = sprites[0];
    }

    void Dance() {
        time += Time.deltaTime;
        if(time > animationDelayQ) {
            time = 0;
            if (isUp) {
                GetComponent<SpriteRenderer>().sprite = sprites[3];
                isUp = false;
            } else {
                GetComponent<SpriteRenderer>().sprite = sprites[2];
                isUp = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (isReady) {
            if(collider.tag == "PlayerBullet") {
                if (isMotorFanOn) {
                    TurnOff();
                } else {
                    TurnOn();
                }
            }
        }
    }

    public bool MotorFanOn() {
        return isMotorFanOn;
    }
}
