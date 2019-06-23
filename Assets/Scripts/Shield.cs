using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public float life;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        Destroy(gameObject, life);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
    }
}
