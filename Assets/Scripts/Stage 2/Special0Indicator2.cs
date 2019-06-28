using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special0Indicator2 : MonoBehaviour
{
    private GameObject player;
    private GameObject boss;

    private Vector3 direction;
    private Vector3 originalPosition;

    private bool isReady;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        boss = GameObject.Find("Boss");

        originalPosition = transform.position;

        isReady = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isReady) {
            transform.position = player.transform.position;

            direction = (player.transform.position - boss.transform.position).normalized;
            transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);

            transform.Translate(transform.up);
        }       
    }

    public void IndicatorOn() {
        isReady = true;
    }

    public void IndicatorOff() {
        isReady = false;
        transform.position = originalPosition;
    }
}
