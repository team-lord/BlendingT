using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private GameObject player;
    private GameObject boss;

    public Sprite leverOnQ;
    private GameObject puzzleManager;

    private bool isReady;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        boss = GameObject.Find("Boss");

        puzzleManager = GameObject.Find("PuzzleManager");

        isReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (isReady) {
            if (collider.tag == "PlayerMelee") {
                GetComponent<SpriteRenderer>().sprite = leverOnQ;
                isReady = false;
                puzzleManager.GetComponent<PuzzleManager>().onPuzzle = true;
            }
        }
    }
}
