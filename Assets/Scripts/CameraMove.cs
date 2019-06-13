using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    public float cameraZQ;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void LateUpdate() { // LateUpdate 한번 써봤음
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, cameraZQ);
    }
}
