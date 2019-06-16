using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BilliardTable1 : MonoBehaviour
{
    public GameObject[] balls = new GameObject[7];

    private Vector2[] originalPosition = new Vector2[7];
    
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<7; i++) {
            originalPosition[i] = balls[i].transform.position;
        }

        StartCoroutine(MoveStart(5, 0));
        StartCoroutine(MoveStart(10, 1));
        StartCoroutine(MoveStart(15, 2));
        StartCoroutine(MoveStart(20, 3));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MoveStart(float time, int index) {
        yield return new WaitForSeconds(time);
        MoveGravity(index);
    }
   
    public void MoveGravity(int index) {
        switch (index) {
            case 0: // Up
                foreach(GameObject ball in balls) {
                    ball.GetComponent<Rigidbody2D>().AddForce(20 * Vector2.up);
                }
                break;
            case 1: // Down
                foreach (GameObject ball in balls) {
                    ball.GetComponent<Rigidbody2D>().AddForce(20 * Vector2.down);
                }
                break;
            case 2: // Left
                foreach (GameObject ball in balls) {
                    ball.GetComponent<Rigidbody2D>().AddForce(20 * Vector2.left);
                }
                break;
            case 3: // Right
                foreach (GameObject ball in balls) {
                    ball.GetComponent<Rigidbody2D>().AddForce(20 * Vector2.right);
                }
                break;
        }
    }

    public void Initialize() {
        for (int i = 0; i < 7; i++) {
            balls[i].transform.position = originalPosition[i];
        }
    }
}
