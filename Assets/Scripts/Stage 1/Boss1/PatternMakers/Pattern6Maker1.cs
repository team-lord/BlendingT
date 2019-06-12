using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern6Maker1 : MonoBehaviour
{
    public GameObject magicStick;

    public GameObject bullet6;
    public int cornerRepetition;
    public float cornerDelay;
    private float cornerTime;
    private int cornerCount;

    public float delay;

    public float sweepVelocity;
    public float sweepTime;

    private Vector3 orthogonalDirection;

    private GameObject player;
    private GameObject boss;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        cornerTime = 0;
        cornerCount = 0;

        player = GameObject.Find("Player");
        boss = GameObject.Find("Boss");

        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(cornerCount < cornerRepetition) {
            cornerTime += Time.deltaTime;

            if (cornerTime > cornerDelay) {
                for (int i = 0; i < 4; i++) {
                    Fire(45 + 90 * i);
                }

                time = 0;
                cornerCount++;
            }

        }

        if(time < delay) {
            time += Time.deltaTime;
        } else {
            MakeOrthogonalDirection();
            // TODO
            Instantiate(magicStick, transform.position, Quaternion.LookRotation(orthogonalDirection));
        }

        
    }

    void MakeOrthogonalDirection() {
        orthogonalDirection = Vector3.zero;
        Vector3 _direction = (player.transform.position - transform.position).normalized;

        float _max = Vector3.Dot(_direction, Vector3.up);
        orthogonalDirection = Vector3.up;
        if (Vector3.Dot(_direction, Vector3.right) > _max) {
            _max = Vector3.Dot(_direction, Vector3.right);
            orthogonalDirection = Vector3.right;
        }
        if (Vector3.Dot(_direction, Vector3.down) > _max) {
            _max = Vector3.Dot(_direction, Vector3.down);
            orthogonalDirection = Vector3.down;
        }
        if (Vector3.Dot(_direction, Vector3.left) > _max) {
            _max = Vector3.Dot(_direction, Vector3.left);
            orthogonalDirection = Vector3.left;
        }
    }

    void Fire(int degree) {
        Instantiate(bullet6, transform.position, Quaternion.Euler(new Vector3(0, 0, degree)));
    }
}
