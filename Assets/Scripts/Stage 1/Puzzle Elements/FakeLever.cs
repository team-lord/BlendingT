using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeLever : MonoBehaviour {

    private bool isReady;
    public float delay;

    public int number;

    // Start is called before the first frame update
    void Start() {
        isReady = true;
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "PlayerMelee") {
            GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
            GetComponentInParent<FakeLevers>().Change(number);
        }
    }

    public void TurnOff() {
        GetComponent<SpriteRenderer>().flipX = false;
    }
}
