using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet4Move1 : MonoBehaviour
{
    public float moveSpeed;

    public float angleVelocity;
    public float rotateDelay;

    private bool isRotate;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        isRotate = false;

        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isRotate) {
            time += Time.deltaTime;
            if (time > rotateDelay) {
                time = 0;
                isRotate = true;

                // 무언가 바뀌었다는 효과음
            }
        } else {
            Rotate();
        }
        
        Move();        
    }

    void Move() {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime, Space.Self);
    }

    void Rotate() {
        transform.Translate(Vector3.right * angleVelocity * Time.deltaTime, Space.Self);
    }
}
