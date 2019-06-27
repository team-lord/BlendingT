using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveT : MonoBehaviour {
    
    public float cameraY = 0;
    private GameObject player;

    public float leftLimit;
    public float rightLimit;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void LateUpdate() {
        if (leftLimit < player.transform.position.x & rightLimit > player.transform.position.x) {
            Camera.main.transform.position = new Vector3(player.transform.position.x, cameraY, -10);
        } else if (leftLimit >= player.transform.position.x) {
            Camera.main.transform.position = new Vector3(leftLimit, cameraY, -10);
        } else {
            Camera.main.transform.position = new Vector3(rightLimit, cameraY, -10);
        }
    }
}

