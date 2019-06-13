using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeBeeB2 : MonoBehaviour
{
    public GameObject beeA;
    public GameObject beeB;

    public float probability; // 0 ~ 1

    private bool isForged;

    private bool isReady;

    // Start is called before the first frame update
    void Start()
    {
        isForged = false;
        isReady = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeBee() {
        if (isReady) {
            if (Random.Range(0f, 1f) < probability) {
                Instantiate(beeA, transform.position + Vector3.left, transform.rotation); // TODO - 맵 밖에서 생성되어야 함
                if (isForged) {
                    Instantiate(beeB, transform.position + Vector3.right, transform.rotation); // TODO - 맵 밖에서 생성되어야 함
                }
            }
        }        
    }

    public void IsReady(bool _bool) {
        isReady = _bool;
    }

    public void Forge() {
        isForged = true;
    }
}
