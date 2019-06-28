using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern2Maker1 : MonoBehaviour
{
    private GameObject boss;

    public GameObject surpriseBox;

    public float range;
    
    private Vector3 upLocation;
    private Vector3 downLeftLocation;
    private Vector3 downRightLocation;

    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.Find("Boss");

        if (GameObject.FindGameObjectsWithTag("SurpriseBox").Length != 0){
            boss.GetComponent<PatternB1>().ForceStart();
            Destroy(gameObject);
            return;
        }
        
        upLocation = new Vector3(0, range, 0);
        downLeftLocation = new Vector3(range * Mathf.Sqrt(3) / 2, -range / 2, 0);
        downRightLocation = new Vector3(-range * Mathf.Sqrt(3) / 2, -range / 2, 0);

        Instantiate(surpriseBox, upLocation, Quaternion.identity);
        Instantiate(surpriseBox, downLeftLocation, Quaternion.identity);
        Instantiate(surpriseBox, downRightLocation, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        boss.GetComponent<PatternB1>().PatternEnd();
        Destroy(gameObject);
    }
}
