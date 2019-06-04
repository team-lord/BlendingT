using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2Move : MonoBehaviour
{ 
    // 기타
    private GameObject player; // player 죽었을 때 처리
    private GameObject boss;
   
    // 속도
    public Vector3 direction;
    public float moveSpeedQ;
    public float fastMoveSpeedQ;

    private bool rotateFirst;
    private Transform originalTransform;
    private float rotatingVelocity;

    // 수명
    public float lifeQ;

    // 페이즈
    private int phase;
    private bool isTimerOn;
    private float time;
    public float stopTimeQ;
    public float rotatingTimeQ;
    public float circleRadiusQ;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.Find("Player");
        boss = GameObject.Find("Boss");
        rotateFirst = true;
        
        Destroy(gameObject, lifeQ);

        phase = 0;
        isTimerOn = true;
        time = 0;
    }

    // Update is called once per frame
    void Update() {

        if (isTimerOn) {
            time += Time.deltaTime;
            CheckPhase();
        }

        switch (phase) {
            case 0:
                Move();
                break;
            case 1:
                break;
            case 2:
                Rotate();
                break;
            case 3:
                break;
            case 4:
                Move();
                break;
            default:
                Debug.Log("Error");
                break;
        }
    }

    void CheckPhase() {
        switch (phase) {
            case 0:
                if (time > circleRadiusQ / moveSpeedQ) {
                    phase = 1;
                    time = 0;
                }
                break;
            case 1:
                if (time > stopTimeQ) {
                    phase = 2;
                    time = 0;
                }
                break;
            case 2:
                if (time > rotatingTimeQ) {
                    phase = 3;
                    time = 0;
                }
                break;
            case 3:
                if (time > stopTimeQ) {
                    phase = 4;
                    time = 0;
                }
                break;
            case 4:
                isTimerOn = false;
                break;
            default:
                Debug.Log("Error");
                break;
        }
    }

    void Move() {
        transform.Translate(Vector3.up * moveSpeedQ * Time.deltaTime, Space.Self);
    }
    
    void Rotate() {
        if (rotateFirst) {
            originalTransform = transform;
            rotateFirst = false;
            MakeDirection();
            float _offset = Quaternion.Angle(transform.rotation, Quaternion.Euler(direction));
            rotatingVelocity = _offset / rotatingTimeQ;
        }
        transform.rotation = Quaternion.Slerp(originalTransform.rotation, Quaternion.Euler(direction), Time.deltaTime * rotatingVelocity);
    }
    
    void MakeDirection() { // 일단은 보스와 플레이어의 중점.
        Vector3 _goal = (boss.transform.position + player.transform.position) / 2;
        direction = (_goal - transform.position).normalized;
    }

    void FastMove() {
        transform.Translate(Vector3.up * fastMoveSpeedQ * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Blanket") {
            Destroy(gameObject);
        }
    }
}
