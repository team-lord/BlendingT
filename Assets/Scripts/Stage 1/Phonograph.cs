using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phonograph : MonoBehaviour
{
    public bool isPhonographOn;

    // Start is called before the first frame update
    void Start()
    {
        isPhonographOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPhonographOn) {
            Dance();
        }
    }

    void Dance() {
        // 애니메이션으로 들썩들썩 구현
    }
}
