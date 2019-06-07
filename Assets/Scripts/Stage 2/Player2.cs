using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public bool isHoneyAttached;
    private GameObject boss;

    // Start is called before the first frame update
    void Start()
    {
        isHoneyAttached = false;
        boss = GameObject.Find("Boss");
    }

    // Update is called once per frame
    void Update() {
        if (isHoneyAttached) {
            GiveHoneyInformation();
        }

    }

    void GiveHoneyInformation() {
        boss.GetComponent<Boss2>().isHoneyAttached = true;
        foreach(GameObject BulletBeeB in GameObject.FindGameObjectsWithTag("BulletBeeB")) {
            BulletBeeB.GetComponent<BulletBeeB>().isHoneyAttached = true;
        }
        isHoneyAttached = false;
    }
}
