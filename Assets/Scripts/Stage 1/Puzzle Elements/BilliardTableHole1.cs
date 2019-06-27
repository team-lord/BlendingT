using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BilliardTableHole1 : MonoBehaviour
{
    private GameObject puzzleBall;

    private bool isReady;

    // Start is called before the first frame update
    void Start()
    {
        puzzleBall = GameObject.Find("2ndPuzzleBall");
        isReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (isReady) {
            if (collision.tag == "PuzzleBall") {
                StartCoroutine(IsReady());
                collision.gameObject.transform.position = new Vector3(0, 64, 0);
                puzzleBall.GetComponent<Rigidbody2D>().gravityScale = 1;
                Camera.main.GetComponent<CameraMove1>().WatchPuzzleBall2nd();
            }
        }
    }

    IEnumerator IsReady() {
        isReady = false;
        yield return new WaitForSeconds(5);
        isReady = true;
    }
}
