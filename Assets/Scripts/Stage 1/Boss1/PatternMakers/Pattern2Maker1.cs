using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern2Maker1 : MonoBehaviour
{
    private GameObject boss;

    public GameObject surpriseBox;

    public float triangleRange;

    private Vector3 upLocation;
    private Vector3 downLeftLocation;
    private Vector3 downRightLocation;

    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.Find("Boss");

        if (GameObject.FindGameObjectsWithTag("SurpriseBox") != null){
            boss.GetComponent<PatternB1>().ForceStart();
            Destroy(gameObject);
        }

        upLocation = new Vector3(0, triangleRange, 0);
        downLeftLocation = new Vector3(triangleRange * Mathf.Sqrt(3) / 2, -triangleRange / 2, 0);
        downRightLocation = new Vector3(-triangleRange * Mathf.Sqrt(3) / 2, -triangleRange / 2, 0);

        Instantiate(surpriseBox, upLocation, transform.rotation);
        Instantiate(surpriseBox, downLeftLocation, transform.rotation);
        Instantiate(surpriseBox, downRightLocation, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        boss.GetComponent<PatternB1>().PatternEnd();
        Destroy(gameObject);
    }
}
