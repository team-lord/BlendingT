using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlanketP1 : MonoBehaviour
{
    public GameObject blanket;
    private bool canBlanket;

    public Image blanketImage;

    private GameObject audienceManager;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        canBlanket = false;

        audienceManager = GameObject.Find("AudienceManager");

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (canBlanket) {
                UseBlanket();
                audienceManager.GetComponent<AudienceManager1>().Blanket();
            }
        }
    }

    void UseBlanket() {
        canBlanket = false;
        blanketImage.GetComponent<NullifyingCore>().UseBlanket();
        Instantiate(blanket, transform.position, Quaternion.identity);
    }

    public void GetBlanket() {
        Debug.Log("GetBlanket");
        animator.SetTrigger("getBlanket");
        canBlanket = true;
        blanketImage.GetComponent<NullifyingCore>().GetBlanket();
    }
}
