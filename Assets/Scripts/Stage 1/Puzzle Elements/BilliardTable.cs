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

}
