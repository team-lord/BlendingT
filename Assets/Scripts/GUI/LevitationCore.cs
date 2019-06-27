using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevitationCore : MonoBehaviour
{
    public Sprite onSprite;
    // public Sprite offSprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetLevitationCore() {
        GetComponent<Image>().color = Color.white;
        GetComponent<Image>().sprite = onSprite;
    }
}
