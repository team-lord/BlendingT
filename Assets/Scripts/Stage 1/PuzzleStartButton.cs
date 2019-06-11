using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleStartButton : MonoBehaviour
{
    private GameObject player;
    private GameObject boss;

    public Sprite buttonOnQ;
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
            if (collider.tag == "PlayerBullet" || collider.tag == "PlayerMelee") {
                GetComponent<SpriteRenderer>().sprite = buttonOnQ;
                isReady = false;
                puzzleManager.GetComponent<PuzzleManager>().Ready();
            }
        }
    }
}
