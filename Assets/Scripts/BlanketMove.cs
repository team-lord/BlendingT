using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlanketMove : MonoBehaviour
{
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1f);
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        transform.localScale += new Vector3(3 * time, 3 * time, 0);
    }
}
