using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackCore : MonoBehaviour
{
    public Sprite meleeCore;
    public Sprite rangeCore;
    // public Sprite bowCore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Melee() {
        GetComponent<Image>().sprite = meleeCore;
    }

    public void Range() {
        GetComponent<Image>().sprite = rangeCore;
    }

    /* public void Bow() {
        GetComponent<Image>().sprite = bowCore;
    } */
}
