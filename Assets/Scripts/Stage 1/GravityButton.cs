using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityButton : MonoBehaviour
{
    private bool isReady;

    public GameObject[] balls = new GameObject[6];
    
    // Start is called before the first frame update
    void Start()
    {
        isReady = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (isReady) {
            isReady = false;
            foreach (GameObject ball in balls) {
                ball.GetComponent<Rigidbody2D>().gravityScale = 1;
            }
        }
    }
}
