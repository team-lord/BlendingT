using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulb : MonoBehaviour
{
    public GameObject sunflower;
    
    private bool isBulbOn;
    private bool isReady;

    // Start is called before the first frame update
    void Start()
    {
        isBulbOn = false;
        isReady = false;
    }

    // Update is called once per frame
    void Update() {
        if (isReady) {
            isReady = false;
            if (isBulbOn) {
                // TODO - 전구가 꺼지는 애니메이션 시작
                // 꺼지면 
            } else {
                // TODO - 전구가 켜지는 애니메이션
            }
            sunflower.GetComponent<Sunflower>().IsReady();
            isBulbOn = !isBulbOn;
        }
    }
    
    public void IsReady() {
        isReady = true;
    }
        
}
