using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunflower : MonoBehaviour
{
    private bool isReady;

    private bool isBulbOn;

    // Start is called before the first frame update
    void Start()
    {
        isReady = false;
        isBulbOn = false;
    }

    // Update is called once per frame
    void Update() {
        if (isReady) {
            isReady = false;
            if (isBulbOn) {
                // TODO - 줄기가 짧아지는 애니메이션 시작
            } else {
                // TODO - 줄기가 길어지는 애니메이션 시작
            }
            isBulbOn = !isBulbOn;
        }
    }

    public void IsReady() {
        isReady = true;
    }
}
