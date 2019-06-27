using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2Move1 : MonoBehaviour {

    private Vector3 position;

    private float time;
    public float range;

    private Vector3 location;
    
    // Start is called before the first frame update
    void Start() {
        Destroy(gameObject, Mathf.PI / 3);
        position = transform.position;
    }

    // Update is called once per frame
    void Update() {
        time += Time.deltaTime;
        
        location.x = range * Mathf.Cos(time) * Mathf.Sin(3 * time);
        location.y = range * Mathf.Sin(time) * Mathf.Sin(3 * time);

        location = transform.rotation * location;

        transform.localPosition = position + location;
    }
}
