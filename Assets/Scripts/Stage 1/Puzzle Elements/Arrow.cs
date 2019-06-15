using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public int index;

    public Sprite[] onSprites = new Sprite[4];
    private Sprite[] offSprites = new Sprite[4];

    public GameObject[] arrows = new GameObject[2];
    private GameObject billiardTable;

    private bool isReady;

    // Start is called before the first frame update
    void Start()
    {
        offSprites[index] = arrows[0].GetComponent<SpriteRenderer>().sprite;
        billiardTable = GameObject.Find("BilliardTable");

        isReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (isReady) {
            if (collision.tag == "PuzzleBall") {
                isReady = false;
                foreach(GameObject arrow in arrows) {
                    arrow.GetComponent<SpriteRenderer>().sprite = onSprites[index];
                }
            }
        }        
    }


}
