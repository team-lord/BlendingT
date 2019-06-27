using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMaker12 : MonoBehaviour
{
    public GameObject bullet;

    public bool shootUpside;

    private float time;
    public float delay;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > delay) {
            time = 0;
            if (shootUpside) {
                Instantiate(bullet, transform.position, Quaternion.identity);
            } else {
                Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 180)));
            }
        }
    }
}
