using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet5SlowMove2 : MonoBehaviour
{
    public Vector3 direction;
    public float slowMoveSpeedQ;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        Move();
    }

    void Move() {
        transform.Translate(Vector3.up * slowMoveSpeedQ * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Blanket") {
            Destroy(gameObject);
        }
    }
}
