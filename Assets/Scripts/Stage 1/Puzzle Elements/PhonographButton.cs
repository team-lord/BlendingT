using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhonographButton : MonoBehaviour
{
    public int number; // answer = 2; 0, 1, 2
    
    public Sprite onSprite;
    private Sprite offSprite;

    // Start is called before the first frame update
    void Start()
    {
        offSprite = GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnOn() {
        GetComponent<SpriteRenderer>().sprite = onSprite;
    }

    public void TurnOff() {
        GetComponent<SpriteRenderer>().sprite = offSprite;
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "PlayerBullet") {
            GetComponentInParent<Phonograph>().Change(number);
        }
    }
}
