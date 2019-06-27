using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunflowerCheck1 : MonoBehaviour
{
    private GameObject puzzleBall;

    // Start is called before the first frame update
    void Start()
    {
        puzzleBall = GameObject.Find("PuzzleBall");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "PuzzleBall") {
            puzzleBall.GetComponent<PuzzleBallMove1>().PuzzleFail();
        }
    }
}
