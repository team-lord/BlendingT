using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlanketP1 : MonoBehaviour
{
    public GameObject blanket;
    private bool canBlanket;

    private GameObject audienceManager;

    // Start is called before the first frame update
    void Start()
    {
        canBlanket = false;

        audienceManager = GameObject.Find("AudienceManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1)) { // 우클릭
            if (canBlanket) {
                UseBlanket();
                audienceManager.GetComponent<AudienceManager>().Blanket();
            }
        }
    }

    void UseBlanket() {
        canBlanket = false;
        Instantiate(blanket, transform.position, transform.rotation);
    }

    public void GetBlanket() {
        canBlanket = true;
    }
}
