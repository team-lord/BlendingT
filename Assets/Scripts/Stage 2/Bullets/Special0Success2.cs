using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special0Success2 : MonoBehaviour {

    public float delay;
    private float time;

    public float startDelay;

    private GameObject boss;

    private Vector3 direction;
    private float dot;
    private float angle; // degree
    private float z;

    private bool isReady;

    // Start is called before the first frame update
    void Start() {
        boss = GameObject.Find("Boss");

        time = 0;

        StartCoroutine(IsReady());
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (isReady) {
            time += Time.deltaTime;
            if (time > delay) {
                Rotate();
                time = 0;
            }
        }        
    }

    IEnumerator IsReady() {
        isReady = false;
        yield return new WaitForSeconds(startDelay);
        isReady = true;
    }

    void Rotate() {
        if (gameObject.activeSelf) {
            direction = (boss.transform.position - transform.position).normalized;
            dot = Vector3.Dot(transform.up, direction);
            if (dot < 1) {
                angle = Mathf.Acos(dot) * Mathf.Rad2Deg;
                z = Vector3.Cross(transform.up, direction).z;

                if (z > 0) {
                    angle = transform.rotation.eulerAngles.z + Mathf.Min(10, angle);
                } else {
                    angle = transform.rotation.eulerAngles.z - Mathf.Min(10, angle);
                }

                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log(collision.tag);
        if(collision.transform.name == "Boss") {
            boss.GetComponent<Animator>().SetTrigger("mes");
            Destroy(gameObject);
        }
    }
}
