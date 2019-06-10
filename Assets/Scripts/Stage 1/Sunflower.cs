using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunflower : MonoBehaviour
{

    public bool bulbPulse;
    private bool isBulbOn;

    // Start is called before the first frame update
    void Start()
    {
        bulbPulse = false;
        isBulbOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (bulbPulse && !isBulbOn) {
            isBulbOn = true;
            bulbPulse = false;
            // 줄기가 늘어나는 애니메이션
        } else if (bulbPulse && isBulbOn) {
            isBulbOn = false;
            bulbPulse = false;
            // 줄기가 줄어드는 애니메이션
        }
    }
}
