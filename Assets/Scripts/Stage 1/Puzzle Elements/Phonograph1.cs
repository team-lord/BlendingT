using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phonograph1 : MonoBehaviour
{
    private GameObject dolls;

    private int currentNumber; // 0, 1, 2, 3: Off
    
    // Start is called before the first frame update

    void Start()
    {
        dolls = GameObject.Find("Dolls");

        currentNumber = 3;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Change() {

        if(currentNumber < 3) {
            currentNumber++;
        } else {
            currentNumber = 0;
        }

        dolls.GetComponent<Dolls1>().Change(currentNumber);
        
    }
}
