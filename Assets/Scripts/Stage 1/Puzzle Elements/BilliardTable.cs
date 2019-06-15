using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BilliardTable : MonoBehaviour
{
    public GameObject[] balls = new GameObject[7];

    private Vector2[] originalPosition = new Vector2[7];
    
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0; i<7; i++) {
            originalPosition[i] = balls[i].transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    public void MoveGravity(int index) {
        switch (index) {
            case 0: // Up
                break;
            case 1: // Down
                break;
            case 2: // Left
                break;
            case 3: // Right
                break;
        }

    }

    public void Initialize() {
        for (int i = 0; i < 7; i++) {
            balls[i].transform.position = originalPosition[i];
        }
    }
}
