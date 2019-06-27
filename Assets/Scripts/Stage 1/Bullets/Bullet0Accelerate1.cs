using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet0Accelerate1 : MonoBehaviour
{
    private float extraMoveSpeed;

    public float acceleration;

    // Start is called before the first frame update
    void Start()
    {
        extraMoveSpeed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        extraMoveSpeed += acceleration;
        transform.Translate(Vector3.up * extraMoveSpeed * Time.deltaTime, Space.Self);
    }
}
