using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet5Move : MonoBehaviour
{
    // 속도
    public float moveSpeedQ;

    // 수명
    public float lifeQ;

    // 회전
    public float angleVelocityQ;
    public float delayQ;
    private bool isClockwise;
    private bool isRotating;
    private bool isReady;

    public bool tumblePulse;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeQ);

        isClockwise = true; // 구르면 반대 방향이 됨.
        isRotating = false;
        isReady = false;

        tumblePulse = false;
    }

    // Update is called once per frame
    void Update() {

        if (!isReady) {
            StartCoroutine(WaitMoveAndRotate(delayQ));
        }        

        if (!isRotating) {
            Move();
        } else {
            MoveAndRotate();
        }
    }

    IEnumerator WaitMoveAndRotate(float time) {
        isReady = true;
        yield return new WaitForSeconds(time);
        isRotating = true;
    }

    void Move() {
        transform.Translate(Vector3.up * moveSpeedQ * Time.deltaTime, Space.Self);
    }

    void MoveAndRotate() {
        transform.Translate(Vector3.up * moveSpeedQ * Time.deltaTime, Space.Self);
        if (tumblePulse) {
            isClockwise = !isClockwise;
            tumblePulse = false;
        }
        if (isClockwise) {
            transform.Translate(Vector3.right * angleVelocityQ * Time.deltaTime, Space.Self);
        } else {
            transform.Translate(Vector3.left * angleVelocityQ * Time.deltaTime, Space.Self);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Blanket") {
            Destroy(gameObject);
        }
    }
}
