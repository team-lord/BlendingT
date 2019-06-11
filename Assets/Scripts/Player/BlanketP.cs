using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlanketP : MonoBehaviour
{
    public GameObject blanket;
    private bool canBlanket;

    // Start is called before the first frame update
    void Start()
    {
        canBlanket = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(1)) { // 우클릭
            if (canBlanket) {
                UseBlanket();
            }
        }
    }

    void UseBlanket() {
        canBlanket = false;
        Instantiate(blanket, transform.position, transform.rotation);
        // 보스 패턴 끊기
    }

    public void GetBlanket() {
        canBlanket = true;
    }
}
