using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleStartButton : MonoBehaviour
{
    private GameObject puzzleBall;

    private GameObject player;
    private GameObject boss;

    public Sprite buttonOn;
    private Sprite buttonOff;

    // Start is called before the first frame update
    void Start()
    {
        puzzleBall = GameObject.Find("PuzzleBall");

        player = GameObject.Find("Player");
        boss = GameObject.Find("Boss");

        buttonOff = GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "PlayerMelee") {
            GetComponent<SpriteRenderer>().sprite = buttonOn;
            puzzleBall.GetComponent<PuzzleBallMove>().Direction(Vector3.right);
        }
    }
}
