using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1Move2 : MonoBehaviour
{
    // 속도
    public Vector3 direction;
    public float moveSpeedQ;    
    
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        Move();
    }

    void Move() {
        transform.Translate(Vector3.up * moveSpeedQ * Time.deltaTime, Space.Self);
    }
}
