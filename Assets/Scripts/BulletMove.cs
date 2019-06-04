using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour {

    // This is friendly BulletMove!

    // 속도
    public float moveSpeedQ;

    // 수명
    public float lifeQ;

    // Start is called before the first frame update
    void Start() {
        Destroy(gameObject, lifeQ);
    }

    // Update is called once per frame
    void Update() {
        Move();
    }

    void Move() {
        transform.Translate(Vector3.up * moveSpeedQ * Time.deltaTime, Space.Self);
    }
    
}
