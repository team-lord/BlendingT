using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Club : MonoBehaviour
{
    // 수명
    public float lifeQ;

    // GameObject
    private GameObject player;
    private GameObject boss;

    // Sweep
    private float sweepAngleVelocity;
    private float sweepingTime;
    private bool isClockwise;
    private bool isDetermined;
    public float delayQ;
    private bool isReady;

    private float time;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeQ);

        player = GameObject.Find("Player");
        boss = GameObject.Find("Boss");

        sweepAngleVelocity = boss.GetComponent<Boss1>().sweepAngleVelocityQ;
        sweepingTime = boss.GetComponent<Boss1>().sweepingTimeQ;
        isDetermined = false;
        isReady = false;

        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDetermined) {
            DetermineDirection();
        }

        if (!isReady) {
            time += Time.deltaTime;
            if (time > delayQ) {
                isReady = true;
            }
        } else {
            Sweep(isClockwise);
        }
       
    }

    void DetermineDirection() {
        Vector3 _direction = boss.GetComponent<Boss1>().orthogonalDirection;
        Vector3 _crossProduct = Vector3.Cross(_direction, (player.transform.position - transform.position).normalized);

        if (_crossProduct.z >= 0) {
            isClockwise = true; // false
        } else {
            isClockwise = false; // true
        } // 아직 어디가 z의 양수인지 생각 안해서 모름. 해보고 바꾸면 됌
    }

    void Sweep(bool isClockwise) {
        if (isClockwise) {
            transform.Rotate(new Vector3(0, 0, sweepAngleVelocity * Time.deltaTime), Space.Self);
        } else {
            transform.Rotate(new Vector3(0, 0, -sweepAngleVelocity * Time.deltaTime), Space.Self);
        }
    }

    // Club은 Blanket에 면역
    /*
    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Blanket") {
            Destroy(gameObject);
        }
    }
    */
}
