using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2Move1 : MonoBehaviour
{
    private float time;
    public float range;

    private float life;

    private Vector2 location;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, Mathf.PI / 3);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        location.x = range * Mathf.Cos(time) * Mathf.Sin(3 * time);
        location.y = range * Mathf.Sin(time) * Mathf.Sin(3 * time);
        transform.position = location;
    }
}
