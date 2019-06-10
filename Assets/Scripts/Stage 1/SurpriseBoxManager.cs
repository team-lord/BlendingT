using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurpriseBoxManager : MonoBehaviour {
    private GameObject boss;

    public GameObject surpriseBoxQ; // surpriseBox

    public int maxSurpriseBoxQ;
    private int currentSurpriseBox;

    // Start is called before the first frame update
    void Start() {
        boss = GameObject.Find("Boss");

        Instantiate(surpriseBoxQ, transform.position, transform.rotation);
        currentSurpriseBox = 1;

    }

    // Update is called once per frame
    void Update() {
    }

    void CheckAlive() {
        if (currentSurpriseBox <= 0) {
            Destroy(gameObject);
            boss.GetComponent<Boss2>().Pattern3IsPossible();
        }
    }

    public void CheckDestroy() {
        while (currentSurpriseBox > maxSurpriseBoxQ) {
            GameObject _box = GameObject.FindGameObjectWithTag("SurpriseBox");
            Destroy(_box);
            currentSurpriseBox--;
        }
    }

    public void Duplicate() {
        currentSurpriseBox++;
    }

    public void Destroy() {
        currentSurpriseBox--;
        CheckAlive();
    }
}
