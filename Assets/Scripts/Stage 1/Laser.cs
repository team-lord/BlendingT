using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // 속도 
    public float moveSpeedQ; // very fast

    // 수명
    public float lifeQ;

    // 진행
    public bool isGoing;
    public float delayQ; // 레이저가 날아온 후 잔상이 날아올때까지의 Delay
    public GameObject afterimageQ;

    // Start is called before the first frame update
    void Start() {
        Destroy(gameObject, lifeQ);

        isGoing = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGoing) {
            Move();
        }
    }

    void Move() {
        transform.Translate(Vector3.up * moveSpeedQ * Time.deltaTime, Space.Self);
        // 길어져야 함
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Blanket") {
            Destroy(gameObject);
        }

        if (isGoing) {
            if (collider.tag == "Wall") {
                isGoing = false;
            }
            StartCoroutine(WaitAfterimage(delayQ));
        }
    }
    
    IEnumerator WaitAfterimage(float time) {
        yield return new WaitForSeconds(time);
        Instantiate(afterimageQ, transform.position, transform.rotation);
    }
}
