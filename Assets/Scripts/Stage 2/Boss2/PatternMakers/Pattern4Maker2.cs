using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern4Maker2 : MonoBehaviour
{
    public GameObject[] bullet4s = new GameObject[3];
    public int maxFire; // new
    public float fireDelay; // new
    private int count; // new
    private float frameTime; // new

    private GameObject player;
    private GameObject boss;

    private Vector3[] directions = new Vector3[3];
    private Vector3 playerMovement;
    private float time;
    

    // Start is called before the first frame update
    void Start()
    {
        count = 0; // new
        frameTime = 0;
        player = GameObject.Find("Player");
        boss = GameObject.Find("Boss");
        
        playerMovement = player.GetComponent<MoveTumbleP2>().MoveDirection();
        /*
        Vector3 _direction = player.transform.position - transform.position;
        time = _direction.magnitude / bullet4s[0].GetComponent<BulletMove>().moveSpeed;

        directions[0] = _direction;
        directions[1] = _direction + 5 * playerMovement * time;
        directions[2] = directions[0] + directions[1];

        for(int i=0; i<3; i++) {
            Fire(i);
        }

        CheckDestroy();
        */
    }

    void Fire(int i) {
        Instantiate(bullet4s[i], transform.position, Quaternion.FromToRotation(Vector3.up, directions[i].normalized));
    }

    // Update is called once per frame
    void Update() // new
    {
        frameTime += Time.deltaTime;
        if (frameTime > fireDelay)
        {
            Vector3 _direction = player.transform.position - transform.position;
            time = _direction.magnitude / bullet4s[0].GetComponent<BulletMove>().moveSpeed;

            directions[0] = _direction;
            directions[1] = _direction + 5 * playerMovement * time;
            directions[2] = directions[0] + directions[1];

            for (int i = 0; i < 3; i++)
            {
                Fire(i);
            }
            count++;
            frameTime = 0;
        }
        if(count >= maxFire)
        {
            CheckDestroy();
        }
    }

    void CheckDestroy() {
        boss.GetComponent<PatternB2>().PatternEnd();
        Destroy(gameObject);
    }
}
