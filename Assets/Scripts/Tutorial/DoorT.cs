using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorT : MonoBehaviour
{
    // TODO - 문이 열리는 애니메이션
    // 닫히는 애니메이션 필요없음

    public GameObject leverMelee;
    public GameObject leverBullet;

    private bool meleeOn;
    private bool bulletOn;

    // Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        meleeOn = false;
        bulletOn = false;

        // animator = GetComponent<Animator>();
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
        // animator.SetTrigger("open");
    }
}
