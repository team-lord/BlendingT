using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    public Sprite[] images = new Sprite[6];
    private int health;

    // Start is called before the first frame update
    void Start()
    {
        health = 6;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeImage() {
        health--;
        GetComponent<Image>().sprite = images[health - 1];      
    }
}
