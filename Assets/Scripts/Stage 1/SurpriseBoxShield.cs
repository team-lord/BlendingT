using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurpriseBoxShield : MonoBehaviour
{
    private float life;
    public GameObject surpriseBox;

    // Start is called before the first frame update
    void Start()
    {
        life = surpriseBox.GetComponent<SurpriseBoxHealth>().shieldDelay;

        Destroy(gameObject, life);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
