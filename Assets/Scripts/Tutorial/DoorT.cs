using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorT : MonoBehaviour
{
    public GameObject leverMelee;
    public GameObject leverBullet;

    private bool meleeOn;
    private bool bulletOn;

    // Start is called before the first frame update
    void Start()
    {
        meleeOn = false;
        bulletOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeMelee(bool isMelee) {
        if (isMelee) {
            meleeOn = true;
        } else {
            bulletOn = true;
        }
        Check();
    }
    
    void Check() {
        if(meleeOn && bulletOn) {
            Open();
        }
    }

    void Open() {
        Debug.Log("Open");
        // TODO - 문이 열리는 애니메이션
    }
}
