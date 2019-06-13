using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BilliardTable : MonoBehaviour
{
    public GameObject[] balls = new GameObject[7];
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "PuzzleBall") {
            foreach (GameObject ball in balls) {
                ball.GetComponent<Rigidbody2D>().gravityScale = 1;
            }
        }
    }
}
