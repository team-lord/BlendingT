using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBeeAB2 : MonoBehaviour
{
    public GameObject beebulletA;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire() {
        Instantiate(beebulletA, transform.position + 2 * Vector3.left, transform.rotation);
        Instantiate(beebulletA, transform.position + 2 * Vector3.right, transform.rotation);
    }
}
