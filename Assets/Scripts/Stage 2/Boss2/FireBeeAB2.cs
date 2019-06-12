using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBeeAB2 : MonoBehaviour
{
    public GameObject beeA;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire() {
        Instantiate(beeA, transform.position + 2 * Vector3.left, transform.rotation);
        Instantiate(beeA, transform.position + 2 * Vector3.right, transform.rotation);
    }
}
