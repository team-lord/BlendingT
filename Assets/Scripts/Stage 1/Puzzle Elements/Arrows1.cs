using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrows1 : MonoBehaviour
{
    private GameObject billiardTable;

    public GameObject[] arrowUp = new GameObject[2];
    public GameObject[] arrowDown = new GameObject[2];
    public GameObject[] arrowLeft = new GameObject[2];
    public GameObject[] arrowRight = new GameObject[2];

    // Start is called before the first frame update
    void Start()
    {
        billiardTable = GameObject.Find("BilliardTable");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Change(int index) {
        switch (index) {
            case 0:
                foreach (GameObject arrow in arrowUp) {
                    arrow.GetComponent<Arrow1>().TurnOn();
                }
                break;
            case 1:
                foreach (GameObject arrow in arrowDown) {
                    arrow.GetComponent<Arrow1>().TurnOn();
                }
                break;
            case 2:
                foreach (GameObject arrow in arrowLeft) {
                    arrow.GetComponent<Arrow1>().TurnOn();
                }
                break;
            case 3:
                foreach (GameObject arrow in arrowRight) {
                    arrow.GetComponent<Arrow1>().TurnOn();
                }
                break;
            default:
                Debug.Log("Error");
                break;
        }
        Camera.main.GetComponent<CameraMove1>().WatchBilliardTable();
        billiardTable.GetComponent<BilliardTable1>().MoveGravity(index);
    }
}
