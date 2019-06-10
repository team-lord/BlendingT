using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurpriseBoxChecker : MonoBehaviour
{
    private bool isExist;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collider) {
        if(collider.tag == "SurpriseBox") {
            isExist = true;
        } else {
            isExist = false;
        }
    }

    public bool ExistSurpriseBox() {
        return isExist;
    }
}
