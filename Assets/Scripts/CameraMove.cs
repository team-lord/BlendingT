using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    public float cameraZ;
    private GameObject player;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void LateUpdate() { // LateUpdate 한번 써봤음
        Camera.main.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, cameraZ);
    }
}
