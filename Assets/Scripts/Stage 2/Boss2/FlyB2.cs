using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyB2 : MonoBehaviour
{
    // 애니메이션 전용

    private bool isFly;

    // Start is called before the first frame update
    void Start()
    {
        isFly = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fly() {
        isFly = true;
        // TODO - 날기
    }

    public void Fall() {
        if (!isFly) {
            Debug.Log("Boss is not flying");
            return;
        }
        // TODO - 떨어지기
    }
}
