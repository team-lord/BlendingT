using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow1 : MonoBehaviour
{
    public int index;
    
    public Sprite onSprite;
    private Sprite offSprite;

    private GameObject billiardTable;

    private bool isReady;
    public float delay;

    // Start is called before the first frame update
    void Start()
    {
        offSprite = GetComponent<SpriteRenderer>().sprite;

        billiardTable = GameObject.Find("BilliardTable");

        isReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnOn() {
        StartCoroutine(Sprite());
        billiardTable.GetComponent<BilliardTable1>().MoveGravity(index);
    }

    IEnumerator Sprite() {
        GetComponent<SpriteRenderer>().sprite = onSprite;
        yield return new WaitForSeconds(delay);
        GetComponent<SpriteRenderer>().sprite = offSprite;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (isReady) {
            if(collision.tag == "PuzzleBall") {
                isReady = false;
                GetComponentInParent<Arrows1>().Change(index);
            }
        }
    }
}
