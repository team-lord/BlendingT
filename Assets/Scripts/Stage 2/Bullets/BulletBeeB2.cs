using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBeeB2 : MonoBehaviour
{
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    public void Turn() {
        Debug.Log("Turn");
        Vector3 _newDirection = (player.transform.position + RandomVector() - transform.position).normalized;

        transform.rotation = Quaternion.Euler(Vector3.zero);
        transform.rotation = Quaternion.FromToRotation(Vector3.up, _newDirection);
    }

    Vector3 RandomVector() {
        float _x = Mathf.Sin(Random.Range(0, 2 * Mathf.PI));
        float _y = Mathf.Cos(Random.Range(0, 2 * Mathf.PI));
        return new Vector3(_x, _y);
    }
}
;