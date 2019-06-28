using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleStartButton1 : MonoBehaviour
{
    private GameObject puzzleBall;

    private bool isReady;

    private GameObject player;
    private GameObject boss;

    public Sprite buttonOn;
    private Sprite buttonOff;

    private GameObject flower;
    private GameObject plankMachine;
    private GameObject dolls;

    private bool isDoingPuzzle;

    // Start is called before the first frame update
    void Start()
    {
        puzzleBall = GameObject.Find("PuzzleBall");

        isReady = true;

        player = GameObject.Find("Player");
        boss = GameObject.Find("Boss");

        buttonOff = GetComponent<SpriteRenderer>().sprite;

        flower = GameObject.Find("Flower");
        plankMachine = GameObject.Find("PlankMachine");
        dolls = GameObject.Find("Dolls");

        isDoingPuzzle = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDoingPuzzle) {
            if (Input.GetKeyDown(KeyCode.R)) {
                // 리셋
                isDoingPuzzle = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (isReady) {
            if (collision.tag == "PlayerMelee") {
                isReady = false;
                isDoingPuzzle = true;

                GetComponent<SpriteRenderer>().sprite = buttonOn;

                flower.GetComponent<PolygonCollider2D>().enabled = true;
                plankMachine.GetComponent<PolygonCollider2D>().enabled = true;
                dolls.GetComponent<Dolls1>().PuzzleStart();

                puzzleBall.GetComponent<Rigidbody2D>().AddForce(180 * Vector2.right);
                Camera.main.GetComponent<CameraMove1>().WatchPuzzleBall1st();
                player.GetComponent<MoveTumbleP1>().CanMoveTumble1(false);
                player.GetComponent<AttackFireP1>().CanAttackFire(false);
            }
        }        
    }

    public void Initialize() {
        isReady = true;
        isDoingPuzzle = false;
        GetComponent<SpriteRenderer>().sprite = buttonOff;
    }

    public void IsDoingPuzzle(bool _bool) {
        isDoingPuzzle = _bool;
    }
}
