using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceBulletMove1 : MonoBehaviour
{
    public float life;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, life);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move() {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime, Space.Self);
    }
}
