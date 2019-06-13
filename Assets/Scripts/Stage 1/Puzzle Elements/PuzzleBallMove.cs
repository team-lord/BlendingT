using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBallMove : MonoBehaviour
{
    private Vector3 direction;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        direction = Vector3.right;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move() {
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }

    public void Direction(Vector3 _direction) {
        direction = _direction;
        direction.Normalize();
    }
}
