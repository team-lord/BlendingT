using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NullifyingCore : MonoBehaviour
{
    public Sprite offSprite;
    private Sprite onSprite;

    // Start is called before the first frame update
    void Start()
    {
        onSprite = GetComponent<Image>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetBlanket() {
        GetComponent<Image>().sprite = onSprite;
    }

    public void UseBlanket() {
        GetComponent<Image>().sprite = offSprite;
    }

}
