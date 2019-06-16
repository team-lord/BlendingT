using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet7Move1 : MonoBehaviour {

    // Wave 입니다.

    private float scale; 
    private float time;

    // Start is called before the first frame update
    void Start() {
        time = 0;
    }
    
    // Update is called once per frame
    void Update() {
        time += Time.deltaTime;
        
        scale = 12 * Mathf.Pow(time - 0.5f, 3) - 2 * time + 1.5f;

        transform.localScale = new Vector3(scale, scale, 0);

        if(time > 1f) {
            Destroy(gameObject);
        }
    }
}
