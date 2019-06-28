using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorT : MonoBehaviour
{
    private Vector3 mousePosition;
    private float offsetZ;

    // Start is called before the first frame update
    void Start() {
        offsetZ = Camera.main.transform.position.z;
    }

    // Update is called once per frame
    void FixedUpdate() {
        GetMousePosition();
        TranslateLocationToWorld();
    }

    void GetMousePosition() {
        mousePosition = Input.mousePosition;
    }

    void TranslateLocationToWorld() {
        transform.position = mousePosition;
    }
}
