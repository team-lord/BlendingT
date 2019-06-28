using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForgedPattern2Maker1 : MonoBehaviour
{
    private GameObject boss;

    public GameObject surpriseBox;

    public float range;

    private Vector3 upLocation;
    private Vector3 downLocation;
    private Vector3 leftLocation;
    private Vector3 rightLocation;
    private Vector3 centerLocation;

    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.Find("Boss");

        if (GameObject.FindGameObjectsWithTag("SurpriseBox").Length != 0) {
            boss.GetComponent<PatternB1>().ForceStart();
            Destroy(gameObject);
            return;
        }

        upLocation = new Vector3(0, range, 0);
        downLocation = new Vector3(0, -range, 0);
        leftLocation = new Vector3(-range, 0, 0);
        rightLocation = new Vector3(range, 0, 0);
        centerLocation = Vector3.zero;

        Instantiate(surpriseBox, upLocation, Quaternion.identity);
        Instantiate(surpriseBox, downLocation, Quaternion.identity);
        Instantiate(surpriseBox, leftLocation, Quaternion.identity);
        Instantiate(surpriseBox, rightLocation, Quaternion.identity);
        Instantiate(surpriseBox, centerLocation, Quaternion.identity);
    }

    void Update() {
        boss.GetComponent<PatternB1>().PatternEnd();
        Destroy(gameObject);
    }
}
