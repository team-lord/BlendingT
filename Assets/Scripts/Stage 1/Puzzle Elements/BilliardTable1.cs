using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BilliardTable1 : MonoBehaviour
{
    public GameObject[] balls = new GameObject[7];

    private Vector2[] originalPosition = new Vector2[7];

    private GameObject puzzleBall;

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<7; i++) {
            originalPosition[i] = balls[i].transform.localPosition;
        }
        puzzleBall = GameObject.Find("PuzzleBall");
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
        for (int i = 0; i < 7; i++) {
            balls[i].GetComponent<Rigidbody2D>().WakeUp();
        }
        switch (index) {
            case 0: // Up
                foreach(GameObject ball in balls) {
                    ball.GetComponent<Rigidbody2D>().AddForce(15 * Vector2.up);
                }
                break;
            case 1: // Down
                foreach (GameObject ball in balls) {
                    ball.GetComponent<Rigidbody2D>().AddForce(15 * Vector2.down);
                }
                break;
            case 2: // Left
                foreach (GameObject ball in balls) {
                    ball.GetComponent<Rigidbody2D>().AddForce(15 * Vector2.left);
                }
                break;
            case 3: // Right
                foreach (GameObject ball in balls) {
                    ball.GetComponent<Rigidbody2D>().AddForce(15 * Vector2.right);
                }
                break;
        }
    }

    public void Initialize() {
        for (int i = 0; i < 7; i++) {
            balls[i].transform.localPosition = originalPosition[i];
            balls[i].transform.rotation = Quaternion.identity;
            balls[i].GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            balls[i].GetComponent<Rigidbody2D>().angularVelocity = 0;
            balls[i].GetComponent<Rigidbody2D>().Sleep();
        }
        GameObject.Find("2ndPuzzleBall").GetComponent<Rigidbody2D>().gravityScale = 0;
    }
    
}
