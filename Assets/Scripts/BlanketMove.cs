using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlanketMove : MonoBehaviour
{
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Blanket Explode");
        Destroy(gameObject, 0.1f);
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        transform.localScale += new Vector3(time, time, 0);
    }
}
