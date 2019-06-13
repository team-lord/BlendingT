using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleStartButton : MonoBehaviour
{
    public GameObject puzzleBall;

    private GameObject player;
    private GameObject boss;

    public Sprite buttonOn;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        boss = GameObject.Find("Boss");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "PlayerBullet" || collision.tag == "PlayerMelee") {
            GetComponent<SpriteRenderer>().sprite = buttonOn;
            // TODO - 쇠공이 나와서 굴러가기 시작
            // puzzleManager.GetComponent<PuzzleManager>().Ready();
        }
    }
}
