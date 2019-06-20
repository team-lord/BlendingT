using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audience1 : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[5];
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScoreChange(int step) {
        if(step < 5) {
            GetComponent<SpriteRenderer>().sprite = sprites[step];
        } else {
            Debug.Log("Error");
        }
    }
}
