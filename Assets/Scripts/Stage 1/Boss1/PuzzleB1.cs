using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleB1 : MonoBehaviour {
    private GameObject player;

    public GameObject puzzleStart;
    public GameObject bulb;
    public GameObject bulbLever;
    public GameObject sunflower;
    public GameObject motorFan;
    public GameObject billiardTable;
    public GameObject board;
    public GameObject phonograph;
    public GameObject phonographPeople;
    public GameObject plankMachine;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update() {

    }

    public void InstantiatePuzzle() { // transform.position 다 고치기

        // 플레이어가 맵 중앙으로 움직이는 애니메이션

        Instantiate(puzzleStart, transform.position, transform.rotation);
        Instantiate(bulb, transform.position, transform.rotation);
        Instantiate(bulbLever, transform.position, transform.rotation);
        Instantiate(sunflower, transform.position, transform.rotation);
        Instantiate(motorFan, transform.position, transform.rotation);
        Instantiate(billiardTable, transform.position, transform.rotation);
        Instantiate(board, transform.position, transform.rotation);
        Instantiate(phonograph, transform.position, transform.rotation);
        Instantiate(phonographPeople, transform.position, transform.rotation);
        Instantiate(plankMachine, transform.position, transform.rotation);

    }
    
}
